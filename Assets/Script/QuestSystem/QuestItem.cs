using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    private bool playerIsNear = false;
    [SerializeField] private QuestInfoSO info;
    private string questID;
    private void Awake()
    {
        questID = info.id;
    }

    private void OnEnable()
    {
        GameEventManager.instance.submitPressEvent.onSubmitPress += CollectItem;
    }

    private void OnDisable()
    {
        GameEventManager.instance.submitPressEvent.onSubmitPress -= CollectItem;
    }
    private void CollectItem()
    {
        if(!playerIsNear)
        {
            return;
        }
        GameEventManager.instance.questItemEvents.ItemCollected(questID);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerIsNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerIsNear = false;
        }
    }
}
