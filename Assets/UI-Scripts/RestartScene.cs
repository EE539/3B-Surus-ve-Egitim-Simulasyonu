using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartScene : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log(SceneManager.GetActiveScene().name);
    }
}
