using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class TeleportSwitch : MonoBehaviour
{
    [SerializeField] XRRayInteractor rayInteractor;
    [SerializeField] InteractionLayerMask[] mask;
    // Start is called before the first frame update
    void Start()
    {
        rayInteractor = GetComponent<XRRayInteractor>();    
    }

    // Update is called once per frame
    public void SwitchLayerMaskTeleport()
    {      
        int index = 0;
        rayInteractor.interactionLayers = mask[index];
        print("0");            
    }
    public void SwitchLayerMaskMixed()
    {
        int index = 1;
        rayInteractor.interactionLayers = mask[index];
        print("1"); 
    }

}
