using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LightFireHandler : QuestBase
{
    [SerializeField] private XRSocketInteractor[] sockets;
    private List<XRSocketInteractor> XRSockets = new List<XRSocketInteractor>();

    public Quest.Achivement woodAchieved;

    public override void Awake()
    {
        base.Awake();

        foreach (XRSocketInteractor socket in sockets) 
        {
            XRSockets.Add(socket);
        }
    }
    public override void Start()
    {
        base.Start();
    }
    public override void Update()
    {
        base.Update();
    }
    public void RemoveItemFromList(XRSocketInteractor socketItem) 
    {
        totalAmountLeft--;
        XRSockets.Remove(socketItem);
        if (XRSockets.Count == 0 && totalAmountLeft == 0) 
        {
            EndQuest();
        }
    }

    public override void StartQuest()
    {
        base.StartQuest();
    }
    public override void QuestInProgress()
    {
        base.QuestInProgress();
    }
    public override void EndQuest()
    {
        lightObject.SetActive(true);
        particles.Play();
        
        if (woodAchieved != null)
        {
            woodAchieved(quest, true, Reward);
        }

        print("No more items");
        base.EndQuest();
    }
}
