using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tamEgitimManager : MonoBehaviour
{
    public GameObject[] egitimler;
    public egitim0101manager egitim01;
    public egitim02manager egitim02;
    public OncelikGecisEgitim egitim03;
    public kavsak egitim04;
    public VirajTriggerSuccess egitim05;
    public int egitimcounter = 0;
    public GameObject basarili;

    // Start is called before the first frame update
    void Start()
    {
        egitimcounter = 0;
        egitimler[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (egitimcounter == 0 && egitim01.egitimtamamlandi)
        {//sürüş kalkış=0
            egitimler[0].SetActive(false);
            egitimler[1].SetActive(true);
            egitimcounter = 1;
        }
        if (egitimcounter == 1 && egitim02.egitimtamamlandi)
        {//park=1
            egitimler[1].SetActive(false);
            egitimler[2].SetActive(true);
            egitimcounter = 2;
        }
        if(egitimcounter == 2 && egitim03.egitimtamamlandi)
        {//oncelik
            egitimler[2].SetActive(false);
            egitimler[3].SetActive(true);
            egitimcounter = 3;
        }
        if (egitimcounter == 3 && egitim04.egitimtamamlandi)
        {//kavşak=2
            egitimler[3].SetActive(false);
            egitimler[4].SetActive(true);
            egitimcounter = 4;
        }
        if (egitimcounter == 4 && egitim05.egitimtamamlandi)
        {//viraj=3
            egitimler[4].SetActive(false);
            basarili.SetActive(true);
        }
        
    }
}