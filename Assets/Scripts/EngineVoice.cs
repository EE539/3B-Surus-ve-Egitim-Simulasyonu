using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineVoice : MonoBehaviour
{
    public Tacometer tc;

    public AudioClip acilis;
    public AudioClip calisma;
    public AudioClip kapanis;

    public float du_hiz; //düzeltme hız
    public float mi_pit;//minimum pitch of voice
    public float pi_hiz;//pitch of voice speed

    private AudioSource _source;
    float hiz;
    bool kontak;

    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<AudioSource>(); //Kodun bulunduğu objedeki sesi dinle
    }

    // Update is called once per frame
    void Update()
    {
        kontak = GetComponent<CarController>().kontak;
        //hiz = GetComponent<CarController>().speed;
        hiz = tc.GetTacoRotation();
        if(hiz == null || hiz == 0)
        {
            hiz = 0;
        }
        else
        {
            hiz = hiz - 138;
        }
               
        if(!kontak && _source.clip == calisma) //kontak kapalı ve araç çalışıyorsa
        {
            _source.clip = kapanis;
            _source.Play();
        }
        
        if(kontak && (_source.clip == kapanis || _source.clip == null)) //kontak açıksa ve araç kapanıyorsa veya çalışmıyorsa
        {
            _source.clip = acilis;
            _source.Play();
            _source.pitch = 1;
        }

        if(kontak && !_source.isPlaying)//kontak açıksa ama hiçbir şey duyulmuyorsa (kod ilk defa çalıştığında)
        {
            _source.clip = calisma;
            _source.Play();
        }

    }
}
