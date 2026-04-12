using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.StagesFeature
{
    public class StagePresenter : IPresenter
    {
        private readonly IconTextView _view;
        private readonly StageProvider _stageProvider;

        private IDisposable _disposable;

        public StagePresenter(IconTextView view, StageProvider stageProvider)
        {
            _view = view;
            _stageProvider = stageProvider;
        }

        public void Initialize()
        {
            _disposable = _stageProvider.CurrentStageNumber.Subscribe(OnNextStageIndexChanged);

            UpdateStage();
        }

        public void Dispose() => _disposable.Dispose();

        private void UpdateStage()
        {
            _view.SetText($"{_stageProvider.CurrentStageNumber.Value}/{_stageProvider.StageCount}");
        }

        private void OnNextStageIndexChanged(int arg1, int arg2) => UpdateStage();
    }
}