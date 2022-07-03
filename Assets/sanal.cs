using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sanal : MonoBehaviour
{

    Animator tut;
    void Start()
    {

        tut = GetComponent<Animator>();

    }
    public  void Hareket2(){//anımasyonları etkinleştirir
        tut.enabled = true;
        Debug.Log("sedan1 çalısıyor");
    }
    public void Dur2()//anımasyonları durdurur.
    {
        GetComponent<Animator>().enabled = false;
        Debug.Log("sedan1 durdu ");

    }
}
