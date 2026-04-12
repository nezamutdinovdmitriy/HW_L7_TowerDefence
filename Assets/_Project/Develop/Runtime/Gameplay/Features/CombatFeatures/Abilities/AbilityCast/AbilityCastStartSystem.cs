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

        private Dictionary<AbilitySlotType, Entity> _abilityStorage;
        private ReactiveVariable<AbilitySlotType> _abilityCurrent;

        private ReactiveVariable<bool> _abilityCastInProcess;

        private ICompositeCondition _canCastAbility;

        public AbilityCastStartSystem(WalletService wallet) => _wallet = wallet;


        public void OnInitialize(Entity entity)
        {
            _abilityStorage = entity.AbilityStorage;
            _abilityCurrent = entity.AbilityCurrent;

            _canCastAbility = entity.CanCastAbility;
            _abilityCastInProcess = entity.AbilityCastInProcess;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_abilityCastInProcess.Value)
                return;

            if (_canCastAbility.Evaluate() == false)
                return;

            _abilityCastInProcess.Value = true;

            _abilityStorage[_abilityCurrent.Value].ShouldStartProcess.Value = true;

            if (_abilityStorage[_abilityCurrent.Value].TryGetShouldSpendCost(out ReactiveVariable<bool> value))
                SpendAbilityCost();
        }

        private void SpendAbilityCost()
        {
            _wallet.Spend(
                _abilityStorage[_abilityCurrent.Value].CurrencyCost,
                _abilityStorage[_abilityCurrent.Value].AbilityCost);
        }
    }
}