using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class ButtonActionsController : MonoBehaviour
{

    /////////////////// /////// Event Declairation \\\\\\\\\\\\\\\\\\\ \\\\\\\\\\\\\\\\\

    // Event with the right Stick for rotation
    public delegate void mostionSickness(bool i);
    public event mostionSickness rightStickRotateAction;
    
    // Event that controls the left grip for blur image in teleportation
    public delegate void mostionSicknessTeleport(bool i);
    public event mostionSicknessTeleport leftGripAction;

    // Event that controlls the Switch between layers in teleportation with the X Button
    public delegate void teleportSwitch(bool indexMask);
    public event teleportSwitch xButton;

    bool check = false;

    // Event that controls the exit of the game with the Y Button in left controller
    public event Action yButton;

    /////////////////// /////// Event Declairation \\\\\\\\\\\\\\\\\\\ \\\\\\\\\\\\\\\\\

    [Header("Buttons")]
    public InputActionProperty[] inputButtonAction;
    
    [Header("Controller Sticks")]
    public InputActionProperty gripStick;

    public int indexLayer = 0;

    void Update()
    {
        ButtonControllersInput();
        SwitchStickInput();
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
                if(buttonXPressed)
                {
                    
                    if (xButton != null)
                    {
                        check = !check;
                        if(check == false)
                        {
                            xButton(true);
                            // check = !check;
                        }
                        
                        else
                        {
                            xButton(false);
                            // check = !check;
                        }
                    }
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

    public void SwitchStickInput()
    {
        // Right Stick /////////////////////
        if(inputButtonAction[4].action.IsPressed())
        {
            if(rightStickRotateAction != null)
            {
                rightStickRotateAction(true);
                print("Rotation");
            }
        }
        else
        {
            rightStickRotateAction(false);
        } 
        //LeftStick ///////////////////////
        if(gripStick.action.IsPressed())
        {
            if(leftGripAction != null)
            {
                leftGripAction(true);
                print("Teleport");
            }
        }
    }

    public void SwitchTeleportwithButtonX()
    {
        
    }
}
