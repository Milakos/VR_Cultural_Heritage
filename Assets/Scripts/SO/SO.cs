using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (fileName = "Item", menuName = "Inventory/Item", order = 1)]
public class SO : ScriptableObject
{
    [Header("Item Identity")]
    [Space(10)]
    public int ID;
    public string ItemName;
    public Type type;
    
    public GameObject prefabGrabbable;
    public GameObject prefabSocket;
    
    public bool CanStored;
    public bool CanUseAsTool;

    [Header("Properties")]
    [Space(10)]
    public Sprite Icon;
    [Space(5)]
    [TextArea(0,10)]
    public string Description;
}

public enum Type 
{
    Branch, Charchoal, Silver, Tool
}
