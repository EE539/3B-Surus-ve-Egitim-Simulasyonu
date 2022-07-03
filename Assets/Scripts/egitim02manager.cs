using System.Threading;
using System.IO;
using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random=UnityEngine.Random;
using UnityEngine.InputSystem;


public enum egitimStages
{
    ONL, ARKAL, PARALEL
}

public class egitim02manager : MonoBehaviour//this code only works with egitim02
{
    
    //general variables
    [SerializeField] private CarController carController;
    [SerializeField] private parkAlaniTrigger[] parkalaniTrigger; 
    [SerializeField] private parkAlaniTrigger[] parkalaniTrigger2;
    [SerializeField] private parkAlaniTrigger[] parkalaniTrigger3;
    [SerializeField] private parkAlaniTrigger[] paralelParkAlaniTriggers;
    public GameObject[] parkAlani;
    public GameObject[] parkAlani2;
    public GameObject[] parkAlani3;
    public GameObject[] paralelParkAlani;
    public GameObject[] parkAlaniDubalar;
    public GameObject[] parkAlani2Dubalar;
    public GameObject[] parkAlani3Dubalar;
    public GameObject[] paralelParkAlaniDubalar;
    public int length;
    public bool egitimtamamlandi=false;
    public int otoPark;
    public int secilenPark;
    public egitimStages egitimCurrentStage=egitimStages.ONL;

    //transform the car variables
    [SerializeField] public GameObject carObject;
    [SerializeField] private Vector3 posIn = new Vector3(0, 0, 0);
    [SerializeField] private Quaternion rotIn = new Quaternion(0, 0, 0, 0);

    //egitim text variables
    public Text theText;
    public TextAsset []onLParkTextFile;
    public TextAsset []arkaLParkTextFile;
    public TextAsset []paralelParkTextFile;
    public string[] onLParkTextLines;
    public string[] arkaLParkTextLines;
    public string[] paralelParkTextLines;
    public int currentLine;

    //panel object variables
    public GameObject basarili;
    public GameObject basarisiz;
    public GameObject gearPanel;
    public GameObject dikizAynasi;
    public GameObject solAyna;
    public GameObject textBox;
    public GameObject tamamlaUyari;

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
    private void NInput_performed(InputAction.CallbackContext obj)
    {
        switch (egitimCurrentStage)
        {
            case egitimStages.ONL://Ön L Park Stage

                theText.text = onLParkTextLines[currentLine];

                if (currentLine == 0)
                {
                    currentLine++;
                }
                else if (currentLine == 1 && carController.speed > 5)
                {
                    currentLine++;
                }
                else if(currentLine == 2 && onLhataKontrol()){
                    theText.text = "Park alanına hatalı giriş yapıldı. Ön L Park yeniden başlatılıyor";
                    parkAlanlariniKapat();
                    chooseParkingLotforLPark();
                    currentLine = 0;
                }
                else if (currentLine == 2 && onLKontrol())
                {//stage basarili
                    parkAlanlariniKapat();
                    chooseParkingLotforLPark();
                    egitimCurrentStage = egitimStages.ARKAL;
                    currentLine = 0;
                    voice.CallVoice();
                }
                break;

            case egitimStages.ARKAL://Arka L Park Stage
                theText.text = arkaLParkTextLines[currentLine];

                if (currentLine == 0)
                {
                    currentLine++;
                }
                else if (currentLine == 1 && carController.speed > 5)
                {
                    currentLine++;
                }
                else if(currentLine == 2 && arkaLhataKontrol()){
                    theText.text = "Park alanına hatalı giriş yapıldı. Arka L Park yeniden başlatılıyor";
                    parkAlanlariniKapat();
                    chooseParkingLotforLPark();
                    currentLine = 0;
                }
                else if (currentLine == 2 && arkaLKontrol())
                {//stage basarili
                    parkAlanlariniKapat();
                    chooseParkingLotforParalelPark();
                    egitimCurrentStage = egitimStages.PARALEL;
                    currentLine = 0;
                }
                break;

            case egitimStages.PARALEL://Paralel Park Stage
                theText.text = paralelParkTextLines[currentLine];

                if (currentLine == 0 || currentLine == 1)
                {
                    currentLine++;
                }
                else if (currentLine == 2 && carController.currentvites == otoviteslevels.REVERSE)
                {
                    currentLine++;
                }
                else if (currentLine == 3 && paralelParkAlaniTriggers[secilenPark].ilkRear)
                {
                    currentLine++;
                }
                else if (paralelParkAlaniTriggers[secilenPark].ilkFront)
                {//wrong entry error
                    theText.text = "Park alanına yanlış girdiniz. Yeniden deneyiniz.";
                    parkAlanlariniKapat();
                    chooseParkingLotforParalelPark();
                }
                else if (currentLine == 4 && paralelParkAlaniTriggers[secilenPark].frontParkEdiliMi && paralelParkAlaniTriggers[secilenPark].rearParkEdildiMi)
                {//stage basarili end egitim
                    basarili.SetActive(true);
                    textBox.SetActive(false);
                    egitimtamamlandi = true;
                }
                break;
        }
        voice.CallVoice();
    }

    private void MInput_performed(InputAction.CallbackContext obj)
    {
        basarisiz.SetActive(true);
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
        if(onLParkTextFile[SahneGecisKontrol.lang] != null){
            onLParkTextLines=(onLParkTextFile[SahneGecisKontrol.lang].text.Split('\n'));
        }
        if(arkaLParkTextFile[SahneGecisKontrol.lang] != null){
            arkaLParkTextLines=(arkaLParkTextFile[SahneGecisKontrol.lang].text.Split('\n'));
        }
        if(paralelParkTextFile[SahneGecisKontrol.lang] != null){
            paralelParkTextLines=(paralelParkTextFile[SahneGecisKontrol.lang].text.Split('\n'));
        }
        carController.kontak=true;
        carController.currentvites=otoviteslevels.DRIVE;
        carController.elfrenicekili=false;
        chooseParkingLotforLPark();
        theText.text = onLParkTextLines[currentLine];
    }

    private void Update()
    {
        switch (egitimCurrentStage)
        {
            case egitimStages.ONL://Ön L Park Stage

                theText.text = onLParkTextLines[currentLine];
                break;

            case egitimStages.ARKAL://Arka L Park Stage
                theText.text = arkaLParkTextLines[currentLine];
                break;

            case egitimStages.PARALEL://Paralel Park Stage
                theText.text = paralelParkTextLines[currentLine];
                break;
        }
    }
    void chooseParkingLotforLPark(){
        otoPark = Random.Range(0, 3);//choosing parking lot
        switch(otoPark){
            case 0:
            length=parkAlani.Length;
            secilenPark = Random.Range(0, length);
            parkAlani[secilenPark].SetActive(true);
            parkAlaniDubalar[secilenPark].SetActive(true);
            posIn = new Vector3(-90,2,-110);
            rotIn = new Quaternion(0,91,0,30);
            carObject.transform.SetPositionAndRotation(posIn, rotIn);
            break;
            case 1:
            length=parkAlani2.Length;
            secilenPark = Random.Range(0, length);
            parkAlani2[secilenPark].SetActive(true);
            parkAlani2Dubalar[secilenPark].SetActive(true);
            posIn = new Vector3(-201,1,-256);
            rotIn = new Quaternion(0,91,0,30);
            carObject.transform.SetPositionAndRotation(posIn, rotIn);
            break;
            case 2:
            length=parkAlani3.Length;
            secilenPark = Random.Range(0, length);
            parkAlani3[secilenPark].SetActive(true);
            parkAlani3Dubalar[secilenPark].SetActive(true);
            posIn = new Vector3(-207,1,-308);
            rotIn = new Quaternion(0,0,0,30);
            carObject.transform.SetPositionAndRotation(posIn, rotIn);
            carObject.transform.Rotate(0, 280, 0);
            break;
        }
    }

    void chooseParkingLotforParalelPark(){
        length=paralelParkAlani.Length;
        secilenPark = Random.Range(0, length);
        paralelParkAlani[secilenPark].SetActive(true);
        paralelParkAlaniDubalar[secilenPark].SetActive(true);
        switch(secilenPark){
            case 0:
            posIn = new Vector3(-227,1,-194);
            rotIn = new Quaternion(0,0,0,0);
            carObject.transform.SetPositionAndRotation(posIn, rotIn);
            carObject.transform.Rotate(0, 236, 0);   
            break;
            case 1:
            posIn = new Vector3(-239,1,-201);
            rotIn = new Quaternion(0,0,0,0);
            carObject.transform.SetPositionAndRotation(posIn, rotIn); 
            carObject.transform.Rotate(0, 54, 0); 
            break;
            case 2:
            posIn = new Vector3(-195,1,-350);
            rotIn = new Quaternion(0,0,0,0);
            carObject.transform.SetPositionAndRotation(posIn, rotIn);
            carObject.transform.Rotate(0, -31, 0); 
            break;
        } 
    }

    void parkAlanlariniKapat(){
        switch(otoPark){
            case 0:
            parkAlani[secilenPark].SetActive(false);
            parkAlaniDubalar[secilenPark].SetActive(false);
            break;
            case 1:
            parkAlani2[secilenPark].SetActive(false);
            parkAlani2Dubalar[secilenPark].SetActive(false);
            break;
            case 2:
            parkAlani3[secilenPark].SetActive(false);
            parkAlani3Dubalar[secilenPark].SetActive(false);
            break;
        }
        paralelParkAlani[secilenPark].SetActive(false);
        paralelParkAlaniDubalar[secilenPark].SetActive(false);
    }

    Boolean onLKontrol(){
        switch(otoPark){
            case 0://otopark 1
            if(parkalaniTrigger[secilenPark].frontParkEdiliMi 
                && parkalaniTrigger[secilenPark].rearParkEdildiMi  
                && parkalaniTrigger[secilenPark].ilkFront){
                return true;
            }
            break;

            case 1://otopark 2
            if(parkalaniTrigger2[secilenPark].frontParkEdiliMi 
                && parkalaniTrigger2[secilenPark].rearParkEdildiMi 
                && parkalaniTrigger2[secilenPark].ilkFront){
                return true;
            }
            break;

            case 2://otopark 3
            if(parkalaniTrigger3[secilenPark].frontParkEdiliMi 
                && parkalaniTrigger3[secilenPark].rearParkEdildiMi 
                && parkalaniTrigger3[secilenPark].ilkFront){
                return true;
            }
            break;
        }
        return false;
    }

    Boolean onLhataKontrol(){
        switch(otoPark){
            case 0://otopark 1
            if(parkalaniTrigger[secilenPark].frontParkEdiliMi 
                && parkalaniTrigger[secilenPark].rearParkEdildiMi  
                && parkalaniTrigger[secilenPark].ilkRear){
                return true;
            }
            break;

            case 1://otopark 2
            if(parkalaniTrigger2[secilenPark].frontParkEdiliMi 
                && parkalaniTrigger2[secilenPark].rearParkEdildiMi 
                && parkalaniTrigger2[secilenPark].ilkRear){
                return true;
            }
            break;

            case 2://otopark 3
            if(parkalaniTrigger3[secilenPark].frontParkEdiliMi 
                && parkalaniTrigger3[secilenPark].rearParkEdildiMi 
                && parkalaniTrigger3[secilenPark].ilkRear){
                return true;
            }
            break;
        }
        return false;
    }

    Boolean arkaLKontrol(){
        switch(otoPark){
            case 0://otopark 1
            if(parkalaniTrigger[secilenPark].frontParkEdiliMi 
            && parkalaniTrigger[secilenPark].rearParkEdildiMi 
            && parkalaniTrigger[secilenPark].ilkRear){
                return true;
            }
            break;

            case 1://otopark 2
            if(parkalaniTrigger2[secilenPark].frontParkEdiliMi 
            && parkalaniTrigger2[secilenPark].rearParkEdildiMi 
            && parkalaniTrigger2[secilenPark].ilkRear){
                return true;
            }
            break;

            case 2://otopark 3
            if(parkalaniTrigger3[secilenPark].frontParkEdiliMi 
            && parkalaniTrigger3[secilenPark].rearParkEdildiMi 
            && parkalaniTrigger3[secilenPark].ilkRear){
                return true;
            }
            break;
        }
        return false;
    }

    Boolean arkaLhataKontrol(){
        switch(otoPark){
            case 0://otopark 1
            if(parkalaniTrigger[secilenPark].frontParkEdiliMi 
            && parkalaniTrigger[secilenPark].rearParkEdildiMi 
            && parkalaniTrigger[secilenPark].ilkFront){
                return true;
            }
            break;

            case 1://otopark 2
            if(parkalaniTrigger2[secilenPark].frontParkEdiliMi 
            && parkalaniTrigger2[secilenPark].rearParkEdildiMi 
            && parkalaniTrigger2[secilenPark].ilkFront){
                return true;
            }
            break;

            case 2://otopark 3
            if(parkalaniTrigger3[secilenPark].frontParkEdiliMi 
            && parkalaniTrigger3[secilenPark].rearParkEdildiMi 
            && parkalaniTrigger3[secilenPark].ilkFront){
                return true;
            }
            break;
        }
        return false;
    }

}
