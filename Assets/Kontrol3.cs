using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kontrol3 : MonoBehaviour
{
    public OncelikGecisEgitim oncelik;
    public TextAsset[] textFile;//uarı dosyasını yukle
    public string[] textLines;//uyarı dosyasındaki her bir satır
    public Text theText;//uyarının görüntülenecegi kısım
    public GameObject ilkgoster;
    public GameObject uyarıgos;
    int endAtLine;
    public int current=2 ;
    
    public static int sorun = 0;
    public static int tekrar = 1;
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
          
        if (tekrar == 1)
        {
            if (other.gameObject.tag == "car")//diger araç 
            {

                StartCoroutine(fonksiyon());
                Debug.Log("yanlıs");
                sorun = 2;

            }
            else
            {
                oncelik.currentLine++;
                oncelik.voice.CallVoice();
            }

            tekrar++;
        }
        }
    IEnumerator fonksiyon()
    {
        ilkgoster.SetActive(false);



        uyarıgos.SetActive(true);
        theText.text = textLines[current];
        oncelik.sorun = current +1;
        oncelik.voice.CallVoice();
        oncelik.sorun = 0;

        yield return new WaitForSeconds(4f);
        ilkgoster.SetActive(true);
        uyarıgos.SetActive(false);



    }
}

