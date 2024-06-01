// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""ad5ae095-6aa6-4c7b-be99-426fde5d1a3f"",
            ""actions"": [
                {
                    ""name"": ""JumpHold"",
                    ""type"": ""PassThrough"",
                    ""id"": ""202a9bcf-77cd-45e5-bcb0-10bec38e97ee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.02)""
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d5e1f86d-b868-4274-922c-a1528029cd5e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""PassThrough"",
                    ""id"": ""22cb2bf5-25ec-49fd-922e-b7ab92b21690"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""Map"",
                    ""type"": ""Button"",
                    ""id"": ""1e435edb-1d97-404c-9797-13003072f0a8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SpellHold"",
                    ""type"": ""Button"",
                    ""id"": ""b1f83997-2610-4398-a3a4-77aec2d9aae9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""SpellPress"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8bb40f4d-b6c3-4100-8c99-4ef7745ad27f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""AttackPress"",
                    ""type"": ""PassThrough"",
                    ""id"": ""10a31ae5-3bb3-4de3-8702-ed30ed371a10"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.3)""
                },
                {
                    ""name"": ""Open Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""bf5e880e-dde9-40b2-987c-14dd243e8d95"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.3)""
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""64857468-a156-47f8-8f1e-3d20578d0e7e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""78488960-ea9a-4d9a-8477-d3865a166ec8"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""a0d4ac71-3945-4b23-b1aa-abb03a06af91"",
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
                    ""id"": ""91e776ea-caa9-430b-b5d6-569b6c0a1e24"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""08861d74-fd17-4c3b-a45f-276f6674e83b"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a062e92a-6b8d-4aa8-a3bc-b63b3de40b37"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fdc7cfa9-2bd8-4e89-bc4f-8594da3c9c5c"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ba9344b6-950d-43f1-ae1e-1f199917cc9d"",
                    ""path"": ""<XInputController>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""341ed441-bf5e-48be-bee3-570b02dc3c01"",
                    ""path"": ""<DualShockGamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2faf5e46-0292-49f7-9908-b5ba169cc72e"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpHold"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ded24822-ce23-4bd3-8ba7-ee2ebbf91243"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpHold"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89ec05f4-52cc-438a-8623-bece353e5c84"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpHold"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cdb8f4db-f088-4170-b5a9-06e395513830"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpHold"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ec247c4-2b5c-41c5-b1f7-d82aeb5794e8"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpHold"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""52fbec2b-72f0-4d9e-9893-b2d5d1a26483"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dbb507a0-09a0-4b5a-931d-64672f992434"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d4ce60a-954e-4e3a-843e-867eb9b6c357"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35d4c127-edcf-492b-b91e-e3dac3df8504"",
                    ""path"": ""<DualShockGamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""621e0dc1-09da-4527-b7ef-f5b3386b642e"",
                    ""path"": ""<XInputController>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""75d02384-cf32-4d42-840a-4e447eec0258"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Map"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5bbebcb8-fca9-48e4-a898-a89b0c8a9c0f"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpellHold"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d8a50c6-77d7-4547-b03c-468e0207d8b7"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpellPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c070d1b8-54b1-4b11-9d00-f4514acb714c"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpellPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""79da9319-2a5d-44e8-9201-53d344323df6"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c9111604-840e-469f-8276-94759c5d8e8a"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7cc6fbac-94b8-40fe-a2ca-dd97f98c21ab"",
                    ""path"": ""<XInputController>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""64d8566b-6590-4875-be5a-98756b9ea57a"",
                    ""path"": ""<DualShockGamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5e7dac75-2177-4fb5-a376-abc1bc031d8c"",
                    ""path"": ""<DualShockGamepad>/touchpadButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Open Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ebdd0c18-ae95-492f-9a7c-2cf692686a04"",
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
                    ""id"": ""7bdabd69-64c7-4b29-b88d-aaa3b83fb444"",
                    ""path"": ""<DualShockGamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d4f435f-4a00-4f96-8514-41c0670bf22f"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f7f5c696-cbe1-4ee2-9b53-2faeeef99b24"",
                    ""path"": ""<XInputController>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_JumpHold = m_Gameplay.FindAction("JumpHold", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_Dash = m_Gameplay.FindAction("Dash", throwIfNotFound: true);
        m_Gameplay_Map = m_Gameplay.FindAction("Map", throwIfNotFound: true);
        m_Gameplay_SpellHold = m_Gameplay.FindAction("SpellHold", throwIfNotFound: true);
        m_Gameplay_SpellPress = m_Gameplay.FindAction("SpellPress", throwIfNotFound: true);
        m_Gameplay_AttackPress = m_Gameplay.FindAction("AttackPress", throwIfNotFound: true);
        m_Gameplay_OpenInventory = m_Gameplay.FindAction("Open Inventory", throwIfNotFound: true);
        m_Gameplay_Pause = m_Gameplay.FindAction("Pause", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_JumpHold;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_Dash;
    private readonly InputAction m_Gameplay_Map;
    private readonly InputAction m_Gameplay_SpellHold;
    private readonly InputAction m_Gameplay_SpellPress;
    private readonly InputAction m_Gameplay_AttackPress;
    private readonly InputAction m_Gameplay_OpenInventory;
    private readonly InputAction m_Gameplay_Pause;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @JumpHold => m_Wrapper.m_Gameplay_JumpHold;
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Dash => m_Wrapper.m_Gameplay_Dash;
        public InputAction @Map => m_Wrapper.m_Gameplay_Map;
        public InputAction @SpellHold => m_Wrapper.m_Gameplay_SpellHold;
        public InputAction @SpellPress => m_Wrapper.m_Gameplay_SpellPress;
        public InputAction @AttackPress => m_Wrapper.m_Gameplay_AttackPress;
        public InputAction @OpenInventory => m_Wrapper.m_Gameplay_OpenInventory;
        public InputAction @Pause => m_Wrapper.m_Gameplay_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @JumpHold.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJumpHold;
                @JumpHold.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJumpHold;
                @JumpHold.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJumpHold;
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Dash.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Map.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMap;
                @Map.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMap;
                @Map.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMap;
                @SpellHold.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpellHold;
                @SpellHold.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpellHold;
                @SpellHold.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpellHold;
                @SpellPress.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpellPress;
                @SpellPress.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpellPress;
                @SpellPress.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpellPress;
                @AttackPress.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttackPress;
                @AttackPress.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttackPress;
                @AttackPress.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttackPress;
                @OpenInventory.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOpenInventory;
                @OpenInventory.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOpenInventory;
                @OpenInventory.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOpenInventory;
                @Pause.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @JumpHold.started += instance.OnJumpHold;
                @JumpHold.performed += instance.OnJumpHold;
                @JumpHold.canceled += instance.OnJumpHold;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Map.started += instance.OnMap;
                @Map.performed += instance.OnMap;
                @Map.canceled += instance.OnMap;
                @SpellHold.started += instance.OnSpellHold;
                @SpellHold.performed += instance.OnSpellHold;
                @SpellHold.canceled += instance.OnSpellHold;
                @SpellPress.started += instance.OnSpellPress;
                @SpellPress.performed += instance.OnSpellPress;
                @SpellPress.canceled += instance.OnSpellPress;
                @AttackPress.started += instance.OnAttackPress;
                @AttackPress.performed += instance.OnAttackPress;
                @AttackPress.canceled += instance.OnAttackPress;
                @OpenInventory.started += instance.OnOpenInventory;
                @OpenInventory.performed += instance.OnOpenInventory;
                @OpenInventory.canceled += instance.OnOpenInventory;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnJumpHold(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnMap(InputAction.CallbackContext context);
        void OnSpellHold(InputAction.CallbackContext context);
        void OnSpellPress(InputAction.CallbackContext context);
        void OnAttackPress(InputAction.CallbackContext context);
        void OnOpenInventory(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
