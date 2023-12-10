using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    private bool playerIsNear = false;
    [SerializeField] private QuestInfoSO info;
    [SerializeField] private GameObject acquireWindow;
    private int windowCloseSec = 2;
    private string questID;
    private bool canShowAcquire;

    private void Awake()
    {
        questID = info.id;
        acquireWindow.SetActive(false);
    }

    private void OnEnable()
    {
        GameEventManager.instance.submitPressEvent.onSubmitPress += CollectItem;
        GameEventManager.instance.questEvents.onQuestStateChange += CheckState;
    }

    private void OnDisable()
    {
        GameEventManager.instance.submitPressEvent.onSubmitPress -= CollectItem;
        GameEventManager.instance.questEvents.onQuestStateChange -= CheckState;
    }

    private void CheckState(Quest quest){
        // if state change not for this quest then do nothing
        if(quest.info.id != this.info.id){
            return;
        }

        // if this quest in progress then show set variable "canShowAcquire" to true
        if(quest.state == QuestState.IN_PROGRESS){
            canShowAcquire = true;
        }
    }

    private void CollectItem()
    {
        if(!playerIsNear)
        {
            return;
        }

        if(canShowAcquire == true){
            GameEventManager.instance.questItemEvents.ItemCollected(questID);
            StartCoroutine(ShowAquireWindow());

        }
    }

    private IEnumerator ShowAquireWindow(){
        acquireWindow.SetActive(true);
        yield return new WaitForSeconds(windowCloseSec);
        acquireWindow.SetActive(false);
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
