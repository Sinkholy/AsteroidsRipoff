//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.0
//     from Assets/Controls/default.inputactions
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

public partial class @DefaultActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @DefaultActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""default"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""ffb7f39a-ec8e-4d7d-b530-431f7dfa47ab"",
            ""actions"": [
                {
                    ""name"": ""Accelerate"",
                    ""type"": ""Value"",
                    ""id"": ""995a469d-a3f3-48db-a067-89c35a3ce632"",
                    ""expectedControlType"": ""Double"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""d14ca498-8edc-459a-9234-2e4883908a83"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": ""Invert"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""abd3c388-52fe-4380-8617-a326f1b6e5c0"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=80)"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""f4c1f958-05b5-4dec-a44b-9d21351a387a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=60)"",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""27099ad6-91ac-4375-aaae-2d7825df430c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""75f6edb7-4671-4ef0-9a47-0443f92f095d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""bfb22a4e-29cf-44dc-9208-aa573485809e"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""One Modifier"",
                    ""id"": ""34148625-e7cf-46b9-8b6d-d012794808ef"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""One Modifier"",
                    ""id"": ""9597d861-c609-4e54-be13-d157f6304e04"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""06b88ed6-ce1e-43c9-933c-b66db600f9f0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""d4ec8b2f-f432-435b-b27b-4a7d27e7da1b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Armory"",
            ""id"": ""62686cf6-1f28-413c-b711-2837648d30b6"",
            ""actions"": [
                {
                    ""name"": ""PrimaryFire"",
                    ""type"": ""Button"",
                    ""id"": ""2140e0da-f29c-4a4e-9876-be1ea312e4a8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press,Hold"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SecondaryFire"",
                    ""type"": ""Button"",
                    ""id"": ""6b1ea4e2-186d-4829-915c-452e4a7dbe0a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""06986c93-ec63-4b46-9aa1-835915f6c2c5"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""PrimaryFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e3670ff7-2b41-4fce-ba29-36eb19790266"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""PrimaryFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""855e51f2-c751-47ff-b5e2-d899c78f2290"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""SecondaryFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""755022fb-b29d-486b-9681-e75865abeffc"",
                    ""path"": ""<Keyboard>/capsLock"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SecondaryFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Abilities"",
            ""id"": ""fccde871-eb46-497f-b209-b6a7c93ddf3f"",
            ""actions"": [
                {
                    ""name"": ""Boost"",
                    ""type"": ""Button"",
                    ""id"": ""17acd017-03d8-4163-801d-5e7dfbd4f0d7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Slowmotion"",
                    ""type"": ""Value"",
                    ""id"": ""d503dc41-d364-4ec2-8dcc-4d4ae41386e3"",
                    ""expectedControlType"": ""Double"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7a2e6447-e5d1-42d8-8b1f-f7d70892f341"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Boost"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dc593089-1ddc-4bb3-abc4-3b510146b133"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Boost"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bf000868-6508-4e9f-ab25-0b21cb1bbd97"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Slowmotion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""92f2f6ea-50ee-4893-a823-0be33d54754d"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Slowmotion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Accelerate = m_Movement.FindAction("Accelerate", throwIfNotFound: true);
        m_Movement_Rotate = m_Movement.FindAction("Rotate", throwIfNotFound: true);
        // Armory
        m_Armory = asset.FindActionMap("Armory", throwIfNotFound: true);
        m_Armory_PrimaryFire = m_Armory.FindAction("PrimaryFire", throwIfNotFound: true);
        m_Armory_SecondaryFire = m_Armory.FindAction("SecondaryFire", throwIfNotFound: true);
        // Abilities
        m_Abilities = asset.FindActionMap("Abilities", throwIfNotFound: true);
        m_Abilities_Boost = m_Abilities.FindAction("Boost", throwIfNotFound: true);
        m_Abilities_Slowmotion = m_Abilities.FindAction("Slowmotion", throwIfNotFound: true);
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

    // Movement
    private readonly InputActionMap m_Movement;
    private List<IMovementActions> m_MovementActionsCallbackInterfaces = new List<IMovementActions>();
    private readonly InputAction m_Movement_Accelerate;
    private readonly InputAction m_Movement_Rotate;
    public struct MovementActions
    {
        private @DefaultActions m_Wrapper;
        public MovementActions(@DefaultActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Accelerate => m_Wrapper.m_Movement_Accelerate;
        public InputAction @Rotate => m_Wrapper.m_Movement_Rotate;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void AddCallbacks(IMovementActions instance)
        {
            if (instance == null || m_Wrapper.m_MovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MovementActionsCallbackInterfaces.Add(instance);
            @Accelerate.started += instance.OnAccelerate;
            @Accelerate.performed += instance.OnAccelerate;
            @Accelerate.canceled += instance.OnAccelerate;
            @Rotate.started += instance.OnRotate;
            @Rotate.performed += instance.OnRotate;
            @Rotate.canceled += instance.OnRotate;
        }

        private void UnregisterCallbacks(IMovementActions instance)
        {
            @Accelerate.started -= instance.OnAccelerate;
            @Accelerate.performed -= instance.OnAccelerate;
            @Accelerate.canceled -= instance.OnAccelerate;
            @Rotate.started -= instance.OnRotate;
            @Rotate.performed -= instance.OnRotate;
            @Rotate.canceled -= instance.OnRotate;
        }

        public void RemoveCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMovementActions instance)
        {
            foreach (var item in m_Wrapper.m_MovementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MovementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // Armory
    private readonly InputActionMap m_Armory;
    private List<IArmoryActions> m_ArmoryActionsCallbackInterfaces = new List<IArmoryActions>();
    private readonly InputAction m_Armory_PrimaryFire;
    private readonly InputAction m_Armory_SecondaryFire;
    public struct ArmoryActions
    {
        private @DefaultActions m_Wrapper;
        public ArmoryActions(@DefaultActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @PrimaryFire => m_Wrapper.m_Armory_PrimaryFire;
        public InputAction @SecondaryFire => m_Wrapper.m_Armory_SecondaryFire;
        public InputActionMap Get() { return m_Wrapper.m_Armory; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ArmoryActions set) { return set.Get(); }
        public void AddCallbacks(IArmoryActions instance)
        {
            if (instance == null || m_Wrapper.m_ArmoryActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ArmoryActionsCallbackInterfaces.Add(instance);
            @PrimaryFire.started += instance.OnPrimaryFire;
            @PrimaryFire.performed += instance.OnPrimaryFire;
            @PrimaryFire.canceled += instance.OnPrimaryFire;
            @SecondaryFire.started += instance.OnSecondaryFire;
            @SecondaryFire.performed += instance.OnSecondaryFire;
            @SecondaryFire.canceled += instance.OnSecondaryFire;
        }

        private void UnregisterCallbacks(IArmoryActions instance)
        {
            @PrimaryFire.started -= instance.OnPrimaryFire;
            @PrimaryFire.performed -= instance.OnPrimaryFire;
            @PrimaryFire.canceled -= instance.OnPrimaryFire;
            @SecondaryFire.started -= instance.OnSecondaryFire;
            @SecondaryFire.performed -= instance.OnSecondaryFire;
            @SecondaryFire.canceled -= instance.OnSecondaryFire;
        }

        public void RemoveCallbacks(IArmoryActions instance)
        {
            if (m_Wrapper.m_ArmoryActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IArmoryActions instance)
        {
            foreach (var item in m_Wrapper.m_ArmoryActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ArmoryActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ArmoryActions @Armory => new ArmoryActions(this);

    // Abilities
    private readonly InputActionMap m_Abilities;
    private List<IAbilitiesActions> m_AbilitiesActionsCallbackInterfaces = new List<IAbilitiesActions>();
    private readonly InputAction m_Abilities_Boost;
    private readonly InputAction m_Abilities_Slowmotion;
    public struct AbilitiesActions
    {
        private @DefaultActions m_Wrapper;
        public AbilitiesActions(@DefaultActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Boost => m_Wrapper.m_Abilities_Boost;
        public InputAction @Slowmotion => m_Wrapper.m_Abilities_Slowmotion;
        public InputActionMap Get() { return m_Wrapper.m_Abilities; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AbilitiesActions set) { return set.Get(); }
        public void AddCallbacks(IAbilitiesActions instance)
        {
            if (instance == null || m_Wrapper.m_AbilitiesActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_AbilitiesActionsCallbackInterfaces.Add(instance);
            @Boost.started += instance.OnBoost;
            @Boost.performed += instance.OnBoost;
            @Boost.canceled += instance.OnBoost;
            @Slowmotion.started += instance.OnSlowmotion;
            @Slowmotion.performed += instance.OnSlowmotion;
            @Slowmotion.canceled += instance.OnSlowmotion;
        }

        private void UnregisterCallbacks(IAbilitiesActions instance)
        {
            @Boost.started -= instance.OnBoost;
            @Boost.performed -= instance.OnBoost;
            @Boost.canceled -= instance.OnBoost;
            @Slowmotion.started -= instance.OnSlowmotion;
            @Slowmotion.performed -= instance.OnSlowmotion;
            @Slowmotion.canceled -= instance.OnSlowmotion;
        }

        public void RemoveCallbacks(IAbilitiesActions instance)
        {
            if (m_Wrapper.m_AbilitiesActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IAbilitiesActions instance)
        {
            foreach (var item in m_Wrapper.m_AbilitiesActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_AbilitiesActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public AbilitiesActions @Abilities => new AbilitiesActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IMovementActions
    {
        void OnAccelerate(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
    }
    public interface IArmoryActions
    {
        void OnPrimaryFire(InputAction.CallbackContext context);
        void OnSecondaryFire(InputAction.CallbackContext context);
    }
    public interface IAbilitiesActions
    {
        void OnBoost(InputAction.CallbackContext context);
        void OnSlowmotion(InputAction.CallbackContext context);
    }
}
