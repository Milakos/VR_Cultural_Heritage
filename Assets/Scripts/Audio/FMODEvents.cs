using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class FMODEvents : MonoBehaviour
{
    [field: Header("Quest Completed SFX")]
    [field: SerializeField] public EventReference questComplete { get; private set; }
    [field: SerializeField] public EventReference Ambience { get; private set; }
    
    public static FMODEvents instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one FMOD Events instance in the Scene");
        }
        instance = this;
    }
    private void Start()
    {
        RuntimeManager.PlayOneShot(Ambience, this.transform.position);
    }
}
