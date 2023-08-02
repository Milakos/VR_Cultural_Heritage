using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmelterHandler : MonoBehaviour
{
    public delegate void Achivement(QuestSO quest, bool completed);
    public event Achivement smeltGathered;

    public QuestSO quest;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            print("SMELT");
            if (smeltGathered != null)
            {
                smeltGathered(quest, true);
            }
        }
    }
}
