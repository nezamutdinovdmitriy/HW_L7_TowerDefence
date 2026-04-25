using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityEffects.ToxicPuddle
{
    public class ToxicPuddleView : MonoEntityView
    {
        [SerializeField] private List<ParticleSystem> _particles;

        protected override void OnEntityInitialized(Entity entity)
        {
            float radius = entity.ToxicPuddleRadius.Value;
            float baseRadius = 1f;
            float scale = radius / baseRadius;

            foreach (var particle in _particles)
            {
                var shape = particle.shape;
                shape.radius *= scale;

                var main = particle.main;
                main.startSizeMultiplier *= scale;
            }
        }
    }
}