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
    private float windowCloseSec = 1.5f;
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
            // StartCoroutine(ShowAquireWindow());
            StartCoroutine(ShowAquireWindow(windowCloseSec));
            canShowAcquire = false;
        }
    }

    // private void ShowAquireWindow(){
    //     acquireWindow.SetActive(true);
    // }

    // private IEnumerator ShowAquireWindow(){
    //     acquireWindow.SetActive(true);
    //     yield return new WaitForSeconds(windowCloseSec);
    //     acquireWindow.SetActive(false);
    // }

    private IEnumerator ShowAquireWindow(float windowCloseSec){
        Time.timeScale = 0; // Pause the game
        acquireWindow.SetActive(true);

        float timer = 0f;
        while (timer < windowCloseSec){
            timer += Time.unscaledDeltaTime; // Use unscaledDeltaTime for paused time
            yield return null;
        }

        Time.timeScale = 1; // Resume the game
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
