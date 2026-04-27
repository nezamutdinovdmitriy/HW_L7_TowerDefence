using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.UpgradesFeature
{
    public class EffectFinalizeSystem : IInitializableSystem, IUpdatableSystem
    {
        private ICompositeCondition _canCanFinalizeEffectCondition;
        private ReactiveVariable<bool> _isEffectApplied;

        public void OnInitialize(Entity entity)
        {
            _isEffectApplied = entity.IsEffectApplied;
            _canCanFinalizeEffectCondition = entity.CanFinalizeEffect;
        }

        public void OnUpdate(float deltaTime)
        {
            if(_isEffectApplied.Value && _canCanFinalizeEffectCondition.Evaluate())
                _isEffectApplied.Value = false;
        }
    }
}