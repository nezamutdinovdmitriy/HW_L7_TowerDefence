using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using TMPro;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.UpgradesFeature.FireballDamageMultiplier
{
    public class DamageMultiplierApplySystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<bool> _isEffectApplied;
        private ReactiveVariable<float> _multiplier;

        private Entity _owner;

        public void OnInitialize(Entity entity)
        {
            _isEffectApplied = entity.IsEffectApplied;
            _multiplier = entity.Multiplier;

            _owner = entity.Hierarchy.Value.Parent;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_isEffectApplied.Value == true)
                return;

            Entity ability;

            foreach (var key in _owner.AbilitiesEquipped.Keys)
            {
                ability = _owner.AbilitiesEquipped[key];

                if (ability.Ability.Value == AbilityType.Fireball)
                {
                    ApplyDamageMultiplier(ability);
                    return;
                }
            }

            foreach (var key in _owner.AbilitiesStorage.Keys)
            {
                foreach (var item in _owner.AbilitiesStorage[key])
                {
                    if (item.Ability.Value == AbilityType.Fireball)
                    {
                        ApplyDamageMultiplier(item);
                        return;
                    }
                }
            }

            _isEffectApplied.Value = true;
        }

        private void ApplyDamageMultiplier(Entity ability)
        {
            ability.AddAbilityDamageMultiplier(new(_multiplier.Value));

            _isEffectApplied.Value = true;
        }
    }
}