using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hareket : MonoBehaviour
{
    private Animator anim;
    private string animationType;
    private string[] split;
    private int arrayLength;

    void Start()
    {
      
        animationType = "Null,Walk,Run";
        split = animationType.Split(',');
        anim = gameObject.GetComponentInChildren<Animator>();
        arrayLength = split.Length;

        // Call here
        StartCoroutine(LoopThroughAnimation());
    }

    IEnumerator LoopThroughAnimation()
    {
        for (int i = 1; i < arrayLength; i++)
        {
            animationType = split[i];
            Debug.Log(animationType);

            //anim.SetInteger ("AnimPar", 0);
            anim.Play(animationType);

            yield return new WaitForSeconds(10);
        }
    }
}
