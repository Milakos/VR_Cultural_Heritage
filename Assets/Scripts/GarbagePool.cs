using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbagePool : MonoBehaviour
{
    public Dictionary<SO , Queue<GameObject>> grabables = new Dictionary<SO, Queue<GameObject>>();

    public Queue<GameObject> grabbables = new Queue<GameObject>();

    public Dictionary<SO, GameObject> tools = new Dictionary<SO, GameObject>();

    ButtonManager[] manager;
    private void Awake()
    {
        manager = FindObjectsOfType<ButtonManager>();

        foreach (ButtonManager mn in manager)
        {
            mn.SpawnRemovedObject += SpawnObject;
        }
    }
    private void SpawnObject(SO item)
    {
        if (item.CanUseAsTool)
        {
            if (tools.ContainsKey(item))
            {
                tools[item].gameObject.SetActive(true);
                tools.Remove(item);
            }
            else
            {
                print("No Tool in Inventory");
            }
        }
        else 
        {
            if (grabables.ContainsKey(item))
            {
                grabbables.Dequeue().SetActive(true);
                /*.gameObject.SetActive(true);*/              
            }
            else 
            {
                grabables.Remove(item);
            }
        }
    }
}
