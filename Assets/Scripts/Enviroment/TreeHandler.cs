using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHandler : MonoBehaviour
{
    public ParticleSystem particles;
    public int overallHits = 15;
    public int hit = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Axe")) 
        {
            if (hit < overallHits) 
            {
                hit++;
                if (hit >= overallHits) 
                {
                    particles.Play();
                    print("You take Tree wood branches");
                    hit = 0;
                }
            }
            

            print("Axe INteracted with Tree");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Axe")) 
        {
            print("Axe Stop Interacting");
        }
    }
}
