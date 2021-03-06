﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public PushdownStateMachine StateMachine { get; private set; }

    public State(PushdownStateMachine stateMachine)
    {
        StateMachine = stateMachine;
    }

    public delegate void OnBeginEnterState();
    public event OnBeginEnterState OnBeginEnter;

    public delegate void OnFinishEnterState();
    public event OnFinishEnterState OnFinishEnter;

    public delegate void OnBeginExitState();
    public event OnBeginExitState OnBeginExit;

    public delegate void OnFinishExitState();
    public event OnFinishExitState OnFinishExit;

    public bool IsInTransition { get; private set; }

    public virtual void Enter()
    {
        if (OnBeginEnter != null)
            OnBeginEnter();

        IsInTransition = true;
        if (StateMachine.DebugTransition) Debug.Log("Enter(Begin): " + this);
    }

    public virtual void EndEnter()
    {
        if (OnFinishEnter != null)
            OnFinishEnter();

        IsInTransition = false;
        if (StateMachine.DebugTransition) Debug.Log("Enter(End): " + this);
    }

    public virtual void Execute()
    {

    }

    public virtual void Exit()
    {
        if (OnBeginExit != null)
            OnBeginExit();

        IsInTransition = true;
        if (StateMachine.DebugTransition) Debug.Log("Exit(Begin): " + this);
    }

    public virtual void EndExit()
    {
        if (OnFinishExit != null)
            OnFinishExit();

        IsInTransition = false;
        if (StateMachine.DebugTransition) Debug.Log("Exit(End): " + this);
    }
}