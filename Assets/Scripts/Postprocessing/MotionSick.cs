using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class MotionSick : MonoBehaviour
{
    PostProcessVolume vol;    
    Vignette vignette;

    ButtonActionsController controller;

    void Start()
    {
        vol = GetComponent<PostProcessVolume>();
        vol.profile.TryGetSettings(out vignette);
    }
    private void OnEnable() 
    { 
        FindObjectOfType<ButtonActionsController>().MotionSickVignetteTrigger += Motionblur;  
    }
    private void OnDisable() 
    {
        // FindObjectOfType<ButtonActionsController>().rightStickAction -= Motionblur;
        // FindObjectOfType<ButtonActionsController>().leftGripAction -= Motionblur;  
    }

    public void Motionblur(bool isInteracting)
    {
        
        if (isInteracting == true)
        {
            vignette.active = true;
            vignette.intensity.value = 1f;
            vignette.smoothness.value = 1f;
            
        }
        else
        {
            vignette.active = false;
            vignette.intensity.value = 0f;
            vignette.smoothness.value = 0f;
            
        }
    }
}
