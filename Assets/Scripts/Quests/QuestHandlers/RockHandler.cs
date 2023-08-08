using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class RockHandler : QuestBase
{
    public Quest.Achivement rocksAchieved;

    public override void Awake()
    {
        base.Awake();
    }
    public override void Start()
    {
        base.Start();
    }
    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickAxe"))
        {
            if (hit < overallHits)
            {
                hit++;
                if (hit >= overallHits)
                {
                    particles.Play();

                    base.SpawnObject(objectsToSpawn[objectCounter], true);

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
            if (objectCounter < objectsToSpawn.Length - 1)
                objectCounter++;
            
            print("Axe INteracted with Rock");
        }
    }
}
