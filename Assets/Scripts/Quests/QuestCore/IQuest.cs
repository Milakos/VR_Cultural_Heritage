using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IQuest
{
    public void StartQuest();
    public void QuestInProgress();
    public void EndQuest();
}
