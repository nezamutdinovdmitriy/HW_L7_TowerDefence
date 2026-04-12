using Assets._Project.Develop.Runtime.Meta.Features.WalletFeature;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities.Casts
{
    public class AbilityCastConfig : ScriptableObject
    {
        [field: SerializeField] public float InitialTime { get; private set; }
        [field: SerializeField] public float SpawnEffectDelay { get; private set; }
    }
}