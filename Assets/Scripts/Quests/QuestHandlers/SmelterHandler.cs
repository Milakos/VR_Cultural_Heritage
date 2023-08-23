using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmelterHandler : QuestBase
{  
    public GameObject timer;
    public override void Awake()
    {
        base.Awake();
    }
    public override void Start()
    {
        timer.SetActive(false);
        base.Start();
    }
    public override void StartQuest()
    {
        base.StartQuest();
    }
    public override void QuestInProgress()
    {
        base.QuestInProgress();
    }
    public override void EndQuest()
    {
        if (timer != null)
            timer.SetActive(true);
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
    /*    public void SilverPlacedAtTheCauldron() 
        {

        }*/
}
