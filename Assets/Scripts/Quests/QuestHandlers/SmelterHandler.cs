using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmelterHandler : QuestBase
{  
    public GameObject timer;

    public override void Start()
    {
        timer.SetActive(false);
        base.Start();
    }
    public void SilverPlacedAtTheCauldron() 
    {
        if(timer != null)
            timer.SetActive(true);
    }
}
