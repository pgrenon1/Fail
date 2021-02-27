public class SplashScreenState : GameMenuState
{
    private SplashScreen _splashScreen;
    public SplashScreen SplashScreen
    {
        get
        {
            if (_splashScreen == null)
                _splashScreen = GameMenuPanel as SplashScreen;

            return _splashScreen;
        }
    }

    public SplashScreenState(SplashScreen splashScreenPanel, GameMenu gameMenu, PushdownStateMachine stateMachine)
    : base(gameMenu, stateMachine)
    {
        GameMenuPanel = splashScreenPanel;
    }

    public override void Enter()
    {
        base.Enter();

        SplashScreen.Show(EndEnter);
    }

    public override void Execute()
    {
        base.Execute();
    }

    public override void Exit()
    {
        base.Exit();

        SplashScreen.Hide(EndExit);
    }
}
