using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class sinyal : MonoBehaviour
{

    public Image ObjectIcon;
    public Image ObjectIcon2;
    public AudioSource audioS;

    public InputActionAsset inputActions;
    InputActionMap gameplay;
    InputAction LSignal, RSignal;
    private void Awake()
    {
        gameplay = inputActions.FindActionMap("Gameplay");
        LSignal = gameplay.FindAction("Left Signal");
        RSignal = gameplay.FindAction("Right Signal");

        LSignal.performed += LSignal_performed;
        RSignal.performed += RSignal_performed;
    }

    private void RSignal_performed(InputAction.CallbackContext obj) //sağ sinyal (klavyede L tuşu ve konsolda 3 tuşu)
    {
        ObjectIcon.enabled = true;
        audioS.Play();
        StartCoroutine(Fade());
    }

    private void LSignal_performed(InputAction.CallbackContext obj) //sol sinyal (klavyede k tuşu ve konsolda 6 numaralı tuş) 
    {
        ObjectIcon2.enabled = true;
        audioS.Play();
        StartCoroutine(Fade());
    }

    private void OnEnable()
    {
        RSignal.Enable();
        LSignal.Enable();
    }
    private void OnDisable()
    {
        RSignal.Disable();
        LSignal.Disable();
    }
    private void Start()
    {
        ObjectIcon.enabled = false;
        ObjectIcon2.enabled=false;
    }
    void Update()
    {
       
        if (Input.GetKeyDown("l"))//saga dön
        {
            ObjectIcon.enabled = true;
            Debug.Log("L basıldı");
            audioS.Play();
            StartCoroutine(Fade());
        }
        if (Input.GetKeyDown("k"))//sola dön
        {
            ObjectIcon2.enabled = true;
            audioS.Play();
            StartCoroutine(Fade());
        }


    }
    IEnumerator Fade ()
    {
            //Debug.Log("Coroutine");
        
        yield return new WaitForSeconds(3f);
        ObjectIcon.enabled = false;
        ObjectIcon2.enabled = false;
        audioS.Pause();
    }

}
