using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Fireball
{
    public class FireballView : MonoEntityView
    {
        private ICompositeCondition _mustDie; 
        protected override void OnEntityInitialized(Entity entity)
        {
            _mustDie = entity.MustDie;
        }

        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);
        }

        private void Update()
        {
            
        }
    }
}