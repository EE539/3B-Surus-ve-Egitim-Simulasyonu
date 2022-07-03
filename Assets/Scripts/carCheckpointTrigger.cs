using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carCheckpointTrigger : MonoBehaviour
{
    public int checkedpoint=0;
    void OnTriggerEnter(Collider other){
        if(other.tag == "Check"){
            checkedpoint++;
        }
    }
}
