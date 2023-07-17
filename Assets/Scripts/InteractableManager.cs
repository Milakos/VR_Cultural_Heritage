using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
public class InteractableManager : MonoBehaviour, IItemInventory
{    
    [Header("Item Properties")][SerializeField] 
    public SO Item; // The Scripatble object item that this script will inherit properties
    public GameObject ItemsSocket;
    [Space(10)]

    [Header("Interactable Reference")][SerializeField]
    private XRGrabInteractable baseInteractable; // Reference of the XRGrabInteracyable Component
    [Space(10)]
    [Header("Hand Interactors")]
    public XRBaseInteractor[] baseInteractors; // The initialization of the hands through Inspector,
                                              // for a reason only works when access modifier is public 
    
    private List<GameObject> hands = new List<GameObject>(); // List of gameobjects that will be added
    
    [Header("Layer Identifier Usability")][Space(10)][Tooltip("Choose the condition of the object after is attached to its socket")]
    [SerializeField] private InteractionLayerMask mask; // Layer Mask that identifies the object state such as "is Placed"

    /// <summary>
    /// Const Variables that will not change
    /// </summary>
    private const bool Deactivate = false; // A Const bool that always have to be False for hand deactivation
    private const int LayerInteractable = 10;
    private const int LayerHands = 12;
    [SerializeField] private string AnimationNameHash = "";
    /// <summary>
    /// 
    /// </summary>
    private Animator anim; // Reference of Animator Componenet
    private Rigidbody rb; // Reference of Rigidbody component
    
    private ButtonActionsController controller;

    public delegate void MountInInventory(SO item);
    public event MountInInventory MountInventory;
    Inventory inventory;
    private void OnEnable()
    {       
        controller = FindObjectOfType<ButtonActionsController>();
        inventory = FindObjectOfType<Inventory>();
        inventory.interactables.Add(this);

        baseInteractable = GetComponent<XRGrabInteractable>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        if (baseInteractors == null) { return; }
        baseInteractors = FindObjectsOfType<XRBaseInteractor>();

        hands.Add(GameObject.Find("RightHandGrab"));
        hands.Add(GameObject.Find("LeftHandGrab"));

        baseInteractable.selectEntered.AddListener(OnSelectEnter);
        baseInteractable.selectExited.AddListener(OnSelectExit);

        DeactivateHands();

        
    }
    private void OnDisable()
    {
        inventory.interactables.Remove(this);
        baseInteractable.selectEntered.RemoveListener(OnSelectEnter);
        baseInteractable.selectExited.RemoveListener(OnSelectExit);
    }
    // Method that Triggers all the functionality when an interactor grabs this interactable
    private void OnSelectEnter(SelectEnterEventArgs EnterEvents)
    {
        ItemsSocket.SetActive(true);
        HandSelectChoose(true);
        StopEmissionEffectAnimation(true);
        controller.aButton += StoreInInventory;
    }
    // Method that Triggers all the functionality when an interactor release this interactable
    private void OnSelectExit(SelectExitEventArgs ExitEvents)
    {
        ItemsSocket.SetActive(false);
        HandSelectChoose(false);
        DeactivateHands();
        StopEmissionEffectAnimation(false);
        ApplyPhysicsToInteractable();
        controller.aButton -= StoreInInventory;
    }

    // Function that checks which of the two interactors aka hands interact with this gameobject
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
    
    // A Function that cannot let the player interact with a placed object in the scene
    //through Socket GameObject
    public void OnSocketDetach()
    {
        baseInteractable.interactionLayers = mask;
    }
    // A Function for triggering the emission animation componenet through grabbing from player
    public void StopEmissionEffectAnimation(bool grabbingBool)
    {
        anim.SetBool("isGrabbed", grabbingBool);
    }

    // A Funcion that only Set Active to false both attached hand gameobjects
    public void DeactivateHands()
    {
        foreach (GameObject hand in hands)
        {
            hand.SetActive(Deactivate);
        }
    }
    /// <summary>
    /// When the player releases the interactable object thiw method applies force of gravity for a realistic 
    /// throw and Ignores the Collision with the hands to prevent from bouncing effects
    /// </summary>
    private void ApplyPhysicsToInteractable()
    {
        rb.isKinematic = false;
        rb.AddRelativeForce(Vector3.down, ForceMode.Force);
        Physics.IgnoreLayerCollision(LayerInteractable, LayerHands, true);
    }

    /// <summary>
    /// Function that Destoys the gamobject that this component is attached to through animation events
    /// </summary>
    public void DestroyParent() 
    {
        Destroy(gameObject);
    }

    public bool CanUsedAsATool()
    {
        return Item.CanUseAsTool;
    }
    public bool CanBeStored()
    {
        return Item.CanStored;
    }
    public void Use()
    {
        if (!CanUsedAsATool()) { return; }

        if (CanUsedAsATool() == true) 
        {
            //TODO add some functionality for using the tool
        }
    }

    public void StoreInInventory()
    {
        if (!CanBeStored()) { return; }
        
        if (CanBeStored() == true)
        {
            print("TEST");
            DeactivateHands();
            FindObjectOfType<HandUI>().anim.SetBool("HandUIActivated", true);
            anim.Play(AnimationNameHash);
            //TODO add some functionality that puts the data in the inventory list
            if (MountInventory != null) 
            {               
                MountInventory?.Invoke(Item);
            }
            
        }
        else
        {           
            FindObjectOfType<HandUI>().anim.SetBool("HandUIActivated", true);
        }

        controller.aButton -= StoreInInventory;
    }

    public void RemoveFromInventory()
    {
    }


}
