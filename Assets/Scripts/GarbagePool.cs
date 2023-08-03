using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbagePool : MonoBehaviour
{
    public Dictionary<SO, Queue<GameObject>> grabables = new Dictionary<SO, Queue<GameObject>>();

    public Queue<GameObject> branches = new Queue<GameObject>();
    public Queue<GameObject> Ores = new Queue<GameObject>();

    public Dictionary<SO, GameObject> tools = new Dictionary<SO, GameObject>();

    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float offset;
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
                tools[item].transform.position = FindTargetPosition();
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
                if (item.type == Type.Branch)
                {
                    if (branches.Count != 0)
                    {
                        GameObject ob = branches.Dequeue();
                        ob.SetActive(true);
                        ob.transform.position = FindTargetPosition();
                    }
                    else
                    {
                        //
                        Queue<GameObject> itemQueue = grabables[item];
                        if (itemQueue.Count > 0)
                        {
                            GameObject ob = itemQueue.Dequeue();
                            ob.SetActive(true);
                            ob.transform.position = FindTargetPosition();
                        }
                        else
                        {
                            grabables.Remove(item);
                        }
                        //
                        /*grabables[item].Dequeue();*/

                    }
                }
                else if (item.type == Type.Silver)
                {
                    if (Ores.Count != 0)
                    {
                        GameObject ob = Ores.Dequeue();
                        ob.SetActive(true);
                        ob.transform.position = FindTargetPosition();
                    }
                    else
                    {
                        // Handle when the Ores queue is empty
                        Queue<GameObject> itemQueue = grabables[item];
                        if (itemQueue.Count > 0)
                        {
                            GameObject ob = itemQueue.Dequeue();
                            ob.SetActive(true);
                            ob.transform.position = FindTargetPosition();
                        }
                        else
                        {
                            grabables.Remove(item);
                        }
                    }

                    /*.gameObject.SetActive(true);*/
                }
                else
                {
                    grabables.Remove(item);
                }
            }
        }

    }

    public Vector3 FindTargetPosition()
    {
        // Let's get a position infront of the player's camera
        return cameraTransform.position + (cameraTransform.forward * offset);
    }
}
