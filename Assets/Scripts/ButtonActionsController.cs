using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class ButtonActionsController : MonoBehaviour
{
    public InputActionProperty[] inputButtonAction;
    UnityEvent myEvent = new UnityEvent();
    public bool isPressedBool;
    bool pressed;

    private void Start() 
    {
        myEvent.AddListener(QuitActionButton);  
                
    }
    // Update is called once per frame
    void Update()
    {
        ButtonControllersInput();
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
                if(buttonXPressed)
                {
                     print("You Pressed " + inputButtonAction[1].action.name);
                }
                if (buttonYPressed)
                {
                    print("You Pressed " + inputButtonAction[3].action.name);  
                    myEvent.Invoke(); 
                }  
        }
    }

    public void QuitActionButton()
    {
        FindObjectOfType<MainMenu>().QuitGame();
    }   
}
