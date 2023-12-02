using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindItemQuest : QuestStep
{
    [SerializeField] private QuestInfoSO info;
    private bool isCollected = false;
    private void OnEnable()
    {
        GameEventManager.instance.questItemEvents.OnItemCollected += ItemCollected;
    }

    private void OnDisable()
    {
        GameEventManager.instance.questItemEvents.OnItemCollected -= ItemCollected;
    }

    private void ItemCollected(string questID)
    {
        if(questID.Equals(info.id))
        {
            isCollected = true;
            UpdateState();
        }

        if(isCollected)
        {
            FinishQuestStep(questID);
        }
    }

    private void UpdateState()
    {
        string state = isCollected.ToString();
        ChangeState(state);
    }

    protected override void SetQuestStepState(string state)
    {
        this.isCollected = System.Boolean.Parse(state);
        UpdateState();
    }
}
