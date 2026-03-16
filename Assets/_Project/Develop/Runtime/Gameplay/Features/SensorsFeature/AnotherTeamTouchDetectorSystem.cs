using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature;
using Assets._Project.Develop.Runtime.Utilities.Pooling;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature
{
    public class AnotherTeamTouchDetectorSystem : IInitializableSystem, IUpdatableSystem
    {
        private Buffer<Entity> _contactsEntities;
        private ReactiveVariable<bool> _isTouchAnotherTeam;
        private ReactiveVariable<TeamType> _sourceTeam;

        public void OnInitialize(Entity entity)
        {
            _contactsEntities = entity.ContactsEntitiesBuffer;
            _isTouchAnotherTeam = entity.IsTouchAnotherTeam;
            _sourceTeam = entity.Team;
        }

        public void OnUpdate(float deltaTime)
        {
            for (int i = 0; i < _contactsEntities.Count; i++)
            {
                Entity contactEntity = _contactsEntities.Items[i];

                if(contactEntity.TryGetTeam(out ReactiveVariable<TeamType> anotherTeam))
                {
                    if(anotherTeam.Value != _sourceTeam.Value)
                    {
                        _isTouchAnotherTeam.Value = true;
                        return;
                    }
                }

                _isTouchAnotherTeam.Value = false;
            }
        }
    }
}