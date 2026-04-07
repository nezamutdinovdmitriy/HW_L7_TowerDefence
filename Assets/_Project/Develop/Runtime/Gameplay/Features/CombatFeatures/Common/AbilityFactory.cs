using Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.ArcaneMine;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Fireball;
using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common
{
    public class AbilityFactory
    {
        private readonly EntitiesLifeContext _lifeContext;
        private readonly CombatEntityFactory _combatEntityFactory;
        private readonly WalletService _wallet;

        public AbilityFactory(
            EntitiesLifeContext lifeContext,
            CombatEntityFactory combatEntityFactory,
            WalletService wallet)
        {
            _lifeContext = lifeContext;
            _combatEntityFactory = combatEntityFactory;
            _wallet = wallet;
        }

        public Entity Create(AbilityConfig config, Entity owner)
        {
            Entity entity;

            switch (config)
            {
                case FireballAbilityConfig fireballAbilityConfig:
                    entity = CreateCommon(owner)
                        .AddAbilityFireballConfig(fireballAbilityConfig)
                        .AddSystem(new FireballStartSystem(_combatEntityFactory));
                    break;

                case ArcaneMineAbilityConfig arcaneMineAbilityConfig:
                    ICompositeCondition canSpawnArcaneMine = new CompositeCondition()
                            .Add(new FuncCondition(() => owner.IsDead.Value == false));

                    entity = CreateCommon(owner)
                        .AddAbilityArcaneMineConfig(arcaneMineAbilityConfig)
                        .AddAimPoint(owner.AimPoint)
                        .AddCanUseArcaneMine(canSpawnArcaneMine)
                        .AddArcaneMineCost(new ReactiveVariable<int>(arcaneMineAbilityConfig.ActivationCost))
                        .AddSystem(new ArcaneMineStartSystem(_combatEntityFactory))
                        .AddSystem(new ArcaneMineGoldCostSystem(arcaneMineAbilityConfig.CostCurrency, _wallet));
                    break;

                case ExplosionAbilityConfig explosionAbilityConfig:
                    
                    ICompositeCondition canSpawnExplosion = new CompositeCondition()
                            .Add(new FuncCondition(() => owner.IsDead.Value));

                    entity = CreateCommon(owner)
                        .AddAbilityExplosionConfig(explosionAbilityConfig)
                        .AddTransfrom(owner.Transfrom)
                        .AddCanSpawnExplosion(canSpawnExplosion)
                        .AddSystem(new ExplosionStartSystem(_combatEntityFactory, explosionAbilityConfig));
                    break;

                default:
                    throw new InvalidOperationException();
            }

            return entity;
        }

        private Entity CreateCommon(Entity owner)
        {
            Entity entity = new();

            entity
                .SetParent(owner)
                .AddAbilityUseRequest()
                .AddAbilityStartedEvent()
                .AddTeam(owner.Team)
                .AddSystem(new AbilityStartSystem());

            _lifeContext.Add(entity);

            return entity;
        }
    }
}