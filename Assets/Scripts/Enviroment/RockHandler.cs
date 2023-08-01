using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHandler : MonoBehaviour
{
    public ParticleSystem particles;
    public int overallHits = 15;
    public int hit = 0; 
    public int totalAmountLeft;

    public delegate void Achivement(QuestSO quest, bool completed);
    public event Achivement rocksGathered;

    public QuestSO quest;
    private void Awake()
    {
        totalAmountLeft = quest.targetAmount;
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
                    print("You take Silver Ore");
                    hit = 0;
                    totalAmountLeft--;
                }
            }
            if (totalAmountLeft == 0)
            {
                if (rocksGathered != null)
                {
                    rocksGathered(quest, true);
                }
            }
            print("Axe INteracted with Rock");
        }
    }
}
