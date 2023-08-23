using FMODUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class TreeHandler : QuestBase
{
    /// <summary>
    /// The TreeHandler class is responsible for checking if an object with the tag Axe is collides with this game object
    /// If yes, then calculates the hits that collides and implementing different logic. When collides it counts the hit,
    /// then when the hits are surpasing the overall hits that needed to be counted for spawning the collectable, the collectable 
    /// will be enabled as a particle system, and will reset the hits. When this logic completed the total amount of tries reduced 
    /// as the list of objects. when everything is completed the event of completedaction is invoked to the subscriber gustGiver to
    /// change to the next quest.
    /// </summary>
    /// 
    public Quest.Achivement treeAchieved;
    public override void Awake()
    {
        base.Awake();
    }
    public override void Start()
    {
        base.Start();
    }
    public override void Update()
    {
        base.Update();
    }
    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Axe"))
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
            print("Axe INteracted with Tree");
            
        }
        base.OnTriggerEnter(other);
    }
    public override void StartQuest()
    {
        base.StartQuest();
    }
    public override void QuestInProgress()
    {
        particles.Play();
        AudioReward();
        base.SpawnObject(objectsToSpawn[objectCounter], true);

        print("You take Tree wood branches");
        hit = 0;

        totalAmountLeft--;
        base.QuestInProgress();
    }
    public override void EndQuest()
    {
        if (treeAchieved != null)
        {
            print("Quest Completed");
            treeAchieved(quest, true, null);
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
