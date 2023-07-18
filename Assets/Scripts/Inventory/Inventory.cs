using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<SO> items = new List<SO>();
    UI_Manager uiManager;
    ButtonManager btnManager;
    
    public List<InteractableManager> interactables = new List<InteractableManager>();

    public bool HasItem { get; private set; }


    private void Awake()
    {
        btnManager = FindObjectOfType<ButtonManager>();
        uiManager = FindObjectOfType<UI_Manager>();

        foreach (InteractableManager manager in interactables)
        {
            manager.MountInventory += AddItem;
        }
    }
    public void AddItem(SO item) 
    {
        items.Add(item);
        HasItem = true;

        uiManager.ChangeInventoryButtonImage(item.Icon);
        btnManager.item = item;
    }
    public void RemoveItem(SO item) 
    {        
        if (items.Count <= 1) 
        {           
            items.Remove(item);
            uiManager.ClearInventoryButtonImage();
            btnManager.ClearSOReference();
        }
        if (items.Count > 0) 
        {
            items.Remove(item);
        }
    }

    public void GetItem() 
    {
        SO item = btnManager.item;

        if (HasItem)
        {
            RemoveItem(item);
            print("REMOVE");
        }
        if (!HasItem) 
        {
            print("No Item");
        }
    }

   
}
