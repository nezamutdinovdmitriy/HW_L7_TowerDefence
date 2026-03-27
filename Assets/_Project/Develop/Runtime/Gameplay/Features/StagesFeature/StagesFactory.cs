using Assets._Project.Develop.Runtime.Gameplay.Configs.Stages;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.EnemiesFeature;
using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.StagesFeature
{
    public sealed class StagesFactory
    {
        private readonly DIContainer _container;

        public StagesFactory(DIContainer container) => _container = container;

        public IStage Create(StageConfig config)
        {
            switch (config)
            {
                case ClearEnemyWaveStageConfig clearEnemyWaveStageConfig:
                    return new ClearEnemyWaveStage(
                        clearEnemyWaveStageConfig,
                        _container.Resolve<EnemiesEntityFactory>(),
                        _container.Resolve<EntitiesLifeContext>());

                default:
                    throw new ArgumentException($"Not support {config.GetType()} type config!");
            }
        }
    }
}