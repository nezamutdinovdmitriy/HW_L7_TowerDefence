using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.HealthFeature;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.UpgradesFeature.DamageFirstEnemies
{
    public class DealDamageToFirstTargetsSystem : IInitializableSystem, IUpdatableSystem
    {
        private readonly EntitiesLifeContext _entitiesLifeContext;
        private readonly int _maxTargets;
        private readonly float _damagePercent;

        private ICompositeCondition _canApplyEffectCondition;
        private ReactiveVariable<bool> _isEffectApplied;

        private Entity _owner;

        public DealDamageToFirstTargetsSystem(int maxTargets, EntitiesLifeContext entitiesLifeContext, float damageAmount)
        {
            _maxTargets = maxTargets;
            _damagePercent = damageAmount;

            _entitiesLifeContext = entitiesLifeContext;
        }

        public void OnInitialize(Entity entity)
        {
            _canApplyEffectCondition = entity.CanApplyEffect;
            _isEffectApplied = entity.IsEffectApplied;

            _owner = entity.Hierarchy.Value.Parent;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_isEffectApplied.Value)
                return;

            if (_canApplyEffectCondition.Evaluate() == false)
                return;

            DealPercentDamageToFirstTargets();

            _isEffectApplied.Value = true;
        }

        private void DealPercentDamageToFirstTargets()
        {
            int hitCount = 0;

            for (int i = 0; i < _entitiesLifeContext.Entities.Count; i++)
            {
                Entity entity = _entitiesLifeContext.Entities[i];

                if (entity.HasComponent<MaxHealth>() == false)
                    continue;

                int damage = Mathf.RoundToInt(entity.MaxHealth.Value * (_damagePercent / 100f));

                if (EntitiesHelper.TryTakeDamageFrom(_owner, _entitiesLifeContext.Entities[i], damage))
                {
                    hitCount++;
                    Debug.Log($"Противник ({hitCount}) получил {damage} урона!");
                }

                if (hitCount >= _maxTargets)
                    break;
            }
        }
    }
}