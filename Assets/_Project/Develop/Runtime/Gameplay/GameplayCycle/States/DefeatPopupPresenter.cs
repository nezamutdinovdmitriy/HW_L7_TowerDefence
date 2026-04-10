using Assets._Project.Develop.Runtime.Gameplay.GameplayCycle.States;
using Assets._Project.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;

public class DefeatPopupPresenter : PopupPresenterBase
{
    private const string TileName = "YOU DEFEAT!";

    private readonly DefeatPopupView _view;
    private readonly SceneSwitcherService _sceneSwitcher;
    private readonly ICoroutinesPerformer _coroutinesPerformer;
    private readonly GameplayInputArgs _args;

    public DefeatPopupPresenter(
        DefeatPopupView view,
        SceneSwitcherService sceneSwitcher,
        ICoroutinesPerformer coroutinesPerformer,
        GameplayInputArgs args)
        : base (coroutinesPerformer)
    {
        _view = view;
        _sceneSwitcher = sceneSwitcher;
        _coroutinesPerformer = coroutinesPerformer;
        _args = args;
    }

    protected override PopupViewBase PopupView => _view;

    public override void Initialize()
    {
        base.Initialize();

        _view.SetTile(TileName);

        _view.ExitClicked += OnExitClicked;
        _view.RestartClicked += OnRestartClicked;
    }

    public override void Dispose()
    {
        base.Dispose();

        _view.ExitClicked -= OnExitClicked;
        _view.RestartClicked -= OnRestartClicked;
    }

    private void OnRestartClicked()
    {
        _coroutinesPerformer.StartPerform(
            _sceneSwitcher.ProcessSwitchTo(
                Scenes.Gameplay, 
                new GameplayInputArgs(_args.LevelNumber)));
        
        OnCloseRequest();
    }

    private void OnExitClicked()
    {
        _coroutinesPerformer.StartPerform(
            _sceneSwitcher.ProcessSwitchTo(Scenes.MainMenu));
        
        OnCloseRequest();
    }
}
