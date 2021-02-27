// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/GameInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInputs"",
    ""maps"": [
        {
            ""name"": ""PlayerActions"",
            ""id"": ""7af811f1-501c-4cd4-b24f-0bad43446021"",
            ""actions"": [
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""ea0fd09c-4767-46fa-b25d-e31d2c2759d6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""d9996d20-994a-479a-b236-f25fbcea979d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""850ba5b7-5a92-46af-b3ca-ff793972aa47"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8fa54bcf-b93e-4abd-a380-b2b1df671205"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=0.1,y=0.1)"",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4cb9afef-2e65-4258-a0e3-7dbbbedc3cf1"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""b23dbce3-bcec-46be-88b3-ae53a7226729"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""744ad560-8ec8-4163-8b9e-f3bdd435df5e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""45cea5ac-bb8d-4348-8809-0d66cfcbac88"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9b1ddbb5-0c07-4ed2-8305-a2d95930ef33"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3c7fef28-5d2c-46db-a5a4-cc2c36179884"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""df37dc74-f9e3-40bf-a6e0-3561e43e66f4"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0fb586aa-c932-49e1-8e98-123592f929cd"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7ccb66e7-7df3-4754-b77b-41288fb34cd4"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MenuActions"",
            ""id"": ""8c8bdf50-3b8a-4d0e-9e92-c1176136cace"",
            ""actions"": [
                {
                    ""name"": ""NavLeft"",
                    ""type"": ""Button"",
                    ""id"": ""6ec7ff08-a0ea-475f-a127-02505d72ad9a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NavRight"",
                    ""type"": ""Button"",
                    ""id"": ""5ff8ec89-9938-4c7e-9b3d-039db19652e2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""9e051c05-198d-4041-97af-a039119112de"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""de88d2d5-18c7-472a-8123-a3d5c8836453"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""46e80790-a6e6-45fb-afe2-dfca82dc5b9a"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34b7fe7a-f100-470d-9395-ef0fe07ffdc0"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5d02dbd0-b73b-40a9-a8cc-052cb990b8b6"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""552a1777-9b23-4c3c-9ef2-dbf6cccfcf78"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8cf9d890-f41f-4db1-84f4-aa1d6195cc0b"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e0348e3-b6f8-4073-a149-dfbd7c567aaf"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a14e781b-8a7a-4426-87d3-8e001e731452"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerActions
        m_PlayerActions = asset.FindActionMap("PlayerActions", throwIfNotFound: true);
        m_PlayerActions_Look = m_PlayerActions.FindAction("Look", throwIfNotFound: true);
        m_PlayerActions_Move = m_PlayerActions.FindAction("Move", throwIfNotFound: true);
        m_PlayerActions_Jump = m_PlayerActions.FindAction("Jump", throwIfNotFound: true);
        // MenuActions
        m_MenuActions = asset.FindActionMap("MenuActions", throwIfNotFound: true);
        m_MenuActions_NavLeft = m_MenuActions.FindAction("NavLeft", throwIfNotFound: true);
        m_MenuActions_NavRight = m_MenuActions.FindAction("NavRight", throwIfNotFound: true);
        m_MenuActions_Back = m_MenuActions.FindAction("Back", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // PlayerActions
    private readonly InputActionMap m_PlayerActions;
    private IPlayerActionsActions m_PlayerActionsActionsCallbackInterface;
    private readonly InputAction m_PlayerActions_Look;
    private readonly InputAction m_PlayerActions_Move;
    private readonly InputAction m_PlayerActions_Jump;
    public struct PlayerActionsActions
    {
        private @GameInputs m_Wrapper;
        public PlayerActionsActions(@GameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Look => m_Wrapper.m_PlayerActions_Look;
        public InputAction @Move => m_Wrapper.m_PlayerActions_Move;
        public InputAction @Jump => m_Wrapper.m_PlayerActions_Jump;
        public InputActionMap Get() { return m_Wrapper.m_PlayerActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActionsActions instance)
        {
            if (m_Wrapper.m_PlayerActionsActionsCallbackInterface != null)
            {
                @Look.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLook;
                @Move.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_PlayerActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public PlayerActionsActions @PlayerActions => new PlayerActionsActions(this);

    // MenuActions
    private readonly InputActionMap m_MenuActions;
    private IMenuActionsActions m_MenuActionsActionsCallbackInterface;
    private readonly InputAction m_MenuActions_NavLeft;
    private readonly InputAction m_MenuActions_NavRight;
    private readonly InputAction m_MenuActions_Back;
    public struct MenuActionsActions
    {
        private @GameInputs m_Wrapper;
        public MenuActionsActions(@GameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @NavLeft => m_Wrapper.m_MenuActions_NavLeft;
        public InputAction @NavRight => m_Wrapper.m_MenuActions_NavRight;
        public InputAction @Back => m_Wrapper.m_MenuActions_Back;
        public InputActionMap Get() { return m_Wrapper.m_MenuActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActionsActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActionsActions instance)
        {
            if (m_Wrapper.m_MenuActionsActionsCallbackInterface != null)
            {
                @NavLeft.started -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnNavLeft;
                @NavLeft.performed -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnNavLeft;
                @NavLeft.canceled -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnNavLeft;
                @NavRight.started -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnNavRight;
                @NavRight.performed -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnNavRight;
                @NavRight.canceled -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnNavRight;
                @Back.started -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnBack;
            }
            m_Wrapper.m_MenuActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @NavLeft.started += instance.OnNavLeft;
                @NavLeft.performed += instance.OnNavLeft;
                @NavLeft.canceled += instance.OnNavLeft;
                @NavRight.started += instance.OnNavRight;
                @NavRight.performed += instance.OnNavRight;
                @NavRight.canceled += instance.OnNavRight;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
            }
        }
    }
    public MenuActionsActions @MenuActions => new MenuActionsActions(this);
    public interface IPlayerActionsActions
    {
        void OnLook(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
    public interface IMenuActionsActions
    {
        void OnNavLeft(InputAction.CallbackContext context);
        void OnNavRight(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
    }
}
