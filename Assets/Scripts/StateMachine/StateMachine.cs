public class StateMachine
{
    public State CurrentState { get; private set; }

    public bool Debug { get; set; }

    public void ChangeState(State newState)
    {
        if (CurrentState != null)
            CurrentState.Exit();

        CurrentState = newState;
        CurrentState.Enter();
    }

    public void Update()
    {
        if (CurrentState != null)
            CurrentState.Execute();
    }
}