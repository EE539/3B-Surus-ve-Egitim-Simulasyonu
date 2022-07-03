using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public enum otoviteslevels{
    PARK, DRIVE, REVERSE, NEUTRAL
}

public class CarController : MonoBehaviour
{
    private Rigidbody rb;
    private float horizontalInput;
    private float verticalInput;
    private float currentsteerAngle;
    [HideInInspector] public float currentbreakForce;
    public bool isBreaking;
    public float topSpeed;
    public float  speed;
    public bool kontak;
    public bool callOptions;
    public otoviteslevels currentvites;
    public bool elfrenicekili;

    private Vector3 oldPosition;

    public GameObject elFreniUyari;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider FrontLWCollider;
    [SerializeField] private WheelCollider FrontRWCollider;
    [SerializeField] private WheelCollider RearLWCollider;
    [SerializeField] private WheelCollider RearRWCollider;


    [SerializeField] private Transform FrontLWTransform;
    [SerializeField] private Transform FrontRWTransform;
    [SerializeField] private Transform RearLWTransform;
    [SerializeField] private Transform RearRWTransform;

    /*konsol ve klavye için gerekli yer*/
    public InputActionAsset inputActions;
    InputActionMap gameplay;
    InputAction handBrakeInput;
    InputAction steeringInput;
    InputAction accelerationInput;
    InputAction kontakInput;
    InputAction elFreniInput;
    InputAction currentVDInput, currentVUInput;
    InputAction hornInput;
    InputAction escInput;
    public float handBrake, torque, angle;
    public AudioSource korna;

    private void Awake()
    {
        gameplay = inputActions.FindActionMap("Gameplay");

        handBrakeInput = gameplay.FindAction("Brake");
        steeringInput = gameplay.FindAction("Turn");
        accelerationInput = gameplay.FindAction("Acceleration");
        kontakInput = gameplay.FindAction("Kontak");
        elFreniInput = gameplay.FindAction("Hand Brake");
        currentVDInput = gameplay.FindAction("Currentvites Down");
        currentVUInput = gameplay.FindAction("Currentvites Up");
        hornInput = gameplay.FindAction("Horn");
        escInput = gameplay.FindAction("Escape Button");

        handBrakeInput.performed += HandBrakeInput;
        steeringInput.performed += SteeringInput;
        accelerationInput.performed += AccelerationInput;
        kontakInput.performed += KontakInput;
        elFreniInput.performed += ElFreniInput;
        currentVDInput.performed += CurrentVDInput;
        currentVUInput.performed += CurrentVUInput;
        hornInput.performed += HornInput_performed;
        escInput.performed += EscInput;

        handBrakeInput.canceled += HandBrakeInput;
        steeringInput.canceled += SteeringInput;
        handBrakeInput.canceled += HandBrakeInput_canceled;
    }

    private void EscInput(InputAction.CallbackContext obj)
    {
        PauseGame();
        currentbreakForce = 37267.0f;
        ApplyBreaking();
    }

    private void HornInput_performed(InputAction.CallbackContext obj)
    {
        if(!korna.isPlaying)
            korna.Play();
    }

    private void CurrentVUInput(InputAction.CallbackContext obj)
    {
        if (currentvites.Equals(otoviteslevels.PARK))
        {//DRIVE GECIS
            currentvites = otoviteslevels.NEUTRAL;
        }
        else if (currentvites.Equals(otoviteslevels.DRIVE))
        {//REVERSE GECIS
            currentvites = otoviteslevels.PARK;
        }
        else if (currentvites.Equals(otoviteslevels.REVERSE))
        {//NEUTRAL GECIS
            currentvites = otoviteslevels.DRIVE;
        }
        else
        {//PARK GECIS
            currentvites = otoviteslevels.REVERSE;
        }
    }

    private void CurrentVDInput(InputAction.CallbackContext obj)
    {
        if (currentvites.Equals(otoviteslevels.PARK))
        {
            currentvites = otoviteslevels.DRIVE;
        }
        else if (currentvites.Equals(otoviteslevels.DRIVE))
        {
            currentvites = otoviteslevels.REVERSE;
        }
        else if (currentvites.Equals(otoviteslevels.REVERSE))
        {
            currentvites = otoviteslevels.NEUTRAL;
        }
        else
        {
            currentvites = otoviteslevels.PARK;
        }
    }

    private void HandBrakeInput_canceled(InputAction.CallbackContext obj) //frene basmayı durduğumuzda
    {
        isBreaking = false;
    }

    private void AccelerationInput(InputAction.CallbackContext context)//Hızlan
    {
        torque = context.ReadValue<float>() * motorForce;
    }

    private void SteeringInput(InputAction.CallbackContext context) //döndürme
    {
        angle = context.ReadValue<float>() * maxSteerAngle;
    }

    private void HandBrakeInput(InputAction.CallbackContext context) //frene basmaya başlarsak
    {
        isBreaking = true;
    }

    private void KontakInput(InputAction.CallbackContext obj) //kontak aç kap (klavyede X ve konsolda 7 numaralı tuş)
    {
        if (obj.performed)
        {
            if (kontak)
            { 
                kontak = false;
                currentbreakForce = 37267.0f;
                ApplyBreaking();
            }
               
            else
                kontak = true;
        }
    }
    private void ElFreniInput(InputAction.CallbackContext context) //el frenini çek ya da it (klavyede Q ve konsolda 8 numaralı tuş)
    {
        if (context.performed)
        {
            if (elfrenicekili)
            {
                elfrenicekili = false;
                elFreniUyari.SetActive(true);
            }
            else
            {
                elfrenicekili = true;
                elFreniUyari.SetActive(false);
            }
        }
    }
    private void OnEnable()//Çalışması için önemli, SAKIN SİLMEYİN!!!
    {
        handBrakeInput.Enable();
        steeringInput.Enable();
        accelerationInput.Enable();
        kontakInput.Enable();
        elFreniInput.Enable();
        currentVDInput.Enable();
        currentVUInput.Enable();
        hornInput.Enable();
        escInput.Enable();
    }
    private void OnDisable()//Çalışması için önemli, SAKIN SİLMEYİN!!!
    {
        handBrakeInput.Disable();
        steeringInput.Disable();
        accelerationInput.Disable();
        kontakInput.Disable();
        elFreniInput.Disable();
        currentVDInput.Disable();
        currentVUInput.Disable();
        hornInput.Disable();
        escInput.Disable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        kontak = false;
        callOptions = false;
        currentvites = otoviteslevels.PARK;
        elfrenicekili=true;
        elFreniUyari.SetActive(true);
    }
    private void FixedUpdate()
    {
        speed = CarSpeed();
        oldPosition = transform.position;
        GetInput();

        if (kontak)
        {
            HandleSteering();
            HandleWheels();
            if(currentvites.Equals(otoviteslevels.PARK)){
                HandleMotorOnPark();
            }
            else if(currentvites.Equals(otoviteslevels.DRIVE)){
                HandleMotorOnDrive();
            }
            else if(currentvites.Equals(otoviteslevels.REVERSE)){
                HandleMotorOnReverse();
            }
        }
        if(elfrenicekili){
            elFreniUyari.SetActive(true);
        }
        else{
            elFreniUyari.SetActive(false);
        }
    }
    private void GetInput(){
        //horizontalInput = Input.GetAxis("Horizontal");
        //verticalInput = Input.GetAxis("Vertical");
        horizontalInput = steeringInput.ReadValue<float>();
        verticalInput = accelerationInput.ReadValue<float>();
    }
    private void HandleMotorOnDrive()//İleri gitmek için kullanmanız gereken vites
    {
        FrontLWCollider.motorTorque = verticalInput * motorForce;
        FrontRWCollider.motorTorque = verticalInput * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }
    private void HandleMotorOnPark()//Park etmek ve yolculuğu tamamlamak için kullanmanız gereken vites
    {
        currentbreakForce = 37267.0f;
        ApplyBreaking();
    }
    private void HandleMotorOnReverse()//Geri gitmek için kullanmanız gereken vites
    { 
        FrontLWCollider.motorTorque = verticalInput * motorForce * (-1);
        FrontRWCollider.motorTorque = verticalInput * motorForce * (-1);
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }
    [HideInInspector] public void ApplyBreaking(){
        FrontRWCollider.brakeTorque = currentbreakForce;
        FrontLWCollider.brakeTorque = currentbreakForce;
        RearRWCollider.brakeTorque = currentbreakForce;
        RearLWCollider.brakeTorque = currentbreakForce;
    }
    private void HandleSteering(){
        currentsteerAngle = maxSteerAngle * horizontalInput ;
        FrontLWCollider.steerAngle = currentsteerAngle;
        FrontRWCollider.steerAngle = currentsteerAngle;
    }
    private void HandleWheels(){
        UpdateSingleWheel(FrontLWCollider, FrontLWTransform);
        UpdateSingleWheel(FrontRWCollider, FrontRWTransform);
        UpdateSingleWheel(RearLWCollider, RearLWTransform);
        UpdateSingleWheel(RearRWCollider, RearRWTransform);
    }
     private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
    void PauseGame()
    {
        Time.timeScale = 0;
    }
    public float CarSpeed()
    {
        float speed = rb.velocity.magnitude; //rigidbody de bulunan hız değerinin kuvvetini al ve speed e ver
        speed *= 3.6f;
        if(speed > topSpeed)
        {
            rb.velocity = (topSpeed / 3.6f) * rb.velocity.normalized; //hızın 360'ın üzerine çıkmasını engeller
        }
        return speed;
    }
}


