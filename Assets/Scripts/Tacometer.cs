using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tacometer : MonoBehaviour
{
    public CarController cc;
    //0 = 188 derece, 1 = 138 derece
    //5 = -30 derece

    private const float MIN_AVG = 138.0f;
    private const float MAX_AVG = -30.0f;
    public int[] vites = {1, 2, 3, 4, 5};
    public float[] topSpeeds = {40, 60, 80, 120};
    private int topSpeedCounter = 0;
    public int vitesCounter = 0;

    private Transform ibreTransform; // objenin dönüşünü, sahnedeki konumu tutan bir component

    public float speed; //anlık hız
    public float topSpeed; //max hız
    public float tireDiameter;
    private float saveSpeed = 0;

    public bool kontak;

    public GameObject ibre;

    private void Awake()
    {
        ibreTransform = ibre.transform; //transfrom tipinde ibreTransform adında bir değişken oluşturuldu. İbrenin transform bilgilerini al ve ibreTransforma gönder (transform= location, rotate, scale) 
        if (kontak && speed < 1)
        {
            vitesCounter = 0;
            ibreTransform.eulerAngles = new Vector3(0, 0, MIN_AVG+8);
        }
        if (!kontak)
        {
            ibreTransform.eulerAngles = new Vector3(0, 0, 188);
        }
    }

   

    // Update is called once per frame
    private void FixedUpdate()
    {
        StartCoroutine(NewSpeed());
        kontak = cc.kontak;
        speed = cc.speed;
        topSpeed = topSpeeds[topSpeedCounter];
        if (kontak && speed < 1)
        {
            //Debug.Log("vites counter = " + vitesCounter);
            vitesCounter = 0;
            ibreTransform.eulerAngles = new Vector3(0, 0, 146);
        }

        else if (kontak) { 
            ibreTransform.eulerAngles = new Vector3(0, 0, GetTacoRotation());
             
            if(topSpeedCounter !=3 && speed > topSpeed / 2 && speed <= topSpeed - 15) //En sonuncu en yüksek hıza ulaşmadıysam ve Hız en büyük hızın yarısından büyük ve max hızın 15 altında ise
            {
                topSpeedCounter++;
                vitesCounter++;
                topSpeed = topSpeeds[topSpeedCounter];
                ibreTransform.eulerAngles = new Vector3(0, 0, GetTacoRotation());
                //Debug.Log("vites counter = " + vitesCounter);
            }
            else if (vitesCounter != 4 && speed > topSpeed / 2 && speed <= (topSpeed - 20) + 5)
            {
                vitesCounter++;
                topSpeed = 210;
                ibreTransform.eulerAngles = new Vector3(0, 0, GetTacoRotation());
            }

            if(topSpeedCounter != 0 && vitesCounter != 0 && (int)saveSpeed > (int)speed + 1 && speed < topSpeeds[topSpeedCounter - 1]) //Hızım ilk topSpeed değil ise ve SaveSpeed hızımdan büyükse ve hızım bir önceki hızımdan küçükse
            {
                topSpeedCounter--;
                vitesCounter--;
                topSpeed = topSpeeds[topSpeedCounter];
                ibreTransform.eulerAngles = new Vector3(0, 0, GetTacoRotation());
                //Debug.Log("vites counter = " + vitesCounter);
            }

            if (GetTacoRotation() <= MAX_AVG )
            {
                ibreTransform.eulerAngles = new Vector3(0, 0, MAX_AVG);
            } //Devir saati 5'i gösteriyorsa
        }

        if (!kontak)
        {
            ibreTransform.eulerAngles = new Vector3(0, 0, 188);
            topSpeedCounter = 0;
            vitesCounter = 0;
        }
        //Debug.Log("Save Speed: " + (int)saveSpeed + " and speed: " + (int)speed);

        /*float angle = Mathf.Lerp(MIN_AVG, MAX_AVG, Mathf.InverseLerp(0, topSpeed, speed));
        ibreTransform.eulerAngles = new Vector3(0, 0, angle*10f);*/
    }

   [HideInInspector] public float GetTacoRotation()
    {
        float toplamDonusAcisi = MIN_AVG - MAX_AVG; // 138 - (-30) = 168 derece toplam dönüş açım
        float speedNormalized = speed / topSpeed;

        float answer = 40 + MIN_AVG - speedNormalized * toplamDonusAcisi;
        if (answer > MIN_AVG)
            answer = MIN_AVG;
        return answer;
   }

    IEnumerator NewSpeed()
    {
        yield return new WaitForSeconds(2.0f);
        saveSpeed = speed;
    }
}
