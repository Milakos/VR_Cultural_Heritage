using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private TMP_Text textTeleport;
    [SerializeField] private Toggle btn;
    [SerializeField] private Image image;
    
    private void Awake() 
    {    
        textTeleport = GetComponentInChildren<TMP_Text>();    
    }
    private void Start() 
    {
        obj.SetActive(false);
    }
    private void OnEnable() 
    {
        
        FindObjectOfType<TeleportSwitch>().changeButtonText += ChangeToggleText;
        FindObjectOfType<ButtonActionsController>().activateCanvasUI += ActivateUICanvas;    
    }
    public void ChangeToggleText(bool changeText)
    {
        if(changeText == true)
            textTeleport.text = "Teleport";
        else
            textTeleport.text = "Interact";
    }

    public void ActivateUICanvas(bool i)
    {
        if(i == true)
            obj.SetActive(true);
        else
            obj.SetActive(false);
    }

    public void ChangeInventoryButtonImage(Sprite item) 
    {
        image.sprite = item;
    }
    public void ClearInventoryButtonImage() 
    {
        image.sprite = null;
    }

}
