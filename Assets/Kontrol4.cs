using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kontrol4 : MonoBehaviour
{
    public OncelikGecisEgitim oncelik;
    public TextAsset []textFile;//uarı dosyasını yukle
    public string[] textLines;//uyarı dosyasındaki her bir satır
    public Text theText;//uyarının görüntülenecegi kısım
    public GameObject ilkgoster;
    public GameObject uyarıgos;
    int endAtLine;
    public int current = 3;

    public static int sorun = 3;
    public  static int carsayac=0;

    public static int tekrar = 1;

   
    //daha sonra silersin
    Collision y;
    private void Start()
    {
        if (textFile[SahneGecisKontrol.lang] != null)
        {
            textLines = (textFile[SahneGecisKontrol.lang].text.Split('\n'));
        }
        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
            // current = endAtLine;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("TRİGGER'A GİRDİM ve tekrar sayısı "+tekrar);
        Debug.Log("trigger'a giren : " + other.gameObject.name);
        if (tekrar == 1)
        {
            if (other.gameObject.tag != "car" && carsayac != 2)//diger araç 
            {

                StartCoroutine(fonksiyon());
                Debug.Log("yanlıs");
                sorun = 5;
                carsayac = 0;
             

            }
            if (other.gameObject.tag == "car")
            {

                carsayac++;
                if (carsayac == 1)
                {
                    oncelik.currentLine++;//13->14
                    oncelik.voice.CallVoice();
                    Debug.Log("aha ilki çalıstı.ikinciside calısır umarım " + oncelik.currentLine + " car sayac " + carsayac);
                    Debug.Log("DOGRU 1");
                    Debug.Log("trigger'a car 1 ken giren : " + other.gameObject.name);

                }

              else
                {
                    oncelik.currentLine++;//14->15
                    oncelik.voice.CallVoice();
                    Debug.Log("aha ikiside dogru calıstı.İste simdi sıra bizde " + oncelik.currentLine + " car sayac " + carsayac);
                    Debug.Log("DOGRU 2");
                    Debug.Log("trigger'a car 2 ken giren : " + other.gameObject.name);
                }
                
                Debug.Log("car sayac :"+carsayac);
              
            }
         
            if (other.gameObject.tag != "car" && carsayac==2)//diger araç 
            {


                oncelik.currentLine++;//çok guzel //15->16
                Debug.Log("ISTE SON " + oncelik.currentLine);
                oncelik.voice.CallVoice();
                tekrar++;
            }

        }
        Debug.Log("car sayac : " + carsayac );
        Debug.Log("tekrar : " + tekrar);
    }
    IEnumerator fonksiyon()
    {
        ilkgoster.SetActive(false);



        uyarıgos.SetActive(true);
        theText.text = textLines[current];
        oncelik.sorun = current + 1;
        oncelik.voice.CallVoice();
        oncelik.sorun = 0;
        yield return new WaitForSeconds(4f);
        ilkgoster.SetActive(true);
        uyarıgos.SetActive(false);



    }
}
