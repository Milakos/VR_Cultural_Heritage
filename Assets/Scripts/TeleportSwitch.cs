using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class TeleportSwitch : MonoBehaviour
{
    [SerializeField] XRRayInteractor rayInteractor;
    [SerializeField] InteractionLayerMask[] mask;

    private int index;
    void Start()
    {
        rayInteractor = GetComponent<XRRayInteractor>();    
    }
    private void OnEnable() 
    {
        FindObjectOfType<ButtonActionsController>().xButton += SwitchLayerMask;
    }
    // private void OnDisable() 
    // {
    //     FindObjectOfType<ButtonActionsController>().xButton -= SwitchLayerMask;
    // }
    // public void SwitchLayerMaskTeleport()
    // {      
    //     int index = 0;
    //     rayInteractor.interactionLayers = mask[index];
    //     print("0");            
    // }
    // public void SwitchLayerMaskMixed()
    // {
    //     int index = 1;
    //     rayInteractor.interactionLayers = mask[index];
    //     print("1"); 
    // }
    public void SwitchLayerMask(bool intLayers)
    {
        if (intLayers == true)
        {
            index = 1;
            rayInteractor.interactionLayers = mask[index];
            print("INDEX = " + index);
        }
        else 
        {
            index = 0;
            rayInteractor.interactionLayers = mask[index];
            print("INDEX = " + index);
        }

    }

}
