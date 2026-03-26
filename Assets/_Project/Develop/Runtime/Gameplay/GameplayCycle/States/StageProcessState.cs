using Assets._Project.Develop.Runtime.Gameplay.Features.StagesFeature;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using UnityEngine;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.GameplayCycle.States
{
    public class StageProcessState : State, IUpdatableState
    {
        private readonly StageProvider _stageProvider;

        public StageProcessState(StageProvider stageProvider) 
            => _stageProvider = stageProvider;

        public override void Enter()
        {
            base.Enter();

            Debug.Log("");

            Debug.Log($"{_stageProvider.CurrentStageNumber.Value}\n{_stageProvider.CurrentStageResult.Value}" );

            _stageProvider.SwitchToNextStage();
            _stageProvider.StartCurrent();
        }

        public void Update(float deltaTime) 
            => _stageProvider.UpdateCurrent(deltaTime);

        public override void Exit()
        {
            base.Exit();

            _stageProvider.CleanupCurrent();
        }
    }
}