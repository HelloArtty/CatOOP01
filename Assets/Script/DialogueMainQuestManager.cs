using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueMainQuestManager : DialogueQuestManager
{
    private int questNo = 2;
    private int questCount;

    protected override void ChangeDialogue(Quest quest)
    {
        questCount = QuestCount.instance.GetQuestCount();
        if(quest.state == QuestState.CAN_START){
            base.npcDialogueSentences = npcDialogueSentencesCanStart;
        }
        else if(questCount < questNo){
            string[] remainingQuest = new string[] {$"{questNo - questCount} more items need to be delivered."};
            base.npcDialogueSentences = remainingQuest;
        }
        else if(questCount == questNo){
            base.npcDialogueSentences = npcDialogueSentencesFinished;
        }
    }
}
