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
    
    private void Awake()
    {
        btnManager = FindObjectOfType<ButtonManager>();
        uiManager = FindObjectOfType<UI_Manager>();
       
    }
    private void OnEnable()
    {
        foreach (InteractableManager manager in interactables) 
        {
            manager.MountInventory += AddItem;
        }
        
    }
    private void OnDisable()
    {
        foreach (InteractableManager manager in interactables)
        {
            manager.MountInventory -= AddItem;
        }
    }

    public void AddItem(SO item) 
    {
        items.Add(item);
        uiManager.ChangeInventoryButtonImage(item.Icon);
        btnManager.item = item;
    }
    public void RemoveItem(SO item) 
    {
        items.Remove(item);
        uiManager.ClearInventoryButtonImage();
        btnManager.ClearSOReference();
    }
    public bool HasItem(SO item) 
    {
        return item;
    }
    public void GetItem() 
    {
        SO item = btnManager.item;

        if (HasItem(item) == true) 
        {
            RemoveItem(item);
            GameObject obj = Instantiate(item.prefabGrabbable, Vector3.zero ,Quaternion.identity);
        }
    }

   
}
