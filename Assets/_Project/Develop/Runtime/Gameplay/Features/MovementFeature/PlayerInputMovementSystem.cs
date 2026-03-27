using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

public sealed class PlayerInputMovementSystem : IInitializableSystem, IUpdatableSystem
{
    private ReactiveVariable<Vector3> _inputMovementDirection;
    private IGameplayInputService _input;

    public PlayerInputMovementSystem(IGameplayInputService input) => _input = input;

    public void OnInitialize(Entity entity) => _inputMovementDirection = entity.InputMovementDirection;

    public void OnUpdate(float deltaTime) => _inputMovementDirection.Value = _input.MovementDirection;
}
