using System.Collections.Generic;

public class PushdownStateMachine
{
    public State CurrentState
    {
        get
        {
            if (StateStack.Count > 0)
                return StateStack.Peek();
            else
                return null;
        }
    }

    public Stack<State> StateStack { get; private set; } = new Stack<State>();

    public bool DebugTransition { get; set; }

    public void ChangeState(State newState)
    {
        if (CurrentState != null)
        {
            CurrentState.Exit();
        }

        StateStack.Push(newState);
        CurrentState.Enter();
    }

    public void Update()
    {
        if (CurrentState != null)
            CurrentState.Execute();
    }

    public void ChangeStateBack()
    {
        if (CurrentState != null && StateStack.Count > 1)
        {
            var stateToExit = StateStack.Pop();
            stateToExit.Exit();
            
            CurrentState.Enter();
        }
    }
}
