using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(ActionBasedController))]
public class HandController : MonoBehaviour
{
    ActionBasedController controller;
    XRInteractorLineVisual rayLineInteractor;
    HapticsController hapticsController;
    public Color col = new Color(0,136,255);
    public Color col_ = new Color(31,71,106);
    public HandNoIK hand;
    [SerializeField] private float amplitudeHoverValue;
    [SerializeField] private float durationHover;
    [SerializeField] private float amplitudeGrabValue;
    [SerializeField] private float durationGrab;
    [SerializeField] private bool isLeftHand;

    // Start is called before the first frame update
    void Start()
    {
       
        controller = GetComponent<ActionBasedController>();
        rayLineInteractor = GetComponent<XRInteractorLineVisual>();
        hapticsController = FindObjectOfType<HapticsController>();
    }

    // Update is called once per frame
    void Update()
    {
        hand.SetGrip(controller.selectAction.action.ReadValue<float>());
        hand.SetTrigger(controller.activateAction.action.ReadValue<float>());
    }

    public void OnHoverLight(bool hovering)
    {
        rayLineInteractor.validColorGradient.SetKeys
        (
            new GradientColorKey[]
            {
                new GradientColorKey(col,0.0f), 
                new GradientColorKey(col_, 1.0f)
            },
            new GradientAlphaKey[]
            {
                new GradientAlphaKey(0.5f, 1.0f),
                new GradientAlphaKey(0.5f, 1.0f)
            }
        );

        rayLineInteractor.lineWidth = 0.01f;
    }

    public void OnHoverHaptics(bool isLeftHand)
    {
        hapticsController.SendHaptics(isLeftHand, amplitudeHoverValue, durationHover);
    }
    public void OnGrabHaptics(bool isLeftHand)
    {
        hapticsController.SendHaptics(isLeftHand, amplitudeGrabValue, durationGrab);
    }


}
