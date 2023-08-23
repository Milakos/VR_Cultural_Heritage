using FMODUnity;
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
                AudioEvent();
                if (hit >= overallHits)
                {
                    QuestInProgress();
                }
            }
            if (totalAmountLeft == 0)
            {
                EndQuest();
            }
            if (objectCounter < objectsToSpawn.Length - 1)
                objectCounter++;
            
            print("Axe INteracted with Rock");
        }
    }
    public override void StartQuest()
    {
        base.StartQuest();
    }
    public override void QuestInProgress()
    {
        particles.Play();

        base.SpawnObject(objectsToSpawn[objectCounter], true);
        
        AudioReward();
        
        print("You take Silver Ore");
        hit = 0;

        totalAmountLeft--;
        base.QuestInProgress();
    }
    public override void EndQuest()
    {
        if (rocksAchieved != null)
        {
            rocksAchieved(quest, true, Reward);
        }
        base.EndQuest();
    }
    public override void AudioEvent()
    {
        base.AudioEvent();
    }
    public override void AudioReward()
    {
        base.AudioReward();
    }

}
