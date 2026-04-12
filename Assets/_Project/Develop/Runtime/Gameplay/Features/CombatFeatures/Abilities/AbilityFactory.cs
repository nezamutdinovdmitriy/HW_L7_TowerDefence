using Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCast;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.ArcaneMine;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Fireball;
using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities
{
    public class AbilityFactory
    {
        private readonly EntitiesLifeContext _lifeContext;
        private readonly AbilityEffectsFactory _combatEntityFactory;
        private readonly WalletService _wallet;

        public AbilityFactory(
            EntitiesLifeContext lifeContext,
            AbilityEffectsFactory combatEntityFactory,
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
                        .AddAbilityCastInitialTime(new ReactiveVariable<float>(fireballAbilityConfig.CastData.InitialTime))
                        .AddAbilityCastCurrentTime(new ReactiveVariable<float>(fireballAbilityConfig.CastData.InitialTime))
                        .AddAbilityCastSpawnEffectDelay(new ReactiveVariable<float>(fireballAbilityConfig.CastData.EffectSpawnDelay))
                        .AddAbilitySlot(new ReactiveVariable<AbilitySlotType>(fireballAbilityConfig.AbilityData.AbilitySlot))
                        .AddAbility(new ReactiveVariable<AbilityType>(fireballAbilityConfig.AbilityData.AbilityType))
                        .AddSystem(new AbilityCastProcessSystem())
                        .AddSystem(new ProjectileSpawnSystem(_combatEntityFactory, fireballAbilityConfig));
                    break;

                case ArcaneMineAbilityConfig arcaneMineAbilityConfig:
                    ICompositeCondition canSpawnArcaneMine = new CompositeCondition()
                            .Add(new FuncCondition(() => _wallet.Enough(
                                arcaneMineAbilityConfig.CostCurrency, 
                                arcaneMineAbilityConfig.ActivationCost)));

                    entity = CreateCommon(owner)

                        .AddAbilityCastInitialTime(new ReactiveVariable<float>(arcaneMineAbilityConfig.CastData.InitialTime))
                        .AddAbilityCastCurrentTime(new ReactiveVariable<float>(arcaneMineAbilityConfig.CastData.InitialTime))
                        .AddAbilityCastSpawnEffectDelay(new ReactiveVariable<float>(arcaneMineAbilityConfig.CastData.EffectSpawnDelay))
                        .AddAbilitySlot(new ReactiveVariable<AbilitySlotType>(arcaneMineAbilityConfig.AbilityData.AbilitySlot))
                        .AddAbility(new ReactiveVariable<AbilityType>(arcaneMineAbilityConfig.AbilityData.AbilityType))
                        .AddCanUseArcaneMine(canSpawnArcaneMine)
                        .AddCurrencyCost(arcaneMineAbilityConfig.CostCurrency)
                        .AddAbilityCost(arcaneMineAbilityConfig.ActivationCost)
                        .AddShouldSpendCost()
                        .AddSystem(new AbilityCastProcessSystem())
                        .AddSystem(new ArcaneMineSpawnSystem(_combatEntityFactory, arcaneMineAbilityConfig));
                    break;

                case ExplosionAbilityConfig explosionAbilityConfig:

                    ICompositeCondition canSpawnExplosion = new CompositeCondition()
                            .Add(new FuncCondition(() => owner.IsDead.Value));

                    entity = CreateCommon(owner)
                        .AddTransfrom(owner.Transfrom)
                        .AddCanSpawnExplosion(canSpawnExplosion)
                        .AddExplosionDamage(new(explosionAbilityConfig.ExplosionConfig.ExplosionDamage))
                        .AddExplosionRadius(new(explosionAbilityConfig.ExplosionConfig.ExplosionRadius))
                        .AddSystem(new ExplosionSpawnSystem(_combatEntityFactory, explosionAbilityConfig.ExplosionConfig));
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
                .AddShouldSpawnEffect()
                .AddShouldStartProcess()
                .AddTeam(owner.Team);

            _lifeContext.Add(entity);

            return entity;
        }
    }
}