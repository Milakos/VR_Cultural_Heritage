using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class RockHandler : MonoBehaviour
{    
    public int overallHits = 15;
    public int hit = 0; 
    public int totalAmountLeft;

    public int objectCounter = 0;
    
/*    public delegate void Achivement(QuestSO quest, bool completed);
    public event Achivement rocksGathered;*/

    public Quest.Achivement rocksAchieved;
    public GameObject Reward;
    public QuestSO quest;
    public QuestGiver giver;
    public GameObject[] silverOres;
    public ParticleSystem particles;

    private void Awake()
    {
        totalAmountLeft = quest.targetAmount;
        GetComponent<BoxCollider>().isTrigger = true;
    }
    private void Start()
    {
        if(Reward != null)
            Reward.SetActive(false);

        foreach (GameObject ob in silverOres)
        {
            SpawnObject(ob, false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickAxe"))
        {
            if (hit < overallHits)
            {
                hit++;
                if (hit >= overallHits)
                {
                    particles.Play();

                    SpawnObject(silverOres[objectCounter], true);

                    print("You take Silver Ore");
                    hit = 0;

                    totalAmountLeft--;
                }
            }
            if (totalAmountLeft == 0)
            {
                if (rocksAchieved != null)
                {
                    rocksAchieved(quest, true, Reward);
                }
            }
            if (objectCounter < silverOres.Length - 1)
                objectCounter++;
            
            print("Axe INteracted with Rock");
        }
    }

    void SpawnObject(GameObject obj, bool visible)
    {
        obj.SetActive(visible);
    }
}
