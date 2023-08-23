using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammeringQuestHandler : QuestBase
{
    [SerializeField] GameObject Ingot;
    Vector3 finalScale;    
    public Quest.Achivement hammeringSilver;
    [SerializeField] private Material m_CarvedSilver;
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
        if (other.CompareTag("Hammer"))
        {
            if (hit < overallHits)
            {
                hit++;
                AudioEvent();
                CalculateIngotScale();                
                
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

            print("Hammer Interacted With Ingot");
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

        print("You Hammer Silver Ingot");
        hit = 0;

        totalAmountLeft--;
        base.QuestInProgress();
    }
    public override void EndQuest()
    {
        Ingot.GetComponent<MeshRenderer>().material = m_CarvedSilver;

        if (hammeringSilver != null)
        {
            hammeringSilver(quest, true, Reward);
        }
        base.EndQuest();
    }
    void CalculateIngotScale() 
    {
        finalScale = new Vector3(0.03f, -0.001f, 0.05f);
        Ingot.transform.localScale += finalScale;
    }
    public override void AudioEvent()
    {
        base.AudioEvent();
    }
}
