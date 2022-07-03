using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public GameObject weathermanager;
    public Dropdown res;
    public GameObject option;
    public AudioMixer mainMixer;
    public List<ResItems> resolution = new List<ResItems>();
    [SerializeField] private Slider volumeSlider = null; //will help us to load volume's value in the slider

    public TextMeshProUGUI[] theText;
    public TextAsset[] textFile;
    public string[] textLines;
    public void Start()
    {
        if (textFile[SahneGecisKontrol.lang] != null)
        {
            textLines = (textFile[SahneGecisKontrol.lang].text.Split('\n'));
        }
        for (int count = 0; count < textLines.Length; count++)
        {
            theText[count].text = textLines[count];
        }
        LoadValues();
        findScreenSize();
    }
    public void SetVolume(float volume)
    {
        mainMixer.SetFloat("volume", volume);
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("volume", volumeValue);
        LoadValues();
    }

    public void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("volume");
        volumeSlider.value = volumeValue;
    }

    public void findScreenSize()
    {
        int count = 0;
        if (Screen.fullScreen)
            res.value = count;
        else
        {
            while (resolution[count].horizontal != null)
            {
                if (resolution[count].horizontal == Screen.width)
                {
                    res.value = count + 1;
                    break;
                }
                count++;
            }
        }
    }

    public void WeatherManager(bool isChecked)
    {
        weathermanager.SetActive(isChecked);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetVsync(bool isVsync)
    {
        if (isVsync)
            QualitySettings.vSyncCount = 1;
        else
            QualitySettings.vSyncCount = 0;
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void setResolution(int resIndex)
    {
        if (resIndex == 0)
        {
            Screen.SetResolution(resolution[resIndex].horizontal, resolution[resIndex].vertical, true);
        }
            
        else
        {
            Screen.SetResolution(resolution[resIndex-1].horizontal,resolution[resIndex-1].vertical, false);
        }
    }

    [System.Serializable] //Let system know how to handle the class below
    public class ResItems
    {
        public int horizontal, vertical;
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        option.gameObject.SetActive(false);

    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        option.gameObject.SetActive(false);
        SahneGecisKontrol.activategoVites = true;
        SceneManager.LoadScene("Arayüz");
        MenuMusic.Instance.gameObject.GetComponent<AudioSource>().Play();
    }
    /*public void Update()
    {
        Debug.Log(QualitySettings.GetQualityLevel());// shows quality level in teh unity
    }*/
}
