using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class MotionSick : MonoBehaviour
{
    /// <summary>
    /// A class that is resposnible to reduce the motion sickness to the user
    /// with the help of a vigniette effect when the user is moving or turning right
    /// left with the controllers and not the camera
    /// </summary>
    PostProcessVolume vol;    
    Vignette vignette;

    void Start()
    {
        vol = GetComponent<PostProcessVolume>();
        vol.profile.TryGetSettings(out vignette);
    }
    private void OnEnable() 
    { 
        FindObjectOfType<ButtonActionsController>().MotionSickVignetteTrigger += Motionblur;  
    }
    /// <summary>
    /// Motion blur logic that is visible when the controllers are pressed or are in progress that corresponds
    /// with a boolean check sending it to that class and subscribes as a listener
    /// </summary>
    /// <param name="isInteracting"></param>
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
