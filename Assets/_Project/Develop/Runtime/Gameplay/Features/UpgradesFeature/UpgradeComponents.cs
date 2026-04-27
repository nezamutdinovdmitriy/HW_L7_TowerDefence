using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.UpgradesFeature
{
    public class Upgrades : IEntityComponent
    {
        public List<Entity> Value;
    }

    public class TowerHealOnWaveStartUpgradeTag : IEntityComponent
    {
    }

    public class DamageFirstEnemiesUpgradeTag : IEntityComponent
    {
    }

    public class FireballDamageMultiplierUpgradeTag : IEntityComponent
    {
    }
}