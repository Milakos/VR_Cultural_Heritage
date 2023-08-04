using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quests/Quest", order = 1)]
public class QuestSO : ScriptableObject
{
    public string questName;
    [TextArea(0, 50)]
    public string description;
    public QuestType type;
    public int targetAmount;
    
    public bool isCompleted;
    public enum QuestType { CollectWoodBranches, CollectSilverOre, SmeltOre }
}
