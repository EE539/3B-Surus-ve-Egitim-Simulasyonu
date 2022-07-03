using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirajTriggerSuccess : MonoBehaviour
{
    public Viraj orta_viraj;
    public bool egitimtamamlandi = false;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider Other)
    {
        if (string.Equals(this.name, "trigger"))
        {
            orta_viraj.clearScreen();
            orta_viraj.basarili.SetActive(true);
            egitimtamamlandi=true;
        }
        orta_viraj.Car.gameObject.GetComponent<CarController>().enabled = false;
        orta_viraj.cc.currentbreakForce = 37267.0f;
        orta_viraj.cc.ApplyBreaking();
        orta_viraj.currentLine++;
        orta_viraj.PosIn = this.gameObject.transform.position;
        orta_viraj.RotIn = this.gameObject.transform.rotation;
        orta_viraj.saveLine = orta_viraj.currentLine;
        Destroy(this);
       
    }
    
}
