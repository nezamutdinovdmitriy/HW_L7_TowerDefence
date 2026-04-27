using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Meta.Features.UpgradesFeature;
using Assets._Project.Develop.Runtime.ProjectInfrastructure.DI;
using UnityEngine;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.UpgradesFeature
{
    public class UpgradesFactory
    {
        private readonly DIContainer _container;
        private readonly EntitiesLifeContext _lifeContext;

        public UpgradesFactory(
            DIContainer container,
            EntitiesLifeContext lifeContext)
        {
            _container = container;
            _lifeContext = lifeContext;
        }

        public Entity Create(Entity owner, UpgradeType upgradeType)
        {
            Entity upgrade;

            switch (upgradeType)
            {
                case UpgradeType.TowerHealOnWaveStart:
                    upgrade = CreateCommon(owner);

                    upgrade
                        .AddTowerHealOnWaveStartUpgradeTag();
                    Debug.Log("Создал хил башни");

                    break;

                case UpgradeType.DamageFirstEnemies:
                    upgrade = CreateCommon(owner);

                    upgrade
                        .AddTowerHealOnWaveStartUpgradeTag();
                    Debug.Log("Создал нанесение урона врагам");

                    break;

                case UpgradeType.FireballDamageMultiplier:
                    upgrade = CreateCommon(owner);

                    upgrade
                        .AddTowerHealOnWaveStartUpgradeTag();
                    Debug.Log("Создал увеличенный урон файрболом");

                    break;

                default:
                    throw new InvalidOperationException();
            }

            _lifeContext.Add(upgrade);

            return upgrade;
        }

        private Entity CreateCommon(Entity owner)
        {
            Entity upgrade = new();
            upgrade.Hierarchy.Value.SetParent(owner);
            return upgrade;
        }
    }
}