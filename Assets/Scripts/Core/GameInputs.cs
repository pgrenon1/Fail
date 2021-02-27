// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Core/GameInputs.inputactions'

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
            ""name"": ""RopeActions"",
            ""id"": ""2e07e3a0-bce7-473c-bb0f-eecf452e8e68"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""927f11a3-6a4f-40da-a0af-0f207eaf7757"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7442c539-cd36-4ff6-9ab9-6a4cff97948a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Unlock1"",
                    ""type"": ""Button"",
                    ""id"": ""bf1c950c-2273-4334-8d9a-2aa0d7d9e7f2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Unlock2"",
                    ""type"": ""Button"",
                    ""id"": ""c1ab2084-2e53-4d7d-8bc0-700fd4bec819"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TenseUp"",
                    ""type"": ""Button"",
                    ""id"": ""245a9f96-9e10-42a0-9a72-7797341868eb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Lift"",
                    ""type"": ""Button"",
                    ""id"": ""36454389-46ae-4326-8f34-637eeef922a5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""dd7f2eb3-e6c2-4553-aae1-80c0514999ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4444f1de-e845-4680-a5de-503050a3ec2d"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""ASDW"",
                    ""id"": ""1d4a3635-e4ac-4010-8bc9-bb14293d843b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""478442f1-dd68-4df0-95be-9cc3abee5fdf"",
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
                    ""id"": ""bdb7208a-bbba-40dc-8ad2-2a18f1c49c3c"",
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
                    ""id"": ""6de80eb4-eedb-40b3-a99a-b0cac99f7185"",
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
                    ""id"": ""476d7c53-60f6-4330-971f-9fb5ae14b4e4"",
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
                    ""id"": ""3b7d04ba-4564-408b-874c-d44a5a7c705b"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""277bb0d9-a54c-457c-a9f4-63ef290e6b80"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Unlock1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fa5bb78b-5bda-4e91-8477-cf068160e4ed"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Unlock1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f0ea942-a04b-4a8c-9299-456fac07b9ee"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Unlock2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""92f51c56-1801-454b-99bc-6f17b9431144"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Unlock2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""918dc33d-6e84-45fd-af9f-22b764afa084"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TenseUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d3a04e52-bdbf-41e3-9e02-23189dd22463"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TenseUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19b98ef2-d71a-4470-9cfa-96393f844472"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Lift"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c88d08f0-cb87-41e3-b6ec-c540bce3c7c8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Lift"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fffaa2a4-cb1f-448a-b05f-e3d0040c9064"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""27cf71f4-7d46-4dc7-a286-ed39ea1a1d7c"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""CheatActions"",
            ""id"": ""e702d614-0f74-4d2b-a872-d69e06ca0c3c"",
            ""actions"": [
                {
                    ""name"": ""IncreaseTimeScale"",
                    ""type"": ""Button"",
                    ""id"": ""b2e588ea-bca2-4c45-afa0-9a64c22f05a3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DecreaseTimeScale"",
                    ""type"": ""Button"",
                    ""id"": ""25ba9bf8-4f43-46c7-8cfc-2a60c1883a92"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SkipLevel"",
                    ""type"": ""Button"",
                    ""id"": ""e6100330-0498-4d1a-8d4e-63bab6709da0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CycleCamera"",
                    ""type"": ""Button"",
                    ""id"": ""6a561115-0ba1-425d-bebe-4e86f507efe0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""cb2fe58f-79cb-4eed-9a3e-ee896b93be9c"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SkipLevel"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""7799754d-f8d3-4754-908d-684f299ab561"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SkipLevel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""649164d3-899b-423a-8111-3851152ec91b"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SkipLevel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""45f70cea-a629-4851-aa16-ed8cb479e09f"",
                    ""path"": ""<DualShockGamepad>/touchpadButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CycleCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3e51078a-9c8e-48d6-85ce-776179843bc5"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CycleCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""GameActions"",
            ""id"": ""fc9d1832-d742-4a64-bfe0-81d198a9a5de"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""b861e0c2-7927-451a-b19a-0ce6942947f5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ffed0f0b-6277-4cf0-9a86-fea1abb0a319"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ba307a74-2926-41fb-b797-0d87a011a5d9"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MenuActions"",
            ""id"": ""1100b2da-73b2-447f-a420-3e5fadebb2a1"",
            ""actions"": [
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""518fbd90-4ae1-47fb-b3c8-7dc508e1edb2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""ce6708af-141a-4404-838a-5021780ece85"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NavLeft"",
                    ""type"": ""Button"",
                    ""id"": ""b13ed721-cc9f-4618-858c-93a0f09570ad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NavRight"",
                    ""type"": ""Button"",
                    ""id"": ""270b88dc-f0b4-47ec-a5e2-6bd21c5df5e1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ef11a1c3-7700-4a8f-936d-691b4a94a770"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""def526d8-8e81-48d4-a7aa-20741df846a6"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""21a6c8ab-681d-4b85-bc96-d19d8ced7169"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""983ca7e2-8508-429a-b085-dbda6e01b2d7"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // RopeActions
        m_RopeActions = asset.FindActionMap("RopeActions", throwIfNotFound: true);
        m_RopeActions_Move = m_RopeActions.FindAction("Move", throwIfNotFound: true);
        m_RopeActions_Look = m_RopeActions.FindAction("Look", throwIfNotFound: true);
        m_RopeActions_Unlock1 = m_RopeActions.FindAction("Unlock1", throwIfNotFound: true);
        m_RopeActions_Unlock2 = m_RopeActions.FindAction("Unlock2", throwIfNotFound: true);
        m_RopeActions_TenseUp = m_RopeActions.FindAction("TenseUp", throwIfNotFound: true);
        m_RopeActions_Lift = m_RopeActions.FindAction("Lift", throwIfNotFound: true);
        m_RopeActions_Pause = m_RopeActions.FindAction("Pause", throwIfNotFound: true);
        // CheatActions
        m_CheatActions = asset.FindActionMap("CheatActions", throwIfNotFound: true);
        m_CheatActions_IncreaseTimeScale = m_CheatActions.FindAction("IncreaseTimeScale", throwIfNotFound: true);
        m_CheatActions_DecreaseTimeScale = m_CheatActions.FindAction("DecreaseTimeScale", throwIfNotFound: true);
        m_CheatActions_SkipLevel = m_CheatActions.FindAction("SkipLevel", throwIfNotFound: true);
        m_CheatActions_CycleCamera = m_CheatActions.FindAction("CycleCamera", throwIfNotFound: true);
        // GameActions
        m_GameActions = asset.FindActionMap("GameActions", throwIfNotFound: true);
        m_GameActions_Pause = m_GameActions.FindAction("Pause", throwIfNotFound: true);
        // MenuActions
        m_MenuActions = asset.FindActionMap("MenuActions", throwIfNotFound: true);
        m_MenuActions_Submit = m_MenuActions.FindAction("Submit", throwIfNotFound: true);
        m_MenuActions_Back = m_MenuActions.FindAction("Back", throwIfNotFound: true);
        m_MenuActions_NavLeft = m_MenuActions.FindAction("NavLeft", throwIfNotFound: true);
        m_MenuActions_NavRight = m_MenuActions.FindAction("NavRight", throwIfNotFound: true);
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

    // RopeActions
    private readonly InputActionMap m_RopeActions;
    private IRopeActionsActions m_RopeActionsActionsCallbackInterface;
    private readonly InputAction m_RopeActions_Move;
    private readonly InputAction m_RopeActions_Look;
    private readonly InputAction m_RopeActions_Unlock1;
    private readonly InputAction m_RopeActions_Unlock2;
    private readonly InputAction m_RopeActions_TenseUp;
    private readonly InputAction m_RopeActions_Lift;
    private readonly InputAction m_RopeActions_Pause;
    public struct RopeActionsActions
    {
        private @GameInputs m_Wrapper;
        public RopeActionsActions(@GameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_RopeActions_Move;
        public InputAction @Look => m_Wrapper.m_RopeActions_Look;
        public InputAction @Unlock1 => m_Wrapper.m_RopeActions_Unlock1;
        public InputAction @Unlock2 => m_Wrapper.m_RopeActions_Unlock2;
        public InputAction @TenseUp => m_Wrapper.m_RopeActions_TenseUp;
        public InputAction @Lift => m_Wrapper.m_RopeActions_Lift;
        public InputAction @Pause => m_Wrapper.m_RopeActions_Pause;
        public InputActionMap Get() { return m_Wrapper.m_RopeActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RopeActionsActions set) { return set.Get(); }
        public void SetCallbacks(IRopeActionsActions instance)
        {
            if (m_Wrapper.m_RopeActionsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_RopeActionsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_RopeActionsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_RopeActionsActionsCallbackInterface.OnMove;
                @Look.started -= m_Wrapper.m_RopeActionsActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_RopeActionsActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_RopeActionsActionsCallbackInterface.OnLook;
                @Unlock1.started -= m_Wrapper.m_RopeActionsActionsCallbackInterface.OnUnlock1;
                @Unlock1.performed -= m_Wrapper.m_RopeActionsActionsCallbackInterface.OnUnlock1;
                @Unlock1.canceled -= m_Wrapper.m_RopeActionsActionsCallbackInterface.OnUnlock1;
                @Unlock2.started -= m_Wrapper.m_RopeActionsActionsCallbackInterface.OnUnlock2;
                @Unlock2.performed -= m_Wrapper.m_RopeActionsActionsCallbackInterface.OnUnlock2;
                @Unlock2.canceled -= m_Wrapper.m_RopeActionsActionsCallbackInterface.OnUnlock2;
                @TenseUp.started -= m_Wrapper.m_RopeActionsActionsCallbackInterface.OnTenseUp;
                @TenseUp.performed -= m_Wrapper.m_RopeActionsActionsCallbackInterface.OnTenseUp;
                @TenseUp.canceled -= m_Wrapper.m_RopeActionsActionsCallbackInterface.OnTenseUp;
                @Lift.started -= m_Wrapper.m_RopeActionsActionsCallbackInterface.OnLift;
                @Lift.performed -= m_Wrapper.m_RopeActionsActionsCallbackInterface.OnLift;
                @Lift.canceled -= m_Wrapper.m_RopeActionsActionsCallbackInterface.OnLift;
                @Pause.started -= m_Wrapper.m_RopeActionsActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_RopeActionsActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_RopeActionsActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_RopeActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Unlock1.started += instance.OnUnlock1;
                @Unlock1.performed += instance.OnUnlock1;
                @Unlock1.canceled += instance.OnUnlock1;
                @Unlock2.started += instance.OnUnlock2;
                @Unlock2.performed += instance.OnUnlock2;
                @Unlock2.canceled += instance.OnUnlock2;
                @TenseUp.started += instance.OnTenseUp;
                @TenseUp.performed += instance.OnTenseUp;
                @TenseUp.canceled += instance.OnTenseUp;
                @Lift.started += instance.OnLift;
                @Lift.performed += instance.OnLift;
                @Lift.canceled += instance.OnLift;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public RopeActionsActions @RopeActions => new RopeActionsActions(this);

    // CheatActions
    private readonly InputActionMap m_CheatActions;
    private ICheatActionsActions m_CheatActionsActionsCallbackInterface;
    private readonly InputAction m_CheatActions_IncreaseTimeScale;
    private readonly InputAction m_CheatActions_DecreaseTimeScale;
    private readonly InputAction m_CheatActions_SkipLevel;
    private readonly InputAction m_CheatActions_CycleCamera;
    public struct CheatActionsActions
    {
        private @GameInputs m_Wrapper;
        public CheatActionsActions(@GameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @IncreaseTimeScale => m_Wrapper.m_CheatActions_IncreaseTimeScale;
        public InputAction @DecreaseTimeScale => m_Wrapper.m_CheatActions_DecreaseTimeScale;
        public InputAction @SkipLevel => m_Wrapper.m_CheatActions_SkipLevel;
        public InputAction @CycleCamera => m_Wrapper.m_CheatActions_CycleCamera;
        public InputActionMap Get() { return m_Wrapper.m_CheatActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CheatActionsActions set) { return set.Get(); }
        public void SetCallbacks(ICheatActionsActions instance)
        {
            if (m_Wrapper.m_CheatActionsActionsCallbackInterface != null)
            {
                @IncreaseTimeScale.started -= m_Wrapper.m_CheatActionsActionsCallbackInterface.OnIncreaseTimeScale;
                @IncreaseTimeScale.performed -= m_Wrapper.m_CheatActionsActionsCallbackInterface.OnIncreaseTimeScale;
                @IncreaseTimeScale.canceled -= m_Wrapper.m_CheatActionsActionsCallbackInterface.OnIncreaseTimeScale;
                @DecreaseTimeScale.started -= m_Wrapper.m_CheatActionsActionsCallbackInterface.OnDecreaseTimeScale;
                @DecreaseTimeScale.performed -= m_Wrapper.m_CheatActionsActionsCallbackInterface.OnDecreaseTimeScale;
                @DecreaseTimeScale.canceled -= m_Wrapper.m_CheatActionsActionsCallbackInterface.OnDecreaseTimeScale;
                @SkipLevel.started -= m_Wrapper.m_CheatActionsActionsCallbackInterface.OnSkipLevel;
                @SkipLevel.performed -= m_Wrapper.m_CheatActionsActionsCallbackInterface.OnSkipLevel;
                @SkipLevel.canceled -= m_Wrapper.m_CheatActionsActionsCallbackInterface.OnSkipLevel;
                @CycleCamera.started -= m_Wrapper.m_CheatActionsActionsCallbackInterface.OnCycleCamera;
                @CycleCamera.performed -= m_Wrapper.m_CheatActionsActionsCallbackInterface.OnCycleCamera;
                @CycleCamera.canceled -= m_Wrapper.m_CheatActionsActionsCallbackInterface.OnCycleCamera;
            }
            m_Wrapper.m_CheatActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @IncreaseTimeScale.started += instance.OnIncreaseTimeScale;
                @IncreaseTimeScale.performed += instance.OnIncreaseTimeScale;
                @IncreaseTimeScale.canceled += instance.OnIncreaseTimeScale;
                @DecreaseTimeScale.started += instance.OnDecreaseTimeScale;
                @DecreaseTimeScale.performed += instance.OnDecreaseTimeScale;
                @DecreaseTimeScale.canceled += instance.OnDecreaseTimeScale;
                @SkipLevel.started += instance.OnSkipLevel;
                @SkipLevel.performed += instance.OnSkipLevel;
                @SkipLevel.canceled += instance.OnSkipLevel;
                @CycleCamera.started += instance.OnCycleCamera;
                @CycleCamera.performed += instance.OnCycleCamera;
                @CycleCamera.canceled += instance.OnCycleCamera;
            }
        }
    }
    public CheatActionsActions @CheatActions => new CheatActionsActions(this);

    // GameActions
    private readonly InputActionMap m_GameActions;
    private IGameActionsActions m_GameActionsActionsCallbackInterface;
    private readonly InputAction m_GameActions_Pause;
    public struct GameActionsActions
    {
        private @GameInputs m_Wrapper;
        public GameActionsActions(@GameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_GameActions_Pause;
        public InputActionMap Get() { return m_Wrapper.m_GameActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActionsActions set) { return set.Get(); }
        public void SetCallbacks(IGameActionsActions instance)
        {
            if (m_Wrapper.m_GameActionsActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_GameActionsActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GameActionsActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GameActionsActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_GameActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public GameActionsActions @GameActions => new GameActionsActions(this);

    // MenuActions
    private readonly InputActionMap m_MenuActions;
    private IMenuActionsActions m_MenuActionsActionsCallbackInterface;
    private readonly InputAction m_MenuActions_Submit;
    private readonly InputAction m_MenuActions_Back;
    private readonly InputAction m_MenuActions_NavLeft;
    private readonly InputAction m_MenuActions_NavRight;
    public struct MenuActionsActions
    {
        private @GameInputs m_Wrapper;
        public MenuActionsActions(@GameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Submit => m_Wrapper.m_MenuActions_Submit;
        public InputAction @Back => m_Wrapper.m_MenuActions_Back;
        public InputAction @NavLeft => m_Wrapper.m_MenuActions_NavLeft;
        public InputAction @NavRight => m_Wrapper.m_MenuActions_NavRight;
        public InputActionMap Get() { return m_Wrapper.m_MenuActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActionsActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActionsActions instance)
        {
            if (m_Wrapper.m_MenuActionsActionsCallbackInterface != null)
            {
                @Submit.started -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnSubmit;
                @Back.started -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnBack;
                @NavLeft.started -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnNavLeft;
                @NavLeft.performed -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnNavLeft;
                @NavLeft.canceled -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnNavLeft;
                @NavRight.started -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnNavRight;
                @NavRight.performed -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnNavRight;
                @NavRight.canceled -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnNavRight;
            }
            m_Wrapper.m_MenuActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @NavLeft.started += instance.OnNavLeft;
                @NavLeft.performed += instance.OnNavLeft;
                @NavLeft.canceled += instance.OnNavLeft;
                @NavRight.started += instance.OnNavRight;
                @NavRight.performed += instance.OnNavRight;
                @NavRight.canceled += instance.OnNavRight;
            }
        }
    }
    public MenuActionsActions @MenuActions => new MenuActionsActions(this);
    public interface IRopeActionsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnUnlock1(InputAction.CallbackContext context);
        void OnUnlock2(InputAction.CallbackContext context);
        void OnTenseUp(InputAction.CallbackContext context);
        void OnLift(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface ICheatActionsActions
    {
        void OnIncreaseTimeScale(InputAction.CallbackContext context);
        void OnDecreaseTimeScale(InputAction.CallbackContext context);
        void OnSkipLevel(InputAction.CallbackContext context);
        void OnCycleCamera(InputAction.CallbackContext context);
    }
    public interface IGameActionsActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IMenuActionsActions
    {
        void OnSubmit(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnNavLeft(InputAction.CallbackContext context);
        void OnNavRight(InputAction.CallbackContext context);
    }
}
