using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirajTriggerFail : MonoBehaviour
{

    public Viraj viraj_fail;
    private void OnTriggerEnter(Collider other)
    {
        viraj_fail.Car.transform.SetPositionAndRotation(viraj_fail.PosIn, viraj_fail.RotIn);
        viraj_fail.currentLine = viraj_fail.saveLine;
        viraj_fail.Car.gameObject.GetComponent<CarController>().enabled = false;
        viraj_fail.cc.currentbreakForce = 37267.0f;
        viraj_fail.cc.ApplyBreaking();
        viraj_fail.clearScreen();
        viraj_fail.basarisiz.SetActive(true);
    }
}
