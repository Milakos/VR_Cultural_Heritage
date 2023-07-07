using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class InteractableManager : MonoBehaviour
{
    [SerializeField] SO Item;

    Animator anim;
    [SerializeField] XRGrabInteractable controller;
    public InteractionLayerMask mask;
    private void Awake() 
    {
        controller = GetComponent<XRGrabInteractable>();
        anim = GetComponent<Animator>();    
    }
    public void OnSocketDetach()
    {     
        controller.interactionLayers = mask;
        print("Deactivate cube");
    }
    public void StopEmissionEffectAnimation(bool grabbingBool)
    {
        anim.SetBool("isGrabbed", grabbingBool);
    }
}
