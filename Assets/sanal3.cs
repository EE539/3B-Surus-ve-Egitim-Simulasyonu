using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sanal3 : MonoBehaviour
{

    // RaycastHit nesne;
    // trafikLambasi tut;





    void Start()
    {

      
    }

    void Update()
    {
        
    }
    public void Hareket3()//anımasyonları etkinleştirir
    {
        GetComponent<Animator>().enabled = true;
        Debug.Log("sedan2  çalısıyor");
    }
    public void Dur3()//anımasyonları durdurur.
    {
        GetComponent<Animator>().enabled = false;
        Debug.Log("sedan2 durdu ");

    }
}
