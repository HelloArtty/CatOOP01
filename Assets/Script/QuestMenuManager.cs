using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestMenuManager : MonoBehaviour
{
    [Header("Quest Mochi")]
    [SerializeField] private QuestInfoSO infoQuest1;
    [SerializeField] private GameObject questStatus1;

    [Header("Quest Deer")]
    [SerializeField] private QuestInfoSO infoQuest2;
    [SerializeField] private GameObject questStatus2;

    // [Header("Quest Budha")]
    // [SerializeField] private QuestInfoSO infoQuest3;
    // [SerializeField] private GameObject textQuest3;

    Dictionary<QuestInfoSO, TextMeshProUGUI> dict;

    private void Awake()
    {
        dict = new Dictionary<QuestInfoSO, TextMeshProUGUI>()
            {
                {infoQuest1, questStatus1.GetComponent<TextMeshProUGUI>()},
                {infoQuest2, questStatus2.GetComponent<TextMeshProUGUI>()}
            };
    }

    private void OnEnable()
    {
        GameEventManager.instance.questEvents.onQuestStateChange += ChangeText;
    }

    private void OnDisable()
    {
        GameEventManager.instance.questEvents.onQuestStateChange -= ChangeText;
    }

    private void ChangeText(Quest quest)
    {
        foreach(QuestInfoSO info in dict.Keys)
        {
            if(quest.info.id.Equals(info.id))
            {
                switch(quest.state)
                {
                    case QuestState.CAN_START:
                        dict[info].text = "[Unavailable]";
                        break;
                    case QuestState.IN_PROGRESS:
                        dict[info].text = "[Ongoing]";
                        break;
                    case QuestState.CAN_FINISH:
                        dict[info].text = "[Deliver Pending]";
                        break;
                    case QuestState.FINISHED:
                        dict[info].text = "[Completed]";
                        break;
                }
            } 
        }
    }
}
