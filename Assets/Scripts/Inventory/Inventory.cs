using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public ButtonManager[] btnManager;

    private Dictionary<SO, int> items = new Dictionary<SO, int>();

    [HideInInspector] public List<InteractableManager> interactables = new List<InteractableManager>();

    private void Awake()
    {
        foreach (InteractableManager manager in interactables)
        {
            manager.MountInventory += AddItem;           
        }
        foreach (ButtonManager button in btnManager) 
        {
           if(button != null)
                button.Remove += RemoveItem;                      
        }
    }

    public void AddItem(SO item, int ID) 
    {
        if (HasItem(item))
        {
            if (HasID(ID))
            {
                int existingID = items[item];
                int dictionaryItemIndex;
                

                if (ID.GetHashCode() == existingID.GetHashCode())
                {
                    dictionaryItemIndex = items.Values.ToList().IndexOf(ID);

                    btnManager[dictionaryItemIndex].IncreaseQuantity(1);

                    print(dictionaryItemIndex);                              
                }
                else
                {
                    print("Interacted with an item with a different ID: " + ID + "" + item.GetHashCode());
                }
            }
            else
            {               
                print("NO ID Tracked");
            }
        }
        else
        {           
            items.Add(item, ID);
            //
            /*int dictionaryItemIndex = items.Values.ToList().IndexOf(ID);*/
            //
            ///
            int dictionaryItemIndex = -1;
            /// ///
            /// ///            
            for (int i = 0; i < btnManager.Length; i++)
            {
                if (!btnManager[i].hasItemInSlot)
                {
                    dictionaryItemIndex = i;
                    break;
                }
            }
            if (dictionaryItemIndex >= 0)
            {
                btnManager[dictionaryItemIndex].ChangeUIElement(item.Icon, item.Description, true, 1, item);
                
            }
            ///
            ///
            /*btnManager[dictionaryItemIndex].ChangeUIElement(item.Icon, item.Description, false, 1, item);*/
                    

            print("Interacted with a new item with ID: " + ID);
        }
    }

    public void RemoveItem(SO item)
    {
        if (HasItem(item))
        {
            items.Remove(item);
            #region ChatGPT
            /* 
                        /* int removedItemIndex = -1;*//*

             for (int i = 0; i < btnManager.Length; i++)
             {
                 if (btnManager[i] != null && btnManager[i].item == item)
                 {
                     btnManager[i].ClearSlotData(null, null, false, null);
                     *//*removedItemIndex = i;*/
            /*break;*//*
        }

    }*//*
            if (removedItemIndex >= 0)
            {
                // Move items after the removed item to fill the gap
                for (int i = removedItemIndex; i < btnManager.Length - 1; i++)
                {
                    // If the next slot is null, clear the current slot and break the loop
                    if (btnManager[i + 1] == null)
                    {
                        btnManager[i].ChangeUIElement(null, null, false, 0 , null);
                        btnManager[i].Quantity = 0;
                        btnManager[i].hasItemInSlot = false;
                        break;
                    }

                    // Swap the item data with the next slot
                    btnManager[i].ChangeUIElement(btnManager[i + 1].image.sprite, btnManager[i + 1].textDescription.text, true, btnManager[i + 1].Quantity, btnManager[i + 1].item);
                    btnManager[i].hasItemInSlot = true;
                    *//*btnManager[i].Quantity = btnManager[i + 1].Quantity;*//*
                }


            }
            else 
            {
                
                // Clear the last item's data (to avoid duplicate)
                btnManager[btnManager.Length - 1].ChangeUIElement(null, null, false, 0, null);
                btnManager[btnManager.Length - 1].hasItemInSlot = false;

                // Update the quantity for the last slot (now empty)
                *//* btnManager[btnManager.Length - 1].Quantity = 0;*//*
                // Remove the item from the dictionary


            }

            items.Remove(item);*/
            #endregion ChatGPT

            Debug.Log("Succesfully Removed "  + item.name + "(s) from the inventory.");
        }
        else
        {
            Debug.Log(item.name + " not found in the inventory.");
        }
    }

    // Check if an item is present in the inventory
    public bool HasItem(SO item)
    {
        return items.ContainsKey(item);
    }
    public bool HasID(int value) 
    {
        foreach (int existingID in items.Values) 
        {
            if (value == existingID) 
            {
                return true;
            }
        }
        return false;
    }
}
