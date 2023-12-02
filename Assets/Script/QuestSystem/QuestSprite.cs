using System.Collections;
using System.Collections.Generic;
using System.Resources;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UIElements;

public class QuestSprite : MonoBehaviour
{
    [SerializeField] QuestInfoSO info;
    [SerializeField] private GameObject icon;
    private UnityEngine.UI.Image sourceSprite;
    [SerializeField] private Sprite notFound;
    [SerializeField] private Sprite found;
    [SerializeField] private Sprite delivered;

    void Awake()
    {
        sourceSprite = icon.GetComponent<UnityEngine.UI.Image>();
        sourceSprite.sprite = notFound;
    }

    private void OnEnable()
    {
        GameEventManager.instance.questEvents.onQuestStateChange += CheckState;
    }

    private void OnDisable()
    {
        GameEventManager.instance.questEvents.onQuestStateChange -= CheckState;
    }

    private void CheckState(Quest quest)
    {
        if(info.id != quest.info.id)
        {
            return;
        }

        switch(quest.state)
        {
            case QuestState.REQUIREMENTS_NOT_MET:
                break;
            case QuestState.CAN_START:
                break;
            case QuestState.CAN_FINISH:
                sourceSprite.sprite = found;
                break;
            case QuestState.FINISHED:
                sourceSprite.sprite = delivered;
                break;
            default:
                break;
        }
    }

}
