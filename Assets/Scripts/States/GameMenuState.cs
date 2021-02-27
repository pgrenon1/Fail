using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuState : State
{
    public GameMenu GameMenu { get; private set; }
    public GameMenuPanel GameMenuPanel { get; set; }

    public GameMenuState(GameMenu gameMenu, PushdownStateMachine stateMachine) 
        : base(stateMachine)
    {
        GameMenu = gameMenu;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void EndEnter()
    {
        base.EndEnter();

        GameMenuPanel.WaitAndSetupNavigation();
    }
}
