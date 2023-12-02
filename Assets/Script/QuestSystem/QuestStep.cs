using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestStep : MonoBehaviour
{
    private bool isFinished = false;
    private string questID;
    private int stepIndex;
    public void InitializeQuestStep(string questID, int stepIndex, string questStepState)
    {
        this.questID = questID;
        this.stepIndex = stepIndex;
        if(questStepState != null && questStepState != "")
        {
            SetQuestStepState(questStepState);
        }
    }

    protected void FinishQuestStep(string questID)
    {
        if(!isFinished)
        {   
            isFinished = true;
            GameEventManager.instance.questEvents.AdvanceQuest(questID);
            Destroy(this.gameObject);
        }
    }

    protected void ChangeState(string newState)
    {
        GameEventManager.instance.questEvents.QuestStepStateChange(questID, stepIndex, new QuestStepState(newState));
    }

    protected abstract void SetQuestStepState(string state);
}
