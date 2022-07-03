using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class egitim0101manager : MonoBehaviour
{//egitim_01-01 icin tasarlandi
    public GameObject textBox;
    public GameObject basarili;
    public GameObject basarisiz;
    public GameObject gearPanel;
    public GameObject tamamlaUyari;
    public GameObject dikizAynasi;
    public GameObject solAyna;

    public Text theText;

    public bool egitimtamamlandi=false;

    public TextAsset []textFile;
    public string[] textLines;


    public int currentLine;
    public int endAtLine;

    [SerializeField] private CarController carController;

    public Voices voice;
    public InputActionAsset inputActions;
    InputActionMap gameplay;
    InputAction NInput, MInput;

    private void Awake()
    {
        gameplay = inputActions.FindActionMap("Gameplay");
        NInput = gameplay.FindAction("N Button");
        MInput = gameplay.FindAction("M Button");

        NInput.performed += NInput_performed;
        MInput.performed += MInput_performed;
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

    private void NInput_performed(InputAction.CallbackContext obj)
    {
        if (currentLine == 0 || currentLine == 2 || currentLine == 3)
        {
            currentLine++;
        }
        if (currentLine == 1 && carController.kontak)
        {
            currentLine++;
        }
        else if (currentLine == 4 && carController.currentvites.Equals(otoviteslevels.NEUTRAL))
        {
            currentLine++;
        }
        else if (currentLine == 5 && carController.currentvites.Equals(otoviteslevels.DRIVE) && !carController.elfrenicekili)
        {
            currentLine++;
        }
        else if (currentLine == 6 && carController.speed > 10)
        {
            currentLine++;
        }
        else if (currentLine == 7 && carController.speed < 5)
        {
            currentLine++;
        }
        else if (currentLine == 8 && carController.currentvites.Equals(otoviteslevels.REVERSE))
        {
            currentLine++;
        }
        else if (currentLine == 9 && carController.currentvites.Equals(otoviteslevels.PARK) && carController.elfrenicekili)
        {
            currentLine++;
        }
        else if (currentLine == 10 && !carController.kontak)
        {//basarili
            currentLine++;
            egitimtamamlandi = true;
            basarili.SetActive(true);
            //clearScreen();
        }
        voice.CallVoice();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        if(textFile[SahneGecisKontrol.lang] != null){
            textLines=(textFile[SahneGecisKontrol.lang].text.Split('\n'));
        }

        if(endAtLine==0){
            endAtLine=textLines.Length -1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        theText.text = textLines[currentLine];
        
    }

    public void clearScreen(){
        textBox.SetActive(false);
        gearPanel.SetActive(false);
        dikizAynasi.SetActive(false);
        solAyna.SetActive(false);
    }
}
