using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null) 
        {
            print("Found more than one Audio Manager in the Scene");
        }
        instance = this;
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos) 
    {
        RuntimeManager.PlayOneShot(sound, worldPos);      
    }

   
}
