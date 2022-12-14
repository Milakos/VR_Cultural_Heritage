using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonActionsController : MonoBehaviour
{
    /////////////////// /////// Event Declairation \\\\\\\\\\\\\\\\\\\ \\\\\\\\\\\\\\\\\

    // Event with the right Stick for rotation
    public delegate void UI_CanvasActivation(bool i);
    public event UI_CanvasActivation activateCanvasUI;
    
    // Event that controls the left grip for blur image in teleportation
    public delegate void mostionSicknesVignnette(bool i);
    public event mostionSicknesVignnette MotionSickVignetteTrigger;

    // Event that controlls the Switch between layers in teleportation with the X Button

    // Event that controls the exit of the game with the Y Button in left controller
    public event Action yButton;

    /////////////////// /////// Event Declairation \\\\\\\\\\\\\\\\\\\ \\\\\\\\\\\\\\\\\

    [Header("Buttons")]
    public InputActionProperty[] inputButtonAction;
    
    [Header("Controller Sticks")]
    public InputActionProperty leftGrip;
    private bool isArea;
    private bool isHittingPlaneCheck;
    void Update()
    {
        ButtonControllersInput();
        MotionSwitchHandler();
    }

    public void ButtonControllersInput()
    {
        foreach (var item in inputButtonAction)
        {
                bool buttonAPressed = inputButtonAction[0].action.IsPressed();                
                bool buttonBPressed = inputButtonAction[1].action.IsPressed();
                bool buttonXPressed = inputButtonAction[2].action.IsPressed();
                bool buttonYPressed = inputButtonAction[3].action.IsPressed();

                if (buttonAPressed == true)
                    print("You Pressed " + inputButtonAction[0].action.name);
                
                if (buttonBPressed == true)
                {
                    print("You Pressed " + inputButtonAction[1].action.name);
                }

                ///////// X BUTTON \\\\\\\\\
                if(buttonXPressed == true)
                {
                    if(activateCanvasUI != null)
                    {
                        activateCanvasUI(true);
                    }
                    // 
                }                
                ///////// X BUTTON \\\\\\\\\

                if (buttonYPressed)
                {
                    print("You Pressed " + inputButtonAction[3].action.name);
                    print("Exit");
                    if(yButton != null)
                    {
                        yButton();
                    }  
                }  
        }
    }

    public void MotionSwitchHandler()
    {
        isArea = FindObjectOfType<TeleportSwitch>().isInTeleportState;
        isHittingPlaneCheck = FindObjectOfType<TeleportSwitch>().IsHittingPlane;

        if(inputButtonAction[4].action.IsPressed() || leftGrip.action.IsPressed() && isArea == true && isHittingPlaneCheck == true)
        {
            if(MotionSickVignetteTrigger != null)
            {
                MotionSickVignetteTrigger(true);
            }
            else
            {
                MotionSickVignetteTrigger(false);
            }
        }
        else
        {
            MotionSickVignetteTrigger(false);
        }
    }
}
