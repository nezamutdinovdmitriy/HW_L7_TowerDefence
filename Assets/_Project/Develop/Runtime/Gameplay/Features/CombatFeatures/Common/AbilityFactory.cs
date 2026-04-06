using Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion;
using Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Fireball;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common
{
    public class AbilityFactory
    {
        private readonly EntitiesLifeContext _lifeContext;
        private readonly CombatEntityFactory _combatEntityFactory;

        public AbilityFactory(EntitiesLifeContext lifeContext, CombatEntityFactory combatEntityFactory)
        {
            _lifeContext = lifeContext;
            _combatEntityFactory = combatEntityFactory;
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
                    entity = CreateCommon(owner);
                    break;

                case ExplosionAbilityConfig explosionAbilityConfig:
                    
                    ICompositeCondition canSpawn = new CompositeCondition()
                            .Add(new FuncCondition(() => owner.IsDead.Value));

                    entity = CreateCommon(owner)
                        .AddAbilityExplosionConfig(explosionAbilityConfig)
                        .AddTransfrom(owner.Transfrom)
                        .AddCanSpawnExplosion(canSpawn)
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
                .AddSystem(new AbilityStartSystem());

            _lifeContext.Add(entity);

            return entity;
        }
    }
}