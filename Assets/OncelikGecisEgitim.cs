using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class OncelikGecisEgitim : MonoBehaviour
{
    public bool egitimtamamlandi=false;

    //4 yol agzı
    //3 yol agzı 
    public GameObject textBox;
  
    public GameObject gearPanel;
   
    public GameObject dikizAynasi;
    public GameObject solAyna;
    public GameObject saat;
    //-------------------
    public GameObject araba;
    public GameObject yardımcı_araba;
    public Transform[] bolgeler = new Transform[3];//arabaların ışınlanacagı yer.
                                                   //   public Transform[] ybolgeler = new Transform[1]; 
    public Transform[] y_bolgeler = new Transform[3];

    public TextAsset []textFile;//bu sayede direkt ınspector kısmından atama yapabiliriz.
    public string[] textLines;//dosyanın her bir satırı
    public Text theText;// komutları ekranda çıkarmak için 

    public int currentLine = 0;
    private int endAtLine = 0;

    public GameObject basarili;
    public GameObject basarisiz;
    public Animator tut;
    public Animator tut2;
    public Animator tut3;
    public Animator tut4;
    public Animator tut5;
    public int sorun = 0;
    int ray = 1;

     private int i = 0;
    private int j = 0;

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
        if (currentLine == 0 || currentLine == 1 || currentLine == 4 || currentLine == 8 || currentLine == 11 || currentLine == 12) //current12 yni degerdeki yolların birleştigi kavşaklarda  soldan gelen araçlar  sağdan gelen araçlara geçiş hakkını vermek zorundadır
        {


            currentLine++;
        }
        if (currentLine == 2)
        {
            StartCoroutine(fonk());
        }
        if (currentLine == 3)
        {

            ArabaIsınlama(1);
            currentLine++;
        }//2.aşamaya gecerken

        if (currentLine == 5)
        {
            Debug.Log("araba  anımı baslaaycak");
            StartCoroutine(fonk2());//2.araba anımasoyunu //sorun 
        }


        if (currentLine == 7)
        {
            ArabaIsınlama(2);

            currentLine++;
        }//3.aşamaya gecerken

        if (currentLine == 9)
        {

            StartCoroutine(fonk3());

        }
        if (currentLine == 10)//Şimdi son kısım

        {
            ArabaIsınlama(3);
            currentLine++;
        }
        if (currentLine == 13)
        {//Bu durumda ilk sedan gecer.
            Debug.Log("aga sorunlu yere geldik!!!");
            StartCoroutine(fonk4());

        }
        if (currentLine == 14)//İkinci olara mercedes gecer.
        {
            Debug.Log("aga ikinci sorunlu yere geldik!!!");
            StartCoroutine(fonk5());

        }
        if (currentLine == 16)
        {
            basarili.SetActive(true);
            egitimtamamlandi=true;
            clearScreen();
        }
        voice.CallVoice();
        Debug.Log("current line : " + currentLine);
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
    void Start()
    {



        tut.gameObject.GetComponent<Animator>().enabled = false;
        tut2.gameObject.GetComponent<Animator>().enabled = false;
        tut3.gameObject.GetComponent<Animator>().enabled = false;
        tut4.gameObject.GetComponent<Animator>().enabled = false;
        tut5.gameObject.GetComponent<Animator>().enabled = false;

        ArabaYeri();



        if (textFile[SahneGecisKontrol.lang] != null)
        {
            textLines = (textFile[SahneGecisKontrol.lang].text.Split('\n'));
        }
        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }
    }

    public void ArabaYeri()
    {
        //  araba = Instantiate(araba, bolgeler[0].position, Quaternion.Euler(-1.96f, 231.8f, -0.91f));
        araba.transform.SetPositionAndRotation(bolgeler[0].position, Quaternion.Euler(-1.96f, 231.8f, -0.91f));




    }
    void Update()
    {
        theText.text = textLines[currentLine];
        Debug.Log("currentLine : " + currentLine);

        if (Kontrol2.sorun == 1)//tekrrardan bir onceki yer (2.sahne)
        {
            
            ArabaIsınlama(1);
            currentLine = 4;

            StartCoroutine(fonk2());
            //Debug.Log("CURRENTLİNE: " + currentLine);
            Kontrol2.sorun = 0;

        }

        if (Kontrol3.sorun == 2)////tekrrardan bir onceki yer (3.sahne)
        {
            //   Debug.Log("4 yol agzında hata var");
            ArabaIsınlama(2);
            currentLine = 8;
            //Animasyonu eski yerine koymam gerek
            tut3.transform.position = y_bolgeler[0].position;
            tut3.transform.rotation = Quaternion.identity;
            tut3.gameObject.GetComponent<Animator>().enabled = false;
          
            Kontrol3.sorun = 0;
            Kontrol3.tekrar = 1;

        }

        if (Kontrol4.sorun == 5)////tekrrardan bir onceki yer (3.sahne)
        {
            Debug.Log("4 yol agzında 2.hata var");
            ArabaIsınlama(3);
            currentLine = 11;
            //Animasyonu eski yerine koymam gerek
            Quaternion rot = new Quaternion();
            rot.eulerAngles = new Vector3(0f, 222.609f, -0.001f);
            

            tut4.transform.position = y_bolgeler[1].position;//sedan
            tut4.transform.rotation = rot;
           tut4.gameObject.GetComponent<Animator>().enabled = false;



            rot.eulerAngles = new Vector3(0f, -44.086f, -0.001f);
            tut5.transform.position = y_bolgeler[2].position;
            tut5.transform.rotation = rot;
            tut5.gameObject.GetComponent<Animator>().enabled = false;

            Kontrol4.sorun = 0;
            Kontrol4.tekrar = 1;
            Kontrol4.carsayac = 0;

        }
        //Debug.Log("currentt " + currentLine);
    }
  
    IEnumerator fonk3()
    {
        yield return new WaitForSeconds(10f);

       
        if (Kontrol3.sorun == 2)
        {
            Debug.Log("SORUNA GİRDİK");
           
            yield return new WaitForSeconds(10f);
        }
        if (currentLine == 9)
        {
            tut3.gameObject.GetComponent<Animator>().enabled = true;
        }

        Kontrol3.sorun = 0;
    }
    IEnumerator fonk()
    {
        yield return new WaitForSeconds(15f);

      //  Debug.Log("ANİM BAŞLAYACAK");
        tut.gameObject.GetComponent<Animator>().enabled = true;

    }

    IEnumerator fonk2()
    {
      
        yield return new WaitForSeconds(10f);
        if (Kontrol2.sorun == 1)
        {
            tut4.Play("4yolsedan_3", -1, 0f);
            yield return new WaitForSeconds(10f);
        }
        if (currentLine == 5)
        {
          
            tut2.gameObject.GetComponent<Animator>().enabled = true;
           
        }

    }

    IEnumerator fonk4()//SEDAN
    {

        yield return new WaitForSeconds(4f);
        if (Kontrol4.sorun == 5)
        {

            yield return new WaitForSeconds(4f);
        }
        if (currentLine == 13)
        {

            tut4.gameObject.GetComponent<Animator>().enabled = true;
           

        }

    }

    IEnumerator fonk5()//MERCEDES
    {

        yield return new WaitForSeconds(3f);
        if (Kontrol4.sorun == 5)
        {

            yield return new WaitForSeconds(2f);
            Kontrol4.sorun = 0;
        }
        Debug.Log("currentLine mevecik : " + currentLine);
        if (currentLine == 14)
        {

            tut5.gameObject.GetComponent<Animator>().enabled = true;


        }

    }
    public void clearScreen()
    {
        currentLine = 0;
        textBox.SetActive(false);
        gearPanel.SetActive(false);
        dikizAynasi.SetActive(false);
        solAyna.SetActive(false);
        saat.SetActive(false);
    }
    public void ArabaIsınlama(int r)
    {
        araba.transform.position = bolgeler[r].position;
        if (r == 1)
        {
            Quaternion rot = new Quaternion();
            rot.eulerAngles = new Vector3(0.31f, -27.293f, 0.002f);
            araba.transform.rotation = rot;

        }
        if (r == 2)
        {
            Quaternion rot = new Quaternion();
            rot.eulerAngles = new Vector3(0.31f, -107.794f, 0.002f);
            araba.transform.rotation = rot;
        }
        if (r == 3)
        {
            Quaternion rot = new Quaternion();
            rot.eulerAngles = new Vector3(-0.391f, 401.25f, 0.002f);
            araba.transform.rotation = rot;
        }

        araba.GetComponent<CarController>().currentvites = otoviteslevels.PARK;
        //Debug.Log("ISINLANIYOR MU");
    }
}

