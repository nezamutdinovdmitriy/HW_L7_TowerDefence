using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.TakeDamage
{
    public class PeriodicDamageSystem : IInitializableSystem, IUpdatableSystem
    {
        private Entity _self;
        private Dictionary<Entity, float> _entityTimers;

        private float _cooldownTick;
        private float _damageTick;

        private List<Entity> _toReset = new();

        public void OnInitialize(Entity entity)
        {
            _self = entity;

            _entityTimers = entity.ContactsEntityTimers;

            _cooldownTick = entity.CooldownTick.Value;
            _damageTick = entity.DamageTick.Value;
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (KeyValuePair<Entity, float> pair in _entityTimers)
            {
                if (pair.Value >= _cooldownTick)
                {
                    EntitiesHelper.TryTakeDamageFrom(_self, pair.Key, _damageTick);

                    Debug.Log("+++");
                    _toReset.Add(pair.Key);
                }
            }

            for (int i = 0; i < _toReset.Count; i++)
                _entityTimers[_toReset[i]] = 0f;

            _toReset.Clear();
        }
    }
}