using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarvingSilverSheetHandler : QuestBase
{
    public Quest.Achivement carvAchieved;
    [SerializeField] GameObject Ingot;
    [SerializeField] private Material m_CarvedSilver;

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
        if (other.CompareTag("ScrewDriver")) 
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
            print("ScrewDriver Interacted with Silver");

        }
        base.OnTriggerEnter(other);
    }
    public override void EndQuest()
    {
        Ingot.GetComponent<MeshRenderer>().material = m_CarvedSilver;

        if (carvAchieved != null)
        {
            print("Quest Completed");
            carvAchieved(quest, true, Reward);
        }
        base.EndQuest();
    }
    public override void AudioEvent()
    {
        base.AudioEvent();
    }
}
