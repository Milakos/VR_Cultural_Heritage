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

    public List<GameObject> hands = new List<GameObject>();
    XRBaseInteractor interactor;

    public InteractionLayerMask mask;
    private void Awake() 
    {
        controller = GetComponent<XRGrabInteractable>();
        anim = GetComponent<Animator>();

    }
    private void Start()
    {
        hands.Add(GameObject.Find("LeftHandGrab"));
        hands.Add(GameObject.Find("RightHandGrab"));
        
        foreach (var hand in hands) 
        {
            gameObject.SetActive(false);
        }
    }
    public void HandChoose(GameObject Hand)
    {
        if (interactor.name == "LeftHand")
        {
            hands[1] = Hand;
        }
        else 
        {
            hands[0] = Hand;
        }
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
