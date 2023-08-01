using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHandler : MonoBehaviour
{
    public ParticleSystem particles;
    public int overallHits = 15;
    public int hit = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickAxe"))
        {
            if (hit < overallHits)
            {
                hit++;
                if (hit >= overallHits)
                {
                    particles.Play();
                    print("You take Silver Ore");
                    hit = 0;
                }
            }


            print("Axe INteracted with Rock");
        }
    }
}
