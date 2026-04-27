using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCast
{
    public class AbilityCastStartSystem : IInitializableSystem, IUpdatableSystem
    {
        private readonly WalletService _wallet;

        private Dictionary<AbilitySlotType, Entity> _abilitiesEquipped;
        private ReactiveVariable<AbilitySlotType> _abilitySlotCurrent;

        private ReactiveVariable<bool> _abilityCastInProcess;
        private ReactiveVariable<Entity> _currentCastingAbility;

        private ICompositeCondition _canCastAbility;

        public AbilityCastStartSystem(WalletService wallet) => _wallet = wallet;


        public void OnInitialize(Entity entity)
        {
            _abilitiesEquipped = entity.AbilitiesEquipped;
            _abilitySlotCurrent = entity.AbilitySlotCurrent;

            _currentCastingAbility = entity.CurrentCastingAbility;
            _canCastAbility = entity.CanCastAbility;
            _abilityCastInProcess = entity.AbilityCastInProcess;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_abilityCastInProcess.Value)
                return;

            if (_canCastAbility.Evaluate() == false)
                return;

            if (_abilitiesEquipped[_abilitySlotCurrent.Value].TryGetShouldSpendCost(out ReactiveVariable<bool> value))
                if (TrySpendAbilityCost() == false)
                    return;

            UpdateCurrentCastingAbility();

            _abilityCastInProcess.Value = true;

            _abilitiesEquipped[_abilitySlotCurrent.Value].ShouldStartProcess.Value = true;
        }

        private void UpdateCurrentCastingAbility()
        {
            _abilitiesEquipped.TryGetValue(_abilitySlotCurrent.Value, out Entity currentCastingAbility);
            _currentCastingAbility.Value = currentCastingAbility;
        }

        private bool TrySpendAbilityCost()
        {
            if(_wallet.Enough(
                _abilitiesEquipped[_abilitySlotCurrent.Value].CurrencyCost,
                _abilitiesEquipped[_abilitySlotCurrent.Value].AbilityCost) == false)
            {
                return false;
            }
            else
            {
                _wallet.Spend(
                    _abilitiesEquipped[_abilitySlotCurrent.Value].CurrencyCost,
                    _abilitiesEquipped[_abilitySlotCurrent.Value].AbilityCost);
                return true;
            }
        }
    }
}