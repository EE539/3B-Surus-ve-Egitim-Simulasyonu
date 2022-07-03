using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafikLambasi : MonoBehaviour
{
    public GameObject kirmizi, sari, yesil;
    public float kirmizizaman, sarizaman, yesilzaman, zaman;
    public static int i = 0;

    public static int durum;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (zaman < yesilzaman) //zaman yeşil ışığın süresinden küçükken zamanı artır
        {
            zaman += Time.deltaTime;
        }
        else //değil ise zaman'ı resetle
        {
            zaman = 0;
        }

        if(zaman < kirmizizaman) //zaman kırmızı ışığın süresinden küçük ise kırmızı yansın
        {
            kirmizi.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            sari.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
            yesil.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
            i = 1;
            durum = 0;
        }
        if(zaman > kirmizizaman && zaman < sarizaman) // zaman sarı ışığın süresinden küçük, kırmızı ışığın süresinden büyük ise sarı ışığı yak
        {
            kirmizi.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
            sari.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            yesil.GetComponent<Renderer>().material.DisableKeyword ("_EMISSION");
            i = 2;
            durum = 0;
        }
        if (zaman > sarizaman)//zaman sarı ığının süresinden büyük ise yeşil ışığı yak
        {
            kirmizi.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
            sari.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
            yesil.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            i = 3;
            durum = 1;
        }

    }
}
