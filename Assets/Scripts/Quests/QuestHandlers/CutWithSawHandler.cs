using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutWithSawHandler : QuestBase
{
    public Quest.Achivement cutAchieved;
    [SerializeField] GameObject silverSheet;
    public override void Awake()
    {
        base.Awake();
    }
    public override void Start()
    {
        base.Start();
    }
    public override void StartQuest()
    {
        base.StartQuest();
    }
    public override void QuestInProgress()
    {
        hit = 0;

        totalAmountLeft--;
        base.QuestInProgress();
    }
    public override void Update()
    {
        base.Update();
    }
    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Saw"))
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
            print("Saw Interacted with Silver");
        }
        base.OnTriggerEnter(other);
    }
    public override void EndQuest()
    {
        silverSheet.SetActive(false);
        particles.Play();
        if (cutAchieved != null)
        {
            lightObject.SetActive(true);
            print("Quest Completed");
            cutAchieved(quest, true, Reward);
        }
        base.EndQuest();
    }
    public override void AudioEvent()
    {
        base.AudioEvent();
    }
}
