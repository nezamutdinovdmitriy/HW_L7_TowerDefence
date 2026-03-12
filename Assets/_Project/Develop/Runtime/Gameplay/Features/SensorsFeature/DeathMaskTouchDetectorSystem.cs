using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Pooling;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature
{
    public class DeathMaskTouchDetectorSystem : IInitializableSystem, IUpdatableSystem
    {
        private Buffer<Collider> _contactsColliders;
        private ReactiveVariable<bool> _isTouchDeathMask;

        private LayerMask _deathMask;

        public void OnInitialize(Entity entity)
        {
            _contactsColliders = entity.ContactsCollidersBuffer;
            _isTouchDeathMask = entity.IsTouchDeathMask;

            _deathMask = entity.DeathMask;
        }

        public void OnUpdate(float deltaTime)
        {
            for (int i = 0; i < _contactsColliders.Count; i++)
            {
                if (MatchWithDeathLayer(_contactsColliders.Items[i]))
                {
                    _isTouchDeathMask.Value = true;
                    return;
                }
            }

            _isTouchDeathMask.Value = false;
        }

        private bool MatchWithDeathLayer(Collider collider)
        {
            return ((1 << collider.gameObject.layer) & _deathMask) != 0;
        }
    }
}