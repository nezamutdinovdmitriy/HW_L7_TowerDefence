using Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCast;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityEffects.Explosion;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityEffects.RuneTotem;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityEffects.ToxicPuddle;
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
        private readonly AbilityEffectsFactory _abilityEffectsFactory;
        private readonly WalletService _wallet;

        public AbilityFactory(
            EntitiesLifeContext lifeContext,
            AbilityEffectsFactory combatEntityFactory,
            WalletService wallet)
        {
            _lifeContext = lifeContext;
            _abilityEffectsFactory = combatEntityFactory;
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
                        .AddSystem(new ProjectileSpawnSystem(_abilityEffectsFactory, fireballAbilityConfig));
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
                        .AddSystem(new ArcaneMineSpawnSystem(_abilityEffectsFactory, arcaneMineAbilityConfig));
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
                        .AddSystem(new ExplosionSpawnSystem(_abilityEffectsFactory, explosionAbilityConfig.ExplosionConfig))
                        .AddSystem(new ExplosionConsumeSystem());
                    break;

                case ToxicPuddleAbilityConfig toxicPuddleAbilityConfig:
                    entity = CreateCommon(owner);

                    entity
                        .AddAbilityCastPerSecond(new(toxicPuddleAbilityConfig.CastData.CastPerSecond))
                        .AddAbilityCastInitialTime(new(toxicPuddleAbilityConfig.CastData.InitialTime))
                        .AddAbilityCastModifiedTime(new(toxicPuddleAbilityConfig.CastData.InitialTime))
                        .AddAbilityCastCurrentTime(new(toxicPuddleAbilityConfig.CastData.InitialTime))
                        .AddAbilityCastSpawnEffectDelay(new(toxicPuddleAbilityConfig.CastData.EffectSpawnDelay))
                        .AddAbilityCastSpawnEffectDelayModified(new(toxicPuddleAbilityConfig.CastData.EffectSpawnDelay))
                        .AddAbilitySlot(new(toxicPuddleAbilityConfig.AbilityData.AbilitySlot))
                        .AddAbility(new(toxicPuddleAbilityConfig.AbilityData.AbilityType))
                        .AddSystem(new AbilityCastProcessSystem())
                        .AddSystem(new ToxicPuddleSpawnSystem(_abilityEffectsFactory, toxicPuddleAbilityConfig));
                    break;

                case RuneTotemAbilityConfig runeTotemAbilityConfig:
                    entity = CreateCommon(owner);

                    entity
                        .AddAbilityCastPerSecond(new(runeTotemAbilityConfig.CastData.CastPerSecond))
                        .AddAbilityCastInitialTime(new(runeTotemAbilityConfig.CastData.InitialTime))
                        .AddAbilityCastModifiedTime(new(runeTotemAbilityConfig.CastData.InitialTime))
                        .AddAbilityCastCurrentTime(new(runeTotemAbilityConfig.CastData.InitialTime))
                        .AddAbilityCastSpawnEffectDelay(new(runeTotemAbilityConfig.CastData.EffectSpawnDelay))
                        .AddAbilityCastSpawnEffectDelayModified(new(runeTotemAbilityConfig.CastData.EffectSpawnDelay))
                        .AddAbilitySlot(new(runeTotemAbilityConfig.AbilityData.AbilitySlot))
                        .AddAbility(new(runeTotemAbilityConfig.AbilityData.AbilityType))
                        .AddSystem(new AbilityCastProcessSystem())
                        .AddSystem(new RuneTotemSpawnSystem(_abilityEffectsFactory, runeTotemAbilityConfig));
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