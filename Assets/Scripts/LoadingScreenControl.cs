using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class LoadingScreenControl : MonoBehaviour
{
    public GameObject loadingScreenObj;
    public Slider slider;
    
    AsyncOperation async;

    public TextMeshProUGUI loadtxt;
    private void Start()
    {
        if (SahneGecisKontrol.lang == 1)
            loadtxt.text = "LOADING...";
        else
            loadtxt.text = "YÜKLENİYOR...";
        StartCoroutine(LoadingSceen());
    }

    IEnumerator LoadingSceen()
    {

        loadingScreenObj.SetActive(true);
        async = SceneManager.LoadSceneAsync(ChooseTraining.egitimler);
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            slider.value = async.progress;
            if(async.progress == 0.9f)
            {
                slider.value = 1f;
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
