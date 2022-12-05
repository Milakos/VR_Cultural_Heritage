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
    public void SwitchLayerMask(int IndexLayer)
    {
        int index;
        //nOT CHECK TO CHECKTO MOOROW
        switch(IndexLayer)
        {
            case 0: 
            if(IndexLayer == 0)
            {
                index = 0;
                rayInteractor.interactionLayers = mask[index];
            }
            
            break;
            
            case 1:
            if(IndexLayer == 1) 
            {
                index = 1;
                rayInteractor.interactionLayers = mask[index];
            }
            break;
        }
        print("InteractLayer");
        // return IndexLayer;
        // rayInteractor.interactionLayers = mask[IndexLayer];
        
    }
}
