/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sanal2 : MonoBehaviour
{

    public delegate void OnHareket();

    RaycastHit nesne;
    trafikLambasi tut;

    public static event Action run;
    public static event Action stop;

     public sanal t1;//sedan
    public sanal3 t2;//sedan

    void Start()
    {


    }

    void Update()
    {
        // 
        Debug.Log("merhaba");
        if (Physics.Raycast(transform.position,  Vector3.forward + Vector3.right, out nesne, 0.5f))
        {//raycast olusturduk.
            Debug.Log("ray cast olustu " + nesne.collider.gameObject.tag);
            Debug.DrawLine(transform.position, Vector3.forward + Vector3.right * 0.5f, Color.green);
            if (nesne.collider.gameObject.tag == "car")//MERCEDES
            {
                Debug.Log("nesneye carpıldı" + "durum : " + trafikLambasi.durum);
                //nesneye carptik
                if (0 == string.Compare(trafikLambasi.durum, "dur"))//trafk lambası classından trafik lambasının durumuna bakarız.
                {
                    stop?.Invoke();//stop adında olusturdugumuz event'i cagrırız.
                    Debug.Log("Arabayı durdurduk");
                }
                else if (0 == string.Compare(trafikLambasi.durum, "gec"))
                {//durum dur degilse o zaman run eventini cagrırız.

                    run?.Invoke();

                    Debug.Log("Arabayı calıstıK");
                }
            }
            if (nesne.collider.gameObject.tag == "car2")//sedan
            {
                Debug.Log("nesneye carpıldı" + "durum : " + trafikLambasi.durum);
                //nesneye carptik
                if (0 == string.Compare(trafikLambasi.durum, "dur"))//trafk lambası classından trafik lambasının durumuna bakarız.
                {
                    t1.Dur2();
                    
                }
                else if (0 == string.Compare(trafikLambasi.durum, "gec"))
                {//durum dur degilse o zaman run eventini cagrırız.

                    t1.Hareket2();

                    
                }

            }
            if (nesne.collider.gameObject.tag == "car3")//sedan2
            {
                Debug.Log("nesneye carpıldı" + "durum : " + trafikLambasi.durum);
                //nesneye carptik
                if (0 == string.Compare(trafikLambasi.durum, "dur")) {
                    t2.Dur3();
                }
                else if (0 == string.Compare(trafikLambasi.durum, "gec"))
                {//durum dur degilse o zaman run eventini cagrırız.

                    t2.Hareket3();
                }
            }

        }
    }
}*/



