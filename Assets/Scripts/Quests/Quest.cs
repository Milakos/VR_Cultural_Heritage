using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public string questName;
    public string description;
    public QuestType type;
    public int targetAmount;
    public bool isCompleted;

    public enum QuestType
    {
        CollectWoodBranches,
        CollectSilverOre
    }

    public Quest(string name, string description, QuestType type, int targetAmount)
    {
        this.questName = name;
        this.description = description;
        this.type = type;
        this.targetAmount = targetAmount;
        this.isCompleted = false;
    }
}
