using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSuccess : MonoBehaviour
{
    public kavsak kavsakE;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider Other)
    {
        if(string.Equals(this.name, "triggerSolB") || string.Equals(this.name, "triggerSagB"))
        {
            kavsakE.clearScreen();
            kavsakE.basarili.SetActive(true);
        }
        kavsakE.Car.gameObject.GetComponent<CarController>().enabled = false;
        kavsakE.cc.currentbreakForce = 37267.0f;
        kavsakE.cc.ApplyBreaking();
        kavsakE.currentLine++;
        kavsakE.PosIn = this.gameObject.transform.position;
        kavsakE.RotIn = this.gameObject.transform.rotation;
        kavsakE.saveLine = kavsakE.currentLine;
        Destroy(this);
    }
}
