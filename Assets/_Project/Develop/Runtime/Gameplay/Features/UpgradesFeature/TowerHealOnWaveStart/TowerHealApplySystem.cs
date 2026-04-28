using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.UpgradesFeature.TowerHealOnWaveStart
{
    public class TowerHealApplySystem : IInitializableSystem, IUpdatableSystem
    {
        private ICompositeCondition _canApplyEffectCondition;
        private ReactiveVariable<bool> _isEffectApplied;
        private ReactiveVariable<float> _healPercent;

        private Entity _owner;

        public void OnInitialize(Entity entity)
        {
            _canApplyEffectCondition = entity.CanApplyEffect;
            _isEffectApplied = entity.IsEffectApplied;
            _healPercent = entity.Percent;

            _owner = entity.Hierarchy.Value.Parent;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_isEffectApplied.Value == true)
                return;

            if (_canApplyEffectCondition.Evaluate() == false)
                return;

            ApplyHeal();

            _isEffectApplied.Value = true;
        }

        private void ApplyHeal()
        {
            float healAmount = _owner.MaxHealth.Value * (_healPercent.Value / 100f);
            float targetHealth = _owner.CurrentHealth.Value + healAmount;

            _owner.CurrentHealth.Value = Mathf.Min(_owner.MaxHealth.Value, targetHealth);
        }
    }
}