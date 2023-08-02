using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class TreeHandler : MonoBehaviour
{    
    public  int overallHits = 15;
    public int hit = 0;
    public int totalAmountLeft;

    public int objectCounter = 0;

    public delegate void Achivement(QuestSO quest, bool completed);
    public event Achivement treeGathered;

    public QuestSO quest;
    public QuestGiver giver;
    public GameObject[] branchTree;
    public ParticleSystem particles;

    private void Awake()
    {
        totalAmountLeft = quest.targetAmount;        
        GetComponent<BoxCollider>().isTrigger = true;
    }
    private void Start()
    {
        foreach (GameObject ob in branchTree)
        {
            SpawnObject(ob, false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Axe")) 
        {
            if (hit < overallHits) 
            {
                hit++;
                if (hit >= overallHits) 
                {
                    particles.Play();

                    SpawnObject(branchTree[objectCounter], true);

                    print("You take Tree wood branches");
                    hit = 0;
                    
                    totalAmountLeft--;
                }
            }
            if (totalAmountLeft == 0)
            {

                if (treeGathered != null)
                {
                    print("Quest Completed");

                    treeGathered(quest, true);
                }
            }
            if (objectCounter < branchTree.Length -1)
                objectCounter++;
            print("Axe INteracted with Tree");
        }
    }

    void SpawnObject(GameObject obj, bool visible)
    {
        obj.SetActive(visible);
    }
}
