using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopEmission : MonoBehaviour
{
    Animator anim;

    private void Awake() 
    {
        anim = GetComponent<Animator>();    
    }

    public void StopEmissionEffect(bool grabbingBool)
    {
        anim.SetBool("isGrabbed", grabbingBool);
    }
}
