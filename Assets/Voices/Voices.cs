using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voices : MonoBehaviour
{
    public AudioSource source;
    public List<AudioClip> clips;
    public egitim0101manager surus;
    public egitim02manager park;
    public OncelikGecisEgitim oncelik;
    public kavsak kavsak;
    public Viraj viraj;
    public int prevLine=0, prevline2 = -1;
    bool check = false;

    public void Start()
    {
        source.PlayOneShot(clips[0]);
    }
    // Update is called once per frame
    public void CallVoice()
    {
        source.Stop();
        switch (surus)
        {
            case UnityEngine.Object obj when !obj:
                break;
            case null:
                break;
            default:
                check = true;
                source.PlayOneShot(clips[surus.currentLine]);
                break;
        }
        switch (park)
        {
            case UnityEngine.Object obj when !obj:
                break;
            case null:
                break;
            default:
                check = true;
                if(park.egitimCurrentStage == egitimStages.ONL)
                    source.PlayOneShot(clips[park.currentLine]);
                else if(park.egitimCurrentStage == egitimStages.ARKAL)
                    source.PlayOneShot(clips[park.currentLine+3]);
                else
                    source.PlayOneShot(clips[park.currentLine+6]);
                break;
        }
        switch(oncelik)
        {
            case UnityEngine.Object obj when !obj:
                break;
            case null:
                break;
            default:
                check = true;
                if (oncelik.sorun == 0)
                {
                    source.PlayOneShot(clips[oncelik.currentLine]);
                }
                else
                {
                    source.PlayOneShot(clips[oncelik.sorun + 16]);
                }
                
                break;
        }
        switch (kavsak)
        {
            case UnityEngine.Object obj when !obj:
                break;
            case null:
                break;
            default:
                check = true;
                source.PlayOneShot(clips[kavsak.currentLine]);
                break;
        }

        switch (viraj)
        {
            case UnityEngine.Object obj when !obj:
                break;
            case null:
                break;
            default:
                source.PlayOneShot(clips[viraj.currentLine]);
                break;
            }
        }
       
    }

