using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button button;
    public Image image;
    public TMP_Text textDescription;
    public TMP_Text textQuantity;
    
    public SO item;
    public int Quantity;
    public bool hasItemInSlot;

    public delegate void RemoveItemEvent(SO item);
    public event RemoveItemEvent Remove;


    private void Awake()
    {
        hasItemInSlot = false;
        button.onClick.AddListener(DecreaseQuantity);
    }
    private void Update()
    {
        textQuantity.text = Quantity.ToString();
    }    
    public void ChangeUIElement(Sprite sprite, string text, bool slot, int quantity, SO item)
    {
        ChangeButtonImage(sprite);
        ChangeButtonDescription(text);
        IncreaseQuantity(quantity);
        ChangeSOItem(item);
        hasItemInSlot = slot;
    }
    public void MinusChangeUIElement(Sprite sprite, string text, bool slot, SO item)
    {
        ChangeButtonImage(sprite);
        ChangeButtonDescription(text);
        DecreaseQuantity();
        ChangeSOItem(item);
        hasItemInSlot = slot;
    }
    public void ClearSlotData(Sprite sprite, string text, bool slot,  SO item) 
    {
        ChangeButtonImage(sprite);
        ChangeButtonDescription(text);
        ChangeSOItem(item);
        hasItemInSlot = slot;
        /*Quantity = quantity;*/
    }
    public void ChangeButtonImage(Sprite sprite) 
    {
        image.sprite = sprite;
    }
    public void ChangeButtonDescription(string text)
    {
        textDescription.text = text;
    }
    public void ChangeSOItem(SO newItem) 
    {
        item = newItem;
    }
    #region Quantity
    public int IncreaseQuantity(int quantity)
    {
        Quantity += quantity;
        return Quantity;
    }
    public void DecreaseQuantity() 
    {
        if (Quantity > 0)
        {
            Quantity--;
        }
        if (Quantity == 0)
        {
            Quantity = 0;
            hasItemInSlot = false;


            

            if (item != null) 
            {

                if (Remove != null)
                {
                    Remove(item);
                    
                    
                    
                }
            }
            FindObjectOfType<InventoryUIManager>().OnImageClicked();
            /*ClearSlotData(null, null, false, null);*/

            print("No more Items to withdraw");
        }       
    }
    #endregion Quantity

}
