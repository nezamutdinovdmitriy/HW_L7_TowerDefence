using Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCast;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityEffects.Explosion;
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
                        .AddAbilityCastPerSecond(new(fireballAbilityConfig.CastData.CastPerSecond))
                        .AddAbilityCastInitialTime(new ReactiveVariable<float>(fireballAbilityConfig.CastData.InitialTime))
                        .AddAbilityCastModifiedTime(new ReactiveVariable<float>(fireballAbilityConfig.CastData.InitialTime))
                        .AddAbilityCastCurrentTime(new ReactiveVariable<float>(fireballAbilityConfig.CastData.InitialTime))
                        .AddAbilityCastSpawnEffectDelay(new ReactiveVariable<float>(fireballAbilityConfig.CastData.EffectSpawnDelay))
                        .AddAbilityCastSpawnEffectDelayModified(new ReactiveVariable<float>(fireballAbilityConfig.CastData.EffectSpawnDelay))
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
                        .AddAbilityCastPerSecond(new(arcaneMineAbilityConfig.CastData.CastPerSecond))
                        .AddAbilityCastInitialTime(new ReactiveVariable<float>(arcaneMineAbilityConfig.CastData.InitialTime))
                        .AddAbilityCastModifiedTime(new ReactiveVariable<float>(arcaneMineAbilityConfig.CastData.InitialTime))
                        .AddAbilityCastCurrentTime(new ReactiveVariable<float>(arcaneMineAbilityConfig.CastData.InitialTime))
                        .AddAbilityCastSpawnEffectDelay(new ReactiveVariable<float>(arcaneMineAbilityConfig.CastData.EffectSpawnDelay))
                        .AddAbilityCastSpawnEffectDelayModified(new ReactiveVariable<float>(arcaneMineAbilityConfig.CastData.EffectSpawnDelay))
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
                    entity = CreateCommon(owner);

                    ICompositeCondition shouldExplosion = new CompositeCondition()
                        .Add(new FuncCondition(() => entity.ShouldSpawnEffect.Value));

                    entity
                        .AddAbilityCastPerSecond(new(explosionAbilityConfig.CastData.CastPerSecond))
                        .AddCanSpawnExplosion(shouldExplosion)
                        .AddAbilityCastInitialTime(new ReactiveVariable<float>(explosionAbilityConfig.CastData.InitialTime))
                        .AddAbilityCastModifiedTime(new ReactiveVariable<float>(explosionAbilityConfig.CastData.InitialTime))
                        .AddAbilityCastCurrentTime(new ReactiveVariable<float>(explosionAbilityConfig.CastData.InitialTime))
                        .AddAbilityCastSpawnEffectDelay(new ReactiveVariable<float>(explosionAbilityConfig.CastData.EffectSpawnDelay))
                        .AddAbilityCastSpawnEffectDelayModified(new ReactiveVariable<float>(explosionAbilityConfig.CastData.EffectSpawnDelay))
                        .AddAbilitySlot(new ReactiveVariable<AbilitySlotType>(explosionAbilityConfig.AbilityData.AbilitySlot))
                        .AddAbility(new ReactiveVariable<AbilityType>(explosionAbilityConfig.AbilityData.AbilityType))
                        .AddTransfrom(owner.Transfrom)
                        .AddExplosionDamage(new(explosionAbilityConfig.ExplosionConfig.ExplosionDamage))
                        .AddExplosionRadius(new(explosionAbilityConfig.ExplosionConfig.ExplosionRadius))
                        .AddSystem(new AbilityCastProcessSystem())
                        .AddSystem(new ExplosionSystem(_combatEntityFactory, explosionAbilityConfig.ExplosionConfig))
                        .AddSystem(new ExplosionConsumeSystem());
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