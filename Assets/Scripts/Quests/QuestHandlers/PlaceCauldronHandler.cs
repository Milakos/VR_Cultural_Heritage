using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCauldronHandler : QuestBase
{
    /*public GameObject potLight;*/

    public Quest.Achivement PotPlacedAchievement;
    public override void Awake()
    {
        base.Awake();
    }
    public override void Start()
    {
        base.Start();
        /*potLight.SetActive(false);*/
    }
    public void PlaceCauldron() 
    {
        if (PotPlacedAchievement != null) 
        {
            lightObject.SetActive(true);
            PotPlacedAchievement(quest, true, Reward);
        }
    }
}
