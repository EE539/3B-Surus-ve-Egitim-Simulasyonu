// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerController"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""be878a8e-a18b-4311-aade-6a05734fabff"",
            ""actions"": [
                {
                    ""name"": ""Acceleration"",
                    ""type"": ""Value"",
                    ""id"": ""169723bc-ca69-44c3-97cb-45079d9700b9"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Turn"",
                    ""type"": ""Value"",
                    ""id"": ""7cc0d310-852a-4b99-9fdd-9d87d924b831"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Brake"",
                    ""type"": ""Button"",
                    ""id"": ""3238182e-79a1-422f-89fa-7527e41e5cb6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Kontak"",
                    ""type"": ""Button"",
                    ""id"": ""7336a395-5537-4f00-88e5-35c32f8dda9f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Hand Brake"",
                    ""type"": ""Button"",
                    ""id"": ""2e90103d-7347-43fe-a373-0abbb7470925"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left Signal"",
                    ""type"": ""Button"",
                    ""id"": ""b58fb992-18e0-4b9d-b4ba-2ba730c99e52"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right Signal"",
                    ""type"": ""Button"",
                    ""id"": ""09d2933b-33ed-425f-ad10-06344d631308"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Currentvites Down"",
                    ""type"": ""Button"",
                    ""id"": ""b899ec72-bdf1-40f6-b219-62c73e4bafa9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Currentvites Up"",
                    ""type"": ""Button"",
                    ""id"": ""8de397b2-1f53-45ba-9ed5-d70cb10fdbae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Horn"",
                    ""type"": ""Button"",
                    ""id"": ""6457832d-a2e6-4bfe-8ca3-c133a93a957c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""N Button"",
                    ""type"": ""Button"",
                    ""id"": ""c0205bab-d331-4b66-b236-614546bee041"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""M Button"",
                    ""type"": ""Button"",
                    ""id"": ""23533206-a8d3-40c0-a233-d7c22b2b7e51"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Escape Button"",
                    ""type"": ""Button"",
                    ""id"": ""cb476869-2336-46e3-aacb-670466269770"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""09550b94-49ed-4369-bbdd-75a52106e418"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Acceleration"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""8bcd6c14-4da9-4b2b-a857-3df02b3bec5a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Acceleration"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""51ac1ae5-500f-4809-8cf3-81dca5b92ba5"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Acceleration"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""23d07590-2fae-4590-adee-baa6d4922a57"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Acceleration"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""45b72230-59a9-4b98-a031-21f6d90b1af4"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d32a5848-0e47-4a10-8b7e-327fc22164d2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""5ff2d940-3043-44a5-a837-310a67ed991c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D AxisC"",
                    ""id"": ""bfbd7b27-c04f-4800-85fa-7f6c48f0c2d8"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d99ff132-f393-4633-81cb-c9b24ca05557"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""7bc2304d-7ccb-43d9-af22-0e188db9f23b"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/stick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""de71eeb0-8b7d-468e-aaca-907f8c6e8de9"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5e4e174-9a9d-4a71-829c-b80b86a9966e"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a95c2cf-fda7-4c75-a990-9650d370f65e"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/button7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Kontak"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0db6cde-5be8-4161-a64b-99e9ea5a3105"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Kontak"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b27ac13d-4260-4943-807d-1fc703b0ff6e"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/button8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hand Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a152b666-e4f4-43a4-8ed2-63850a171825"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hand Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5927f58b-2b5b-4558-ab63-180eefa4ba4e"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left Signal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50cac3b5-4802-47f4-8fe6-d75c84ecd37c"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/button6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left Signal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f410d27-e91f-4ed5-b31e-d9f0b74e09e1"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right Signal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0d01c79a-93e4-4f5b-88c0-077cfe45b91a"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/button3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right Signal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6ca70048-c9a1-468b-819e-9bbae5811979"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Currentvites Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ea73265-e53a-4c87-b11b-e0b86ebd587e"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/button2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Currentvites Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""26c7e8b7-5b66-4981-9192-78ffd7037b68"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Currentvites Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3de9cef5-234f-4c1e-b892-7e851051bfe8"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/hat/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dbf90d90-7cee-4b23-9c42-0fdaace7d7de"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35976fdd-0ede-42f1-8e64-03ea3bea18bb"",
                    ""path"": ""<Keyboard>/n"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""N Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f772672-204e-46f3-969a-83fc67f267ad"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/button4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""N Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8757d632-3f19-40ed-8b4d-d087f187d416"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""M Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb9437db-4baf-431c-a929-458335612819"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/button5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""M Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de917c2a-b6eb-4451-86aa-b5adc54acca1"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b37d26c-3248-47bc-a914-bdc994bff165"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/button10"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape Button"",
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
        m_Gameplay_Acceleration = m_Gameplay.FindAction("Acceleration", throwIfNotFound: true);
        m_Gameplay_Turn = m_Gameplay.FindAction("Turn", throwIfNotFound: true);
        m_Gameplay_Brake = m_Gameplay.FindAction("Brake", throwIfNotFound: true);
        m_Gameplay_Kontak = m_Gameplay.FindAction("Kontak", throwIfNotFound: true);
        m_Gameplay_HandBrake = m_Gameplay.FindAction("Hand Brake", throwIfNotFound: true);
        m_Gameplay_LeftSignal = m_Gameplay.FindAction("Left Signal", throwIfNotFound: true);
        m_Gameplay_RightSignal = m_Gameplay.FindAction("Right Signal", throwIfNotFound: true);
        m_Gameplay_CurrentvitesDown = m_Gameplay.FindAction("Currentvites Down", throwIfNotFound: true);
        m_Gameplay_CurrentvitesUp = m_Gameplay.FindAction("Currentvites Up", throwIfNotFound: true);
        m_Gameplay_Horn = m_Gameplay.FindAction("Horn", throwIfNotFound: true);
        m_Gameplay_NButton = m_Gameplay.FindAction("N Button", throwIfNotFound: true);
        m_Gameplay_MButton = m_Gameplay.FindAction("M Button", throwIfNotFound: true);
        m_Gameplay_EscapeButton = m_Gameplay.FindAction("Escape Button", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_Acceleration;
    private readonly InputAction m_Gameplay_Turn;
    private readonly InputAction m_Gameplay_Brake;
    private readonly InputAction m_Gameplay_Kontak;
    private readonly InputAction m_Gameplay_HandBrake;
    private readonly InputAction m_Gameplay_LeftSignal;
    private readonly InputAction m_Gameplay_RightSignal;
    private readonly InputAction m_Gameplay_CurrentvitesDown;
    private readonly InputAction m_Gameplay_CurrentvitesUp;
    private readonly InputAction m_Gameplay_Horn;
    private readonly InputAction m_Gameplay_NButton;
    private readonly InputAction m_Gameplay_MButton;
    private readonly InputAction m_Gameplay_EscapeButton;
    public struct GameplayActions
    {
        private @PlayerController m_Wrapper;
        public GameplayActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Acceleration => m_Wrapper.m_Gameplay_Acceleration;
        public InputAction @Turn => m_Wrapper.m_Gameplay_Turn;
        public InputAction @Brake => m_Wrapper.m_Gameplay_Brake;
        public InputAction @Kontak => m_Wrapper.m_Gameplay_Kontak;
        public InputAction @HandBrake => m_Wrapper.m_Gameplay_HandBrake;
        public InputAction @LeftSignal => m_Wrapper.m_Gameplay_LeftSignal;
        public InputAction @RightSignal => m_Wrapper.m_Gameplay_RightSignal;
        public InputAction @CurrentvitesDown => m_Wrapper.m_Gameplay_CurrentvitesDown;
        public InputAction @CurrentvitesUp => m_Wrapper.m_Gameplay_CurrentvitesUp;
        public InputAction @Horn => m_Wrapper.m_Gameplay_Horn;
        public InputAction @NButton => m_Wrapper.m_Gameplay_NButton;
        public InputAction @MButton => m_Wrapper.m_Gameplay_MButton;
        public InputAction @EscapeButton => m_Wrapper.m_Gameplay_EscapeButton;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Acceleration.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAcceleration;
                @Acceleration.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAcceleration;
                @Acceleration.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAcceleration;
                @Turn.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTurn;
                @Turn.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTurn;
                @Turn.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTurn;
                @Brake.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBrake;
                @Brake.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBrake;
                @Brake.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBrake;
                @Kontak.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnKontak;
                @Kontak.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnKontak;
                @Kontak.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnKontak;
                @HandBrake.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHandBrake;
                @HandBrake.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHandBrake;
                @HandBrake.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHandBrake;
                @LeftSignal.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftSignal;
                @LeftSignal.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftSignal;
                @LeftSignal.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftSignal;
                @RightSignal.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightSignal;
                @RightSignal.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightSignal;
                @RightSignal.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightSignal;
                @CurrentvitesDown.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCurrentvitesDown;
                @CurrentvitesDown.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCurrentvitesDown;
                @CurrentvitesDown.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCurrentvitesDown;
                @CurrentvitesUp.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCurrentvitesUp;
                @CurrentvitesUp.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCurrentvitesUp;
                @CurrentvitesUp.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCurrentvitesUp;
                @Horn.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHorn;
                @Horn.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHorn;
                @Horn.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHorn;
                @NButton.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNButton;
                @NButton.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNButton;
                @NButton.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNButton;
                @MButton.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMButton;
                @MButton.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMButton;
                @MButton.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMButton;
                @EscapeButton.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEscapeButton;
                @EscapeButton.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEscapeButton;
                @EscapeButton.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEscapeButton;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Acceleration.started += instance.OnAcceleration;
                @Acceleration.performed += instance.OnAcceleration;
                @Acceleration.canceled += instance.OnAcceleration;
                @Turn.started += instance.OnTurn;
                @Turn.performed += instance.OnTurn;
                @Turn.canceled += instance.OnTurn;
                @Brake.started += instance.OnBrake;
                @Brake.performed += instance.OnBrake;
                @Brake.canceled += instance.OnBrake;
                @Kontak.started += instance.OnKontak;
                @Kontak.performed += instance.OnKontak;
                @Kontak.canceled += instance.OnKontak;
                @HandBrake.started += instance.OnHandBrake;
                @HandBrake.performed += instance.OnHandBrake;
                @HandBrake.canceled += instance.OnHandBrake;
                @LeftSignal.started += instance.OnLeftSignal;
                @LeftSignal.performed += instance.OnLeftSignal;
                @LeftSignal.canceled += instance.OnLeftSignal;
                @RightSignal.started += instance.OnRightSignal;
                @RightSignal.performed += instance.OnRightSignal;
                @RightSignal.canceled += instance.OnRightSignal;
                @CurrentvitesDown.started += instance.OnCurrentvitesDown;
                @CurrentvitesDown.performed += instance.OnCurrentvitesDown;
                @CurrentvitesDown.canceled += instance.OnCurrentvitesDown;
                @CurrentvitesUp.started += instance.OnCurrentvitesUp;
                @CurrentvitesUp.performed += instance.OnCurrentvitesUp;
                @CurrentvitesUp.canceled += instance.OnCurrentvitesUp;
                @Horn.started += instance.OnHorn;
                @Horn.performed += instance.OnHorn;
                @Horn.canceled += instance.OnHorn;
                @NButton.started += instance.OnNButton;
                @NButton.performed += instance.OnNButton;
                @NButton.canceled += instance.OnNButton;
                @MButton.started += instance.OnMButton;
                @MButton.performed += instance.OnMButton;
                @MButton.canceled += instance.OnMButton;
                @EscapeButton.started += instance.OnEscapeButton;
                @EscapeButton.performed += instance.OnEscapeButton;
                @EscapeButton.canceled += instance.OnEscapeButton;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnAcceleration(InputAction.CallbackContext context);
        void OnTurn(InputAction.CallbackContext context);
        void OnBrake(InputAction.CallbackContext context);
        void OnKontak(InputAction.CallbackContext context);
        void OnHandBrake(InputAction.CallbackContext context);
        void OnLeftSignal(InputAction.CallbackContext context);
        void OnRightSignal(InputAction.CallbackContext context);
        void OnCurrentvitesDown(InputAction.CallbackContext context);
        void OnCurrentvitesUp(InputAction.CallbackContext context);
        void OnHorn(InputAction.CallbackContext context);
        void OnNButton(InputAction.CallbackContext context);
        void OnMButton(InputAction.CallbackContext context);
        void OnEscapeButton(InputAction.CallbackContext context);
    }
}
