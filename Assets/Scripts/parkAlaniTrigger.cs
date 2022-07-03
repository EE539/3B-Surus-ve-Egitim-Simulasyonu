using System.Diagnostics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parkAlaniTrigger : MonoBehaviour
{
    public Boolean frontParkEdiliMi=false, rearParkEdildiMi=false;
    public Boolean ilkFront=false, ilkRear=false;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Front"&&!ilkFront&&!ilkRear){
            ilkFront=true;
        }
        else if(other.tag == "Rear"&&!ilkFront&&!ilkRear){
            ilkRear=true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        //Debug.Log("Vehicle parked successfully.");
        if(other.tag == "Front"){
            frontParkEdiliMi = true;
        }
        else if(other.tag == "Rear"){
            rearParkEdildiMi = true;
        }
    }
 
}
