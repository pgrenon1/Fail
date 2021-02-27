using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuState : GameMenuState
{
    private MainMenu _mainMenu;
    public MainMenu MainMenu
    {
        get
        {
            if (_mainMenu == null)
                _mainMenu = GameMenuPanel as MainMenu;

            return _mainMenu;
        }
    }

    public MainMenuState(MainMenu mainMenu, GameMenu gameMenu, PushdownStateMachine stateMachine)
    : base(gameMenu, stateMachine)
    {
        GameMenuPanel = mainMenu;
    }

    public override void Enter()
    {
        base.Enter();

        MainMenu.Show(EndEnter);
    }

    public override void Execute()
    {
        base.Execute();
    }

    public override void Exit()
    {
        base.Exit();

        MainMenu.Hide(EndExit);
    }
}
