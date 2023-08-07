using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LightFireHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem particles;
    [SerializeField] Light lightToggle;
    public QuestSO quest;
    public QuestGiver questGiver;
    public GameObject Reward;
    public int leftwoods;


    [SerializeField] XRSocketInteractor[] sockets;
    private List<XRSocketInteractor> XRSockets = new List<XRSocketInteractor>();

/*    public delegate void Achivement(QuestSO quest, bool completed);
    public event Achivement woodPlaced;*/

    public Quest.Achivement woodAchieved;

    private void Awake()
    {
        leftwoods = quest.targetAmount;

        foreach (XRSocketInteractor socket in sockets) 
        {
            XRSockets.Add(socket);
        }
    }
    private void Start()
    {
        if(Reward != null)
            Reward.SetActive(false);
    }
    public void RemoveItemFromList(XRSocketInteractor socketItem) 
    {
        leftwoods--;
        XRSockets.Remove(socketItem);
        if (XRSockets.Count == 0 && leftwoods == 0) 
        {
/*            if (woodPlaced != null) 
            {*/
                /*woodPlaced(quest, true);*/
                if(woodAchieved != null)
                    woodAchieved(quest, true, Reward);
            /*}*/
            
            print("No more items");
        }
    }

}
