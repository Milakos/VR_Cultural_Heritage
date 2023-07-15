using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class InteractableManager : MonoBehaviour
{   
    public XRBaseInteractor[] baseInteractors;

    private List<GameObject> hands = new List<GameObject>();

    [SerializeField] private XRGrabInteractable baseInteractable;

    [SerializeField] private SO Item;
    

    private Animator anim;

    [SerializeField] private InteractionLayerMask mask;

    private void Awake()
    {
        baseInteractable = GetComponent<XRGrabInteractable>();
        anim = GetComponent<Animator>();

        hands.Add(GameObject.Find("RightHandGrab"));
        hands.Add(GameObject.Find("LeftHandGrab"));
    }
    private void Start()
    {
        DeactivateHands(false);

        if (baseInteractors == null) { return; }

        baseInteractors = FindObjectsOfType<XRBaseInteractor>();
    }

    public void DeactivateHands(bool active)
    {      
        foreach (GameObject hand in hands)
        {
            hand.SetActive(active);
        }
        active = false; 
    }

    public void HandSelectChoose(bool handActivation)
    {
        if (baseInteractors != null) 
        {
            if (baseInteractors[0].IsSelecting(baseInteractable))
            {
                hands[0].SetActive(handActivation);
                print("IsSelectingRight");
            }
            else if (baseInteractors[1].IsSelecting(baseInteractable)) 
            {
                hands[1].SetActive(handActivation);
                print("IsSelectingLeft");
            }
        }
    }

    public void OnSocketDetach()
    {
        baseInteractable.interactionLayers = mask;
        print("Deactivate cube");
    }
    public void StopEmissionEffectAnimation(bool grabbingBool)
    {
        anim.SetBool("isGrabbed", grabbingBool);
    }
}
