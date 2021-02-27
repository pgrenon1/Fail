using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectState : GameMenuState
{
    private LevelSelect _levelSelect;
    public LevelSelect LevelSelect
    {
        get
        {
            if (_levelSelect == null)
                _levelSelect = GameMenuPanel as LevelSelect;

            return _levelSelect;
        }
    }

    public LevelSelectState(LevelSelect levelSelect, GameMenu gameMenu, PushdownStateMachine stateMachine)
        : base(gameMenu, stateMachine)
    {
        GameMenuPanel = levelSelect;
    }

    public override void Enter()
    {
        base.Enter();

        LevelSelect.SetupRepeatable(GameMenu.SelectedChapter);

        LevelSelect.Show(EndEnter);
    }

    public override void Execute()
    {
        base.Execute();
    }

    public override void Exit()
    {
        base.Exit();

        LevelSelect.Hide(EndExit);
    }
}
