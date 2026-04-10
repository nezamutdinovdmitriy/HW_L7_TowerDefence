using Assets._Project.Develop.Runtime.Gameplay.GameplayCycle.States;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;

public class WinPopupPresenter : PopupPresenterBase
{
    private const string TileName = "YOU WIN!";

    private readonly WinPopupView _view;
    private readonly SceneSwitcherService _sceneSwitcher;
    private readonly ICoroutinesPerformer _coroutinesPerformer;

    public WinPopupPresenter(
            WinPopupView view,
            SceneSwitcherService sceneSwitcherService,
            ICoroutinesPerformer coroutinesPerformer)
            : base(coroutinesPerformer)
    {
        _view = view;
        _sceneSwitcher = sceneSwitcherService;
        _coroutinesPerformer = coroutinesPerformer;
    }

    protected override PopupViewBase PopupView => _view;

    public override void Initialize()
    {
        base.Initialize();

        _view.SetTile(TileName);
        _view.ContinueClicked += OnContinueClicked;
    }

    public override void Dispose() => _view.ContinueClicked -= OnContinueClicked;

    private void OnContinueClicked()
    {
        _coroutinesPerformer.StartPerform(_sceneSwitcher.ProcessSwitchTo(Scenes.MainMenu));
        OnCloseRequest();
    }
}
