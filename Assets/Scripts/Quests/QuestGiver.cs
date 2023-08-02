using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public List<QuestSO> quests = new List<QuestSO>();

    public List<QuestSO> currentQuest = new List<QuestSO>();
    private int currentQuestIndex = 0;
    private int nextIndex = 0;

    public GameObject player;

    public QuestUI questDisplay;

    private void OnEnable()
    {
        FindObjectOfType<TreeHandler>().treeGathered += UpdateQuestProgress;
        FindObjectOfType<RockHandler>().rocksGathered += UpdateQuestProgress;
        FindObjectOfType<SmelterHandler>().smeltGathered += UpdateQuestProgress;
    }
    private void Start()
    {
        player = FindObjectOfType<GameObject>();
        foreach (QuestSO quest in quests)
        {
            quest.isCompleted = false;
        }
        currentQuest.Add(quests[currentQuestIndex]);
        questDisplay.Quest(currentQuest[currentQuestIndex].questName, currentQuest[currentQuestIndex].description);
  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            questDisplay.Activate(true);
        }       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            questDisplay.Activate(false);
        }
    }
    public void UpdateQuestProgress(QuestSO quest, bool completed)
    {
        quest.isCompleted = completed;

        if (quest == currentQuest[currentQuestIndex] && completed)
        {
            currentQuest.Remove(quest);
            nextIndex++;

            if (HasQuestsRemain())
            {
                currentQuest.Add(quests[nextIndex]);
                questDisplay.Quest(quests[nextIndex].questName, quests[nextIndex].description);
                print("New Quest");
            }
            else 
            {
                print("No more Quests");
            }
            
        }

    }

    public bool HasQuestsRemain() 
    {

        if (nextIndex < quests.Count)
        {
            return true;
        }
        else 
        {
            return false;            
        }
    }
}
