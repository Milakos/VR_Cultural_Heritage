using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
public class InteractableManager : MonoBehaviour, IItemInventory
{
    [Header("Item Properties")] [SerializeField]
    public SO Item; // The Scripatble object item that this script will inherit properties
    public GameObject ItemsSocket;
    [Space(10)]

    [Header("Interactable Reference")] [SerializeField]
    private XRGrabInteractable baseInteractable; // Reference of the XRGrabInteracyable Component
    [Space(10)]
    [Header("Hand Interactors")]
    public XRBaseInteractor[] baseInteractors; // The initialization of the hands through Inspector,
                                               // for a reason only works when access modifier is public 

    public List<GameObject> hands = new List<GameObject>(); // List of gameobjects that will be added

    [Header("Layer Identifier Usability")] [Space(10)] [Tooltip("Choose the condition of the object after is attached to its socket")]
    [SerializeField] private InteractionLayerMask mask; // Layer Mask that identifies the object state such as "is Placed"

    /// <summary>
    /// Const Variables that will not change
    /// </summary>
    private const bool Deactivate = false; // A Const bool that always have to be False for hand deactivation
    private const int LayerInteractable = 10;
    private const int LayerHands = 12;
    [SerializeField] public string AnimationNameHash = "";

    /// <summary>
    /// 
    /// </summary>
    private Animator anim; // Reference of Animator Componenet
    private Rigidbody rb; // Reference of Rigidbody component
    
    private ButtonActionsController controller;

    public delegate void MountInInventory(SO item, int id);
    public event MountInInventory MountInventory;
    Inventory inventory;
    InteractableManager instance;

    GarbagePool garbage;
    //
    public Queue<GameObject> objbranch = new Queue<GameObject>();
    public Queue<GameObject> objores = new Queue<GameObject>();
    //
    private void Awake()
    {
        instance = this;
        //
        if (Item.type == Type.Branch)
            objbranch.Enqueue(instance.gameObject);
        else if(Item.type == Type.Silver)
            objores.Enqueue(instance.gameObject);        
        //
        inventory = FindObjectOfType<Inventory>();       
        controller = FindObjectOfType<ButtonActionsController>();
        garbage = FindObjectOfType<GarbagePool>();
        baseInteractable = GetComponent<XRGrabInteractable>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        if (baseInteractors == null) { return; }
        baseInteractors = FindObjectsOfType<XRBaseInteractor>();
        
    }
    
    private void OnEnable()
    {
        rb.isKinematic = true;
        inventory.interactables.Add(instance);
        baseInteractable.selectEntered.AddListener(OnSelectEnter);
        baseInteractable.selectExited.AddListener(OnSelectExit);       
    }
    private void Start()
    {
        DeactivateHands();
        CollidesWithForge(false);
    }
    private void OnDisable()
    {
        inventory.interactables.Remove(instance);
        controller.aButton -= StoreInInventory;
        baseInteractable.selectEntered.RemoveListener(OnSelectEnter);
        baseInteractable.selectExited.RemoveListener(OnSelectExit);
    }
    // Method that Triggers all the functionality when an interactor grabs this interactable

    private void OnSelectEnter(SelectEnterEventArgs EnterEvents)
    {
        if(ItemsSocket != null)
            ItemsSocket.SetActive(true);
        HandSelectChoose(true);
        StopEmissionEffectAnimation(true);
        controller.aButton += StoreInInventory;
    }
    // Method that Triggers all the functionality when an interactor release this interactable
    private void OnSelectExit(SelectExitEventArgs ExitEvents)
    {
        if (CollidesWithForge(false)) 
        {
            if (ItemsSocket != null)
                ItemsSocket.SetActive(false);
        }

        HandSelectChoose(false);
        StopEmissionEffectAnimation(false);
        DeactivateHands();
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
    public bool AnyInteractorSelecting()
    {
        foreach (XRBaseInteractor binteractor in baseInteractors)
        {
            if (binteractor.IsSelecting(baseInteractable))
            {
                print(binteractor.name);
                return true;
            }
        }
        return false;
    }

    // A Function that cannot let the player interact with a placed object in the scene
    //through Socket GameObject
    public void OnSocketDetach()
    {
        baseInteractable.interactionLayers = mask;
        print("Detach");
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
            if (hand != null) 
            {
                hand.SetActive(Deactivate);
            }          
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
        if (CanBeStored()) 
        {
            if (!CanUsedAsATool())
            {
                if (Item.type == Type.Branch)
                {
                    if (!garbage.grabables.ContainsKey(Item))
                    {
                        garbage.grabables.Add(Item, objbranch);
                    }
                    else
                        garbage.branches.Enqueue(gameObject);
                }
                else if (Item.type == Type.Silver) 
                {
                    if (!garbage.grabables.ContainsKey(Item))
                    {
                        garbage.grabables.Add(Item, objores);
                    }
                    else
                        garbage.Ores.Enqueue(gameObject);
                }              
            }
            else 
            {
                garbage.tools.Add(Item, gameObject);
            }
            
        }      
        gameObject.SetActive(false);
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
            print("This is a Tool");
        }
    }

    public void StoreInInventory()
    {
        if (!CanBeStored()) { return; }
        
        if (CanBeStored() == true)
        {
            DeactivateHands();
            FindObjectOfType<HandUI>().anim.SetBool("HandUIActivated", true);
            anim.Play(AnimationNameHash);
            //TODO add some functionality that puts the data in the inventory list
            if (MountInventory != null) 
            {               
                MountInventory?.Invoke(Item, Item.ID);
                controller.aButton -= StoreInInventory;
            }
        }
        else
        {           
            FindObjectOfType<HandUI>().anim.SetBool("HandUIActivated", true);
        }
        if (ItemsSocket != null)
            ItemsSocket.SetActive(false);
    }
    public void RemoveFromInventory()
    {
        // Logic to implement after removing from inventory
    }

    public void DestoryOnSocket() 
    {
        Destroy(gameObject);
        Destroy(ItemsSocket);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Forge"))
        {
            CollidesWithForge(true);
        }
    }

    public bool CollidesWithForge(bool collides) 
    {
        return collides;
    }
}
