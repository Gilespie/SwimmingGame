//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/InputSystem/PlayerInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""e9072bfa-1647-40ee-b982-2ae1b3337b29"",
            ""actions"": [
                {
                    ""name"": ""Swipe"",
                    ""type"": ""Value"",
                    ""id"": ""52d9a90f-ce0e-44ae-92ce-f6f982927835"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""KeyboardMovementForward"",
                    ""type"": ""Button"",
                    ""id"": ""5f128fa6-3907-4d70-89f5-296f227b2cf9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AccelerationForward"",
                    ""type"": ""Button"",
                    ""id"": ""052e7e1e-ad15-4188-a5db-8215d4ffe184"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""KeyboardMovementSides"",
                    ""type"": ""Button"",
                    ""id"": ""b2c4b18d-94c0-4567-a2e0-47f9a00b9ed1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""df060bd0-df6f-40a8-af38-7d455c787893"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AccelerationForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8b07276-e2ff-471c-92d4-9ac7a9a14a6d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardMovementForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d766708d-ce56-4515-9430-46b027cdc63c"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardMovementForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""0156e60a-912e-4911-a755-00ff8ed44365"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardMovementSides"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""12952e77-cd12-49b3-93ac-23a693222a43"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardMovementSides"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0889479c-2b91-441a-a1c7-9d65400e6e8a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardMovementSides"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Touch"",
                    ""id"": ""98de0c7b-3be6-410f-b761-38a8a797a93f"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swipe"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""53b851b9-1c4c-4fe5-b73e-2dfda6950075"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swipe"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""23dc86b7-5b2b-4e81-88ee-b564162bab05"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swipe"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Mouse"",
                    ""id"": ""e0655ab4-5e9f-4746-903a-e447beddc016"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swipe"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""82537d35-4691-485b-8194-4c5e4d979028"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swipe"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""5035ce2a-1ed7-486a-b877-cba46e483862"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swipe"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Swipe = m_Gameplay.FindAction("Swipe", throwIfNotFound: true);
        m_Gameplay_KeyboardMovementForward = m_Gameplay.FindAction("KeyboardMovementForward", throwIfNotFound: true);
        m_Gameplay_AccelerationForward = m_Gameplay.FindAction("AccelerationForward", throwIfNotFound: true);
        m_Gameplay_KeyboardMovementSides = m_Gameplay.FindAction("KeyboardMovementSides", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private List<IGameplayActions> m_GameplayActionsCallbackInterfaces = new List<IGameplayActions>();
    private readonly InputAction m_Gameplay_Swipe;
    private readonly InputAction m_Gameplay_KeyboardMovementForward;
    private readonly InputAction m_Gameplay_AccelerationForward;
    private readonly InputAction m_Gameplay_KeyboardMovementSides;
    public struct GameplayActions
    {
        private @PlayerInput m_Wrapper;
        public GameplayActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Swipe => m_Wrapper.m_Gameplay_Swipe;
        public InputAction @KeyboardMovementForward => m_Wrapper.m_Gameplay_KeyboardMovementForward;
        public InputAction @AccelerationForward => m_Wrapper.m_Gameplay_AccelerationForward;
        public InputAction @KeyboardMovementSides => m_Wrapper.m_Gameplay_KeyboardMovementSides;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void AddCallbacks(IGameplayActions instance)
        {
            if (instance == null || m_Wrapper.m_GameplayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Add(instance);
            @Swipe.started += instance.OnSwipe;
            @Swipe.performed += instance.OnSwipe;
            @Swipe.canceled += instance.OnSwipe;
            @KeyboardMovementForward.started += instance.OnKeyboardMovementForward;
            @KeyboardMovementForward.performed += instance.OnKeyboardMovementForward;
            @KeyboardMovementForward.canceled += instance.OnKeyboardMovementForward;
            @AccelerationForward.started += instance.OnAccelerationForward;
            @AccelerationForward.performed += instance.OnAccelerationForward;
            @AccelerationForward.canceled += instance.OnAccelerationForward;
            @KeyboardMovementSides.started += instance.OnKeyboardMovementSides;
            @KeyboardMovementSides.performed += instance.OnKeyboardMovementSides;
            @KeyboardMovementSides.canceled += instance.OnKeyboardMovementSides;
        }

        private void UnregisterCallbacks(IGameplayActions instance)
        {
            @Swipe.started -= instance.OnSwipe;
            @Swipe.performed -= instance.OnSwipe;
            @Swipe.canceled -= instance.OnSwipe;
            @KeyboardMovementForward.started -= instance.OnKeyboardMovementForward;
            @KeyboardMovementForward.performed -= instance.OnKeyboardMovementForward;
            @KeyboardMovementForward.canceled -= instance.OnKeyboardMovementForward;
            @AccelerationForward.started -= instance.OnAccelerationForward;
            @AccelerationForward.performed -= instance.OnAccelerationForward;
            @AccelerationForward.canceled -= instance.OnAccelerationForward;
            @KeyboardMovementSides.started -= instance.OnKeyboardMovementSides;
            @KeyboardMovementSides.performed -= instance.OnKeyboardMovementSides;
            @KeyboardMovementSides.canceled -= instance.OnKeyboardMovementSides;
        }

        public void RemoveCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameplayActions instance)
        {
            foreach (var item in m_Wrapper.m_GameplayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnSwipe(InputAction.CallbackContext context);
        void OnKeyboardMovementForward(InputAction.CallbackContext context);
        void OnAccelerationForward(InputAction.CallbackContext context);
        void OnKeyboardMovementSides(InputAction.CallbackContext context);
    }
}
