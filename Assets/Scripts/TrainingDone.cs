using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainingDone : MonoBehaviour
{
    public void onClicked()
    {
        SahneGecisKontrol.returnFromTraining = true;
        SceneManager.LoadScene("Arayüz");
        MenuMusic.Instance.gameObject.GetComponent<AudioSource>().Play();
    }
}
