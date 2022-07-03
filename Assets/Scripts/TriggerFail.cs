using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFail : MonoBehaviour
{

    public kavsak Kavsak;
    private void OnTriggerEnter(Collider other)
    {
        Kavsak.Car.transform.SetPositionAndRotation(Kavsak.PosIn, Kavsak.RotIn);
        Kavsak.currentLine = Kavsak.saveLine;
        Kavsak.Car.gameObject.GetComponent<CarController>().enabled = false;
        Kavsak.cc.currentbreakForce = 37267.0f;
        Kavsak.cc.ApplyBreaking();
    }
}
