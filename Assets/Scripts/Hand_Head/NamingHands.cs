using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NamingHands : MonoBehaviour
{
    public enum ChooseHand
    {
        Right,
        Left
    }

    public ChooseHand choose;
    InteractableManager interactableManager;
    NamingHands instance;
    private void Awake()
    {
        instance = this;
    }
    private void OnEnable()
    {
        interactableManager = GetComponentInParent<InteractableManager>();

        if (choose == ChooseHand.Right)
        {
            instance.gameObject.name = interactableManager.RightHandHash;
        }
        else if (choose == ChooseHand.Left) 
        {
            instance.gameObject.name = interactableManager.LeftHandHash;
        }
    }
}