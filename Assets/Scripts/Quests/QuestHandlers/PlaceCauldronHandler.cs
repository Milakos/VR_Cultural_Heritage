using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCauldronHandler : QuestBase
{
    public Quest.Achivement PotPlacedAchievement;
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
        if (PotPlacedAchievement != null)
        {
            lightObject.SetActive(true);
            PotPlacedAchievement(quest, true, Reward);
        }
        base.EndQuest();
    }
/*    public void PlaceCauldron() 
    {
        if (PotPlacedAchievement != null) 
        {
            lightObject.SetActive(true);
            PotPlacedAchievement(quest, true, Reward);
        }
    }*/
}
