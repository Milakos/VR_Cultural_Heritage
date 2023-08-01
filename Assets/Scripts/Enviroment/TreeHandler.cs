using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHandler : MonoBehaviour
{
    public ParticleSystem particles;
    public  int overallHits = 15;
    public int hit = 0;
    public int totalAmountLeft;

    public delegate void Achivement(QuestSO quest, bool completed);
    public event Achivement treeGathered;

    public QuestSO quest;
    public QuestGiver giver;
    private void Awake()
    {
        totalAmountLeft = quest.targetAmount; 
    }
    private void Update()
    {

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
                    print("You take Tree wood branches");
                    hit = 0;
                    
                    totalAmountLeft--;
                }
            }
            if (totalAmountLeft == 0)
            {

                if (treeGathered != null)
                {
                    print("YEYYYYYYYYYYYYYYY");

                    treeGathered(quest, true);
                }
            }

            print("Axe INteracted with Tree");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Axe")) 
        {
            print("Axe Stop Interacting");
        }
    }
}
