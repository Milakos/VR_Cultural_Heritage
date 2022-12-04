using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticsController : MonoBehaviour
{
    
    [SerializeField] ActionBasedController leftController, rightController;
    [SerializeField] private float hapticsAmplitude, hapticsDuation;
    
    [ContextMenu("Send Haptics")] 
    public void SendHaptics(bool isLeft, float amplitude, float duration)
    {    
        hapticsAmplitude = amplitude;
        hapticsDuation = duration;
        
        if (isLeft)
        {
            leftController.SendHapticImpulse(hapticsAmplitude, hapticsDuation);
        }
        else
        {
            rightController.SendHapticImpulse(hapticsAmplitude, hapticsDuation);
        }       
    }


}
