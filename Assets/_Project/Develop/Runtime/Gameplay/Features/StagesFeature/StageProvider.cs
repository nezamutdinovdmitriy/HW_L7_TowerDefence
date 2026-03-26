using Assets._Project.Develop.Runtime.Gameplay.Configs.Levels;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.StagesFeature
{
    public class StageProvider : IDisposable
    {
        private readonly ReactiveVariable<int> _currentStageNumber = new();
        private readonly ReactiveVariable<StageResult> _currentStageResult = new();

        private IStage _currentStage;

        private IDisposable _stageEndedDisposable;

        private readonly LevelConfig _levelConfig;

        private readonly StagesFactory _stagesFactory;

        public StageProvider(LevelConfig levelConfig, StagesFactory stagesFactory)
        {
            _levelConfig = levelConfig;
            _stagesFactory = stagesFactory;
        }

        public IReadOnlyVariable<int> CurrentStageNumber => _currentStageNumber;
        public IReadOnlyVariable<StageResult> CurrentStageResult => _currentStageResult;
        public int StageCount => _levelConfig.StageConfigs.Count;

        public void SwitchToNextStage()
        {
            if (HasNextStage() == false)
                throw new InvalidOperationException("Next stage is missing!");

            if (_currentStage != null)
                CleanupCurrent();

            _currentStageNumber.Value++;
            _currentStageResult.Value = StageResult.Uncompleted;

            _currentStage = CreateStageBy(_currentStageNumber.Value);
        }

        public bool HasNextStage() => _currentStageNumber.Value < StageCount;

        public void StartCurrent()
        {
            _stageEndedDisposable = _currentStage.Completed.Subscribe(OnStageCompleted);
            _currentStage.Start();
        }

        public void UpdateCurrent(float deltaTime) => _currentStage.Update(deltaTime);
        
        public void CleanupCurrent() => _currentStage.Cleanup();
        
        public void Dispose()
        {
            _stageEndedDisposable?.Dispose();
            _currentStage?.Dispose();
        }

        private IStage CreateStageBy(int stageNumber)
        {
            int stageIndex = stageNumber - 1;

            return _stagesFactory.Create(_levelConfig.StageConfigs[stageIndex]);
        }

        private void OnStageCompleted() => _currentStageResult.Value = StageResult.Completed;
    }
}