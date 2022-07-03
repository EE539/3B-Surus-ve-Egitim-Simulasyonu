using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;



public class Viraj : MonoBehaviour //5. Eğitim
{
    public GameObject basarili; 
    public GameObject basarisiz;
    public GameObject textBox;
    public GameObject Car;
    public GameObject trigger4, trigger5;//Success triggers
    //public GameObject triggerF6, triggerF7, triggerF8, triggerF9; //Fail trigger, F6 ve F7 = Sol, F8 ve F9 = sağ

    public CarController cc;

    public Vector3 PosIn = new Vector3(-247, 0, -421f);
    public Quaternion RotIn = new Quaternion(0, 200, 0, -60);

    public Text theText;
    public TextAsset []textFile;
    public string[] textLines;
    public int saveLine, currentLine, endAtLine, training;

    public Voices voice;

    public InputActionAsset inputActions;
    InputActionMap gameplay;
    InputAction NInput, MInput;

    private void Awake()
    {
        gameplay = inputActions.FindActionMap("Gameplay");
        NInput = gameplay.FindAction("N Button");
        MInput = gameplay.FindAction("M Button");

        NInput.performed += NInput_performed; ;
        MInput.performed += MInput_performed;
    }

    private void NInput_performed(InputAction.CallbackContext obj)
    {
        if (currentLine == 4 || currentLine == 5)
        {
            Car.gameObject.GetComponent<CarController>().enabled = true;
            currentLine++;

            if (currentLine == 6)
            {
                Car.gameObject.GetComponent<CarController>().enabled = true;

            }
        }

        else
        {
            currentLine++;
            Car.gameObject.GetComponent<CarController>().enabled = true;
            /*if (currentLine == 7)
                basariliText();
            */
        }
        voice.CallVoice();

    }

    private void MInput_performed(InputAction.CallbackContext obj)
    {
        basarisiz.SetActive(true);
        clearScreen();
    }

    private void OnEnable()
    {
        NInput.Enable();
        MInput.Enable();
    }
    private void OnDisable()
    {
        NInput.Disable();
        MInput.Disable();
    }
    /*public Collider CarCollider;
    public Collider TriggerCol1, TriggerCol2;*/
    // Start is called before the first frame update
    void Start()
    {
        Car.transform.SetPositionAndRotation(PosIn, RotIn);
        if (textFile[SahneGecisKontrol.lang] != null)
        {
            textLines = (textFile[SahneGecisKontrol.lang].text.Split('\n'));
        }
        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }
        Car.gameObject.GetComponent<CarController>().enabled = false;
        //chooseTraining();
    }

    // Update is called once per frame
    void Update()
    {
        cc.kontak = true;
        cc.currentvites = otoviteslevels.DRIVE;
        cc.elfrenicekili = false;
        cc.elFreniUyari.SetActive(false);
        theText.text = textLines[currentLine];        
    }
    public void basariliText()
    {/*
        if (Input.GetKeyDown(KeyCode.N))
        {
            basarili.SetActive(true);
            clearScreen();
        }*/
    }
    public void clearScreen()
    {
        textBox.SetActive(false);
    }
    /*
    public void chooseTraining()
    {
        training = (int)Random.Range(0, 2);
        if (training == 1)//Sola dönüş için gereksiz triggerları kaldır
        {
            trigger4.SetActive(false);
            triggerF8.SetActive(false);
            triggerF9.SetActive(false);
        }
        else //Sağa dönüş için gereksiz triggerları kaldır
        {
            trigger5.SetActive(false);
            trigger6.SetActive(false);
            triggerF6.SetActive(false);
            triggerF7.SetActive(false);
        }
        Debug.Log("training = " + training);
    }

    private IEnumerator waitingSignal()
    {
        if (currentLine == 10)
            yield return waitForKeyPress(KeyCode.L);
        else if (currentLine == 14)
            yield return waitForKeyPress(KeyCode.K);
    }
    */
    private IEnumerator waitForKeyPress(KeyCode key)
    {
        bool done = false;
        while (!done) // essentially a "while true", but with a bool to break out naturally
        {
            if (Input.GetKeyDown(key))
            {
                done = true; // breaks the loop
            }
            yield return null; // wait until next frame, then continue execution from here (loop continues)
        }

        // now this function returns
    }
}
