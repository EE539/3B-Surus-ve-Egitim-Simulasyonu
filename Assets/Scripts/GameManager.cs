using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public string gear, training, username;
    public List<GameObject> trainings = new List<GameObject>();
    // Start is called before the first frame update
    void Awake()
    {
        gear = ChooseGear.gearName;
        training = ChooseTraining.name;
        username = EnterDatabase.user;
        
    }
    public void Start()
    {
        foreach (GameObject egitim in trainings)
        {
            if (string.Equals(training, egitim.name))
            {
                egitim.SetActive(true);
                break;
            }
        }//fail = serbest
    }

}
