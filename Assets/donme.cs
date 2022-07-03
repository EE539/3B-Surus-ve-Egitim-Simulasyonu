using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class donme : MonoBehaviour
{
    //public double speed = 2f;
    public Vector3 rotateVector = new Vector3(-1, 0, 0);
    void Start()
    {
        
    }

   
    void Update()
    {
        transform.Rotate(rotateVector  * Time.fixedDeltaTime);
    }
}
