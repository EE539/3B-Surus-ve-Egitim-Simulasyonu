using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrafikLambalarEvent:MonoBehaviour
{
    public  delegate void OnHareket();
    public  OnHareket run;
    public   OnHareket stop;
    public  List<GameObject> list = new List<GameObject>();
    
    Animator tut;
    public void Start()
    {


        run += Hareket;
        stop += Dur;

        Debug.Log("selammmm merve ben trafik lambalari olustummm" + " sayim da : " + list.Count);
    }   
    public  void Hareket()
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].GetComponent<Animator>().enabled = true;
            Debug.Log("arabalar çalısıyor");

        }
    }
    public   void Dur()
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].GetComponent<Animator>().enabled = false;
            Debug.Log("arabalr durdu ");

        }
    }
}
