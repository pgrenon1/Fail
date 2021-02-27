using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterSelectState : GameMenuState
{
    private ChapterSelect _chapterSelect;
    public ChapterSelect ChapterSelect
    {
        get
        {
            if (_chapterSelect == null)
                _chapterSelect = GameMenuPanel as ChapterSelect;

            return _chapterSelect;
        }
    }

    public ChapterSelectState(ChapterSelect chapterSelect, GameMenu gameMenu, PushdownStateMachine stateMachine)
        : base(gameMenu, stateMachine)
    {
        GameMenuPanel = chapterSelect;
    }

    public override void Enter()
    {
        base.Enter();

        ChapterSelect.Show(EndEnter);
    }

    public override void Execute()
    {
        base.Execute();
    }

    public override void Exit()
    {
        base.Exit();

        ChapterSelect.Hide(EndExit);
    }
}
