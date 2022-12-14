using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class TeleportSwitch : MonoBehaviour
{
    public delegate void ChangeText(bool change);
    public event ChangeText changeButtonText;

    [SerializeField] XRRayInteractor rayInteractor;
    [SerializeField] InteractionLayerMask[] mask;
    
    [HideInInspector] public bool isTeleportingState;
    [HideInInspector] public bool isInTeleportState;
    int layerMask = 1 << 6;
    [HideInInspector] public bool IsHittingPlane;

    private void Start()     
    {
        TryTeleport(true);
    }
    private void Update() 
    {
        TeleportingAreaCheck();

        if(CheckLayers() == true)
        {
            isInTeleportState = true;
        }
        else
        {
            isInTeleportState = false;
        }
    }

    private void FixedUpdate() 
    {
        // TeleportingAreaCheck();
    }
    public void TryTeleport(bool Telep)
    {
        if (Telep == true)
        {
            rayInteractor.interactionLayers = mask[0];
            rayInteractor.lineType = XRRayInteractor.LineType.ProjectileCurve;
            changeButtonText(true);
        }
        else
        {
            rayInteractor.interactionLayers = mask[1];
            rayInteractor.lineType = XRRayInteractor.LineType.StraightLine;
            changeButtonText(false);
        }

    }
    public bool CheckLayers()
    {
        if(rayInteractor.interactionLayers == mask[0])
        {
            isTeleportingState = true;
            print("IsTeleporting");
        }else
        {
            isTeleportingState = false;
            print("IsNOTTseleporting");
        }
        return isTeleportingState;
    }
    public bool TeleportingAreaCheck()
    {
        RaycastHit hit;  

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit , Mathf.Infinity, layerMask))
        {
            IsHittingPlane = true;
            print(hit.transform.name);
        }else
        {
            IsHittingPlane = false;
        }
        return IsHittingPlane;
    }
}
