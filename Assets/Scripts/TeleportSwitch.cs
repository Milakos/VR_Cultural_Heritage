using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class TeleportSwitch : MonoBehaviour
{
    [SerializeField] XRRayInteractor rayInteractor;
    [SerializeField] InteractionLayerMask[] mask;
    public bool isTeleportingState;
    public bool isInTeleportState;
    private void Start()     
    {
        TryTeleport(true);
        Rays();
    }
    private void Update() 
    {
        if(CheckLayers() == true)
        {
            isInTeleportState = true;
        }
    }
    public void TryTeleport(bool Telep)
    {
        if (Telep == true)
        {
            rayInteractor.interactionLayers = mask[0];
            rayInteractor.lineType = XRRayInteractor.LineType.BezierCurve;
        }
        else
        {
            rayInteractor.interactionLayers = mask[1];
            rayInteractor.lineType = XRRayInteractor.LineType.StraightLine;
        }

    }
    public bool CheckLayers()
    {
        if(rayInteractor.interactionLayers == mask[0])
        {
            isTeleportingState = true;
            print("Iseleporting");
        }else
        {
            isTeleportingState = false;
            print("IsNOTTseleporting");
        }
        return isTeleportingState;
    }
    public void Rays()
    {
        int mask = LayerMask.NameToLayer("Interactable"); 

        if(Physics.Raycast(transform.position, Vector3.forward, Mathf.Infinity, mask))
        {
            print(mask);
        }
    }
    
}
