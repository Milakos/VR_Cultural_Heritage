using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammeringQuestHandler : QuestBase
{
    [SerializeField] GameObject Ingot;
    Vector3 finalScale;    
    public Quest.Achivement hammeringSilver;
    public override void Awake()
    {
        base.Awake();
    }
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }
    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hammer"))
        {
            if (hit < overallHits)
            {
                hit++;
                
                CalculateIngotScale();                
                
                if (hit >= overallHits)
                {
                    /*particles.Play();*/
                    print("You Hammer Silver Ingot");
                    hit = 0;

                    totalAmountLeft--;
                }
            }
            if (totalAmountLeft == 0)
            {
                if (hammeringSilver != null)
                {
                    hammeringSilver(quest, true, Reward);
                }
            }
            if (objectCounter < objectsToSpawn.Length - 1)
                objectCounter++;

            print("Hammer Interacted With Ingot");
        }
        base.OnTriggerEnter(other);
    }

    void CalculateIngotScale() 
    {
        finalScale = new Vector3(0.04f, -0.001f, 0.07f);
        Ingot.transform.localScale += finalScale;
    }
}
