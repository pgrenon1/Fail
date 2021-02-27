using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsState : GameMenuState
{
    private OptionsMenu _optionsMenu;
    public OptionsMenu OptionsMenu
    {
        get
        {
            if (_optionsMenu == null)
                _optionsMenu = GameMenuPanel as OptionsMenu;

            return _optionsMenu;
        }
    }

    public OptionsState(OptionsMenu optionsMenu, GameMenu gameMenu, PushdownStateMachine stateMachine)
        : base(gameMenu, stateMachine)
    {
        GameMenuPanel = optionsMenu;
    }

    public override void Enter()
    {
        base.Enter();

        OptionsMenu.Show(EndEnter);
    }

    public override void Execute()
    {
        base.Execute();
    }

    public override void Exit()
    {
        base.Exit();

        OptionsMenu.Hide(EndExit);
    }
}
