using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SahneGecisKontrol : MonoBehaviour
{
    public static bool activategoVites = false;
    public static bool returnFromTraining = false;
    public TamamlandiMesaj bClick;
    public GameObject pop;
    private GameObject geri, saveObj = null, save = null;
    public List<GameObject> Sahneler = new List<GameObject>();

    public TextMeshProUGUI [] theText;
    public Dropdown language;
    [HideInInspector] public static int lang = 0;
    public TextAsset [] langFiles;
    public string[] textLines;
    public int saveLine, currentLine, endAtLine, training;
    //public GameObject giris, kayit, kgiris, ayarlar_kullanıcısız, ayarlar_kullanıcılı, vites, ess, es; //ess = eğitim sınav serbest sürüş, es = eğitim seçim
    public void goGiris() //Giriş Sayfası
    {
        CheckIfAnyActive();
        Sahneler[0].SetActive(true);
    }
    public void goKayit() //Kayıt Sayfası
    {
        CheckIfAnyActive();
        Sahneler[1].SetActive(true);
    }
    public void goKGiris()//Kullanıcı giriş
    {
        Debug.Log("goKGiris");
        StartCoroutine(WaitABit("giris"));
        
    }
    public void goKOncesiAyarlar() // Kullanıcı Sisteme Girmeden Önce Ayarlar
    {
        CheckIfAnyActive();
        Sahneler[3].SetActive(true);
    }
    public void goKSonrasıAyarlar() //Kullanıcı Sisteme Girdikten Sonra Ayarlar
    {
        CheckIfAnyActive();
        Sahneler[4].SetActive(true);
    }
    public void goVites() //Vites Seçimi
    {
        StartCoroutine(WaitABit("vites"));   
    }
    public void goESS() //Eğitim Sınav Seçim
    {
        CheckIfAnyActive();
        Sahneler[6].SetActive(true);
    }

    public void goES()//Eğitim Seçimi
    {
        CheckIfAnyActive();
        Sahneler[7].SetActive(true);
    }

    public void goKDegistir() //Kullanıcı adı değiştirme sayfası
    {
        CheckIfAnyActive();
        Sahneler[8].SetActive(true);
    }
    public void goSDegistir() //Şifre Değiştirme Sayfası
    {
        CheckIfAnyActive();
        Sahneler[9].SetActive(true);
    }

    public void GeriButton()
    {
        if (Sahneler[4].activeSelf && !string.IsNullOrEmpty(EnterDatabase.user))
        {
            CheckIfAnyActive();
            Sahneler[5].SetActive(true);
        }
        else
        {
            saveObj = geri;
            CheckIfAnyActive();
            geri = saveObj;
            geri.SetActive(true);
            findPrevOne();
            geri = saveObj;
        }
        
    }

    public void CheckIfAnyActive()
    {
        foreach (GameObject sahne in Sahneler)
        {
            if (sahne.activeSelf)
            {
                geri = sahne;
                sahne.SetActive(false);
                break;
            }

        }
    }

    private void findPrevOne()
    {
        foreach (GameObject sahne in Sahneler)
        {
                if (GameObject.ReferenceEquals(sahne, saveObj) && !GameObject.ReferenceEquals(sahne, Sahneler[0]))
            {
                saveObj = save;
                break;
            }
            save = sahne;
        }
    }

    IEnumerator WaitABit(string sahne)
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log(pop.activeSelf);
        if (string.Equals(sahne, "vites"))
        {
            Debug.Log( "1");
            if (pop.activeSelf) { }
            else
            {
                CheckIfAnyActive();
                Sahneler[5].SetActive(true);
            }
                
        }
        else if(string.Equals(sahne, "giris"))
        {
            Debug.Log("entered giris 2");
            if (pop.activeSelf) { }
            else
            {
                Debug.Log("Im here! 3");
                CheckIfAnyActive();
                Sahneler[2].SetActive(true);
            }
                
        }
    }

    public void FixedUpdate()
    {
        if (bClick.buttonClicked)
        {
            goKGiris();
            bClick.buttonClicked = false;
        }
        if (activategoVites)
        {
            CheckIfAnyActive();
            Sahneler[5].SetActive(true);
            activategoVites = false;
        }
        if (returnFromTraining)
        {
            goES();
            returnFromTraining = false;
        }

    }
    public void Update()
    {
        language.onValueChanged.AddListener(delegate {
            Language();
        });
    }
    public void Language()
    {
        if (langFiles[language.value] != null)
        {
            textLines = (langFiles[language.value].text.Split('\n'));
        }
        for (int count = 0; count < textLines.Length; count++)
        {
            theText[count].text = textLines[count];
        }
        lang = language.value;
    }
}
