using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafikAkis : MonoBehaviour
{
   
    int tut;
    



    private void OnCollisionStay(Collision nesne)
    {
        Debug.Log("trigger stay'a girdim");
        if (nesne.collider.gameObject.tag == "car" && trafikLambasi.durum == 0)//araclar duracak
        {
            tut = 5;
         //   Debug.Log("durdurmaya devam: " +tut);
            nesne.collider.gameObject.GetComponent<Animator>().enabled = false;
            //StartCoroutine(Hareket(nesne));
        }
        if (nesne.collider.gameObject.tag == "car" && trafikLambasi.durum == 1)//araclar hareket edecek
        {
            tut = 10;
           // Debug.Log("calıstırmaya devam: " +tut);
           
            nesne.collider.gameObject.GetComponent<Animator>().enabled = true;
        }
        if(nesne.collider.gameObject.tag == "donme")
        {
            if(nesne.collider.gameObject.tag == "car" && trafikLambasi.durum == 1)
            {
                nesne.collider.gameObject.GetComponent<Animator>().enabled = true;
            }
        }
        Debug.Log("tut degeri : " + tut);
    


       
    }

   
}
