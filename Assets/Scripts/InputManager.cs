using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : OdinSerializedSingletonBehaviour<InputManager>
{
    public GameInputs GameInputs { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        GameInputs = new GameInputs();
        GameInputs.Enable();
    }
}
