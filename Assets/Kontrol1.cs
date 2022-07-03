using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Kontrol1 : MonoBehaviour
{
    public OncelikGecisEgitim oncelik;//oncelik texti
    public TextAsset []textFile;//uarı dosyasını yukle
    public  string[] textLines;//uyarı dosyasındaki her bir satır
    public  Text theText;//uyarının görüntülenecegi kısım
    public GameObject ilkgoster;
    public GameObject uyarıgos;
    int endAtLine;
    public  int currentLine=0;
   
     private  int tek=1;
    
    private void Start()
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
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("collision girdim");
        if (tek == 1)
        {
            if (other.gameObject.tag == "car")
            { 
                StartCoroutine(fonksiyon());
                Debug.Log("yanlıs");

            }
            else
            {
                Debug.Log("dogru arac geldi");
                oncelik.currentLine++;
                Debug.Log("currentLine: "+oncelik.currentLine);
                oncelik.voice.CallVoice();
                
            }

            tek++;
        }
    }
    IEnumerator fonksiyon()
    {
        ilkgoster.SetActive(false);
        uyarıgos.SetActive(true);
        theText.text = textLines[currentLine];
        oncelik.sorun = tek;
        oncelik.voice.CallVoice();
        oncelik.sorun = 0;
        yield return new WaitForSeconds(3f);
      
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }


}
