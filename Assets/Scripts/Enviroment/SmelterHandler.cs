using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmelterHandler : MonoBehaviour
{  
    public GameObject Reward;
    public QuestSO quest;
    public GameObject timer;
    public GameObject[] SilverSockets;
    private void Start()
    {
        timer.SetActive(false);
        if(Reward != null)
            Reward.SetActive(false);
        foreach (GameObject silver in SilverSockets) 
        {
            silver.gameObject.SetActive(false);
        }
    }
    public void SilverPlacedAtTheCauldron() 
    {
        if(timer != null)
            timer.SetActive(true);
    }
}
