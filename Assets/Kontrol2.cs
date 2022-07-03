using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Kontrol2 : MonoBehaviour
{
    public OncelikGecisEgitim oncelik;
    public TextAsset []textFile;//uarı dosyasını yukle
    public string[] textLines;//uyarı dosyasındaki her bir satır
    public GameObject ilkgoster;
    public GameObject uyarıgos;
    public Text theText;
    int endAtLine;
    public int current = 1;
    public static int sorun=0;
    public  static int gir = 0;
    void Start()
    {
        if (textFile[SahneGecisKontrol.lang] != null)
        {
            textLines = (textFile[SahneGecisKontrol.lang].text.Split('\n'));
        }
        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }
    }


    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {

        if (gir == 0)
        {
            if (other.gameObject.tag != "car")
            {

                StartCoroutine(fonksiyon());
                Debug.Log("yanlıs");
                sorun = 1;
                

            }//yanlıs arac ilk  gelirse (bizim aracımız )  
            else
            {
                sorun = 0;
                oncelik.currentLine++;//
                oncelik.voice.CallVoice();
                gir++;
            }//doru agrac gelirse gir=1 olur ve text metnimiz bir ilerler


        }
        else if (gir == 1)//dogru arac gelirse text bir ilerlet
        {


            oncelik.currentLine++;//6 DA GİRECEKSİN DİREKT SENI 7 YAPACAK
            oncelik.voice.CallVoice();
            gir = 2;

        }


    }
    IEnumerator fonksiyon()
    {
        ilkgoster.SetActive(false);

        theText.text = textLines[current];//2.TEXT DOSYAM HATA MESAJLARI
        oncelik.sorun = current + 1;
        oncelik.voice.CallVoice();
        oncelik.sorun = 0;
        uyarıgos.SetActive(true);
        
       
        yield return new WaitForSeconds(3f);

        ilkgoster.SetActive(true);
        uyarıgos.SetActive(false);
      
    }
}
