using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public TMP_Text timeText;
    public Quest.Achivement smeltAchieved;
    SmelterHandler smelterHandler;
    private void Awake()
    {
        smelterHandler = FindObjectOfType<SmelterHandler>();
    }
    private void OnEnable()
    {
        
        // Starts the timer automatically
        timerIsRunning = true;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                if (smelterHandler.quest == FindObjectOfType<QuestGiver>().currentQuest[0])
                {
                    if (smeltAchieved != null)
                    {
                        smeltAchieved(smelterHandler.quest, true, smelterHandler.Reward);
                    }
                    Destroy(this.gameObject);
                }
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}