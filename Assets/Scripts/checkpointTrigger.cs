using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointTrigger : MonoBehaviour
{
    public bool checkedCar = false;
    public bool alanicinde = false;
    void OnTriggerEnter(Collider other){
        if(other.tag == "Front" || other.tag == "Rear"){
            checkedCar = true;
            alanicinde = true;
        }
    }
    void OnTriggerExit(Collider other){
        if(other.tag == "Rear"){
            alanicinde = false;
        }
    }
}
