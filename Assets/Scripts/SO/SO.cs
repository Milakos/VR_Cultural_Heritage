using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Item", menuName = "Inventory/Item", order = 1)]
public class SO : ScriptableObject
{    
    [Header("Item Identity")]
    [Space(10)]
    public int ItemID;
    public Type type;
    public string ItemName;
    public bool CanStored;
    public bool CanUseAsTool;

    [Header("Properties")]
    [Space(10)]
    public Sprite Icon;

    [TextArea(0,10)]
    public string Description;
}

public enum Type 
{
    Branch, Charchoal, Silver
}
