using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCauldronHandler : MonoBehaviour
{
    public QuestSO quest;
    public GameObject Reward;
    public GameObject potLight;

    public Quest.Achivement PotPlacedAchievement;

    private void Start()
    {
        potLight.SetActive(false);
        Reward.SetActive(false);
    }
    public void PlaceCauldron() 
    {
        if (PotPlacedAchievement != null) 
        {
            potLight.SetActive(true);
            PotPlacedAchievement(quest, true, Reward);
        }
    }
}
