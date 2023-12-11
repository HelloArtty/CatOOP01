using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class DialogueQuestManager : DialogueManager
{
    [SerializeField] private QuestInfoSO info;
    [TextArea]
    [SerializeField] protected string[] npcDialogueSentencesCanStart;
    [TextArea]
    [SerializeField] protected string[] npcDialogueSentencesInProgress; 
    [TextArea]
    [SerializeField] protected string[] npcDialogueSentencesCanFinish; 
    [TextArea]
    [SerializeField] protected string[] npcDialogueSentencesFinished; 

    private void Awake()
    {
        base.npcDialogueSentences = npcDialogueSentencesCanStart;
    }

    private void OnEnable()
    {
        GameEventManager.instance.questEvents.onQuestStateChange += ChangeDialogue;
    }

    private void OnDisable()
    {
        GameEventManager.instance.questEvents.onQuestStateChange -= ChangeDialogue;
    }

    protected virtual void ChangeDialogue(Quest quest)
    {
        if(quest.info.id.Equals(this.info.id))
        {
            switch(quest.state)
            {
                case QuestState.CAN_START:
                    base.npcDialogueSentences = npcDialogueSentencesCanStart;
                    break;
                case QuestState.IN_PROGRESS:
                    base.npcDialogueSentences = npcDialogueSentencesInProgress;
                    break;
                case QuestState.CAN_FINISH:
                    base.npcDialogueSentences = npcDialogueSentencesCanFinish;
                    break;
                case QuestState.FINISHED:
                    base.npcDialogueSentences = npcDialogueSentencesFinished;
                    break;
            }
        } 
    }

    public IEnumerator CheckIfReadyToStart()
    {
        while (true) // Infinite loop until the condition changes to false
        {
            while (!interactableNPC.dialogueStatus) // Wait for the condition to become true
            {
                yield return null; // Wait for the next frame
            }
            // Condition became true
            while (interactableNPC.dialogueStatus) // Wait for the condition to become false
            {
                yield return null; // Wait for the next frame
            }
            // Condition became false
            break; // Exit the loop when the condition becomes false
        }
    }
}
