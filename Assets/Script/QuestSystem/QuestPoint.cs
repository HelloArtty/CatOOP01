using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Threading;
using System;

// require boxcollider2D on the gameobject that this script attact to
[RequireComponent(typeof(BoxCollider2D))]
public class QuestPoint : MonoBehaviour
{
    [Header("Quest")]
    [SerializeField] private QuestInfoSO questInfoForPoint;

    [Header("Config")]
    [SerializeField] private bool startPoint = true;
    [SerializeField] private bool finishPoint = true;
    private ManualResetEvent dialogueEndedEvent = new ManualResetEvent(false);
    // public event EventHandler StartQuestRequested;

    private bool playerIsNear = false;
    private string questID;
    private QuestState currentQuestState;
    private void Awake()
    {
        questID = questInfoForPoint.id;
    }

    private void OnEnable()
    {
        GameEventManager.instance.questEvents.onQuestStateChange += QuestStateChange;
        GameEventManager.instance.submitPressEvent.onSubmitPress += SubmitPressed;
    }

    private void OnDisable()
    {
        GameEventManager.instance.questEvents.onQuestStateChange -= QuestStateChange;
        GameEventManager.instance.submitPressEvent.onSubmitPress -= SubmitPressed;
    }

    private void SubmitPressed()
    {
        if(!playerIsNear)
        {
            return;
        }

        if (currentQuestState.Equals(QuestState.CAN_START) && startPoint)
        {
            StartCoroutine(StartQuestIfReady());
        }
        else if(currentQuestState.Equals(QuestState.CAN_FINISH) && finishPoint)
        {
            GameEventManager.instance.questEvents.FinishQuest(questID);
        }
    }

    public IEnumerator StartQuestIfReady()
    {
        yield return StartCoroutine(GetComponent<DialogueQuestManager>().CheckIfReadyToStart());

        // This line will execute only after CheckIfReadyToStart completes
        GameEventManager.instance.questEvents.StartQuest(questID);
    }

    private void QuestStateChange(Quest quest)
    {
        // only update the quest state if this point has the corresponding quest
        if(quest.info.id.Equals(questID) )
        {
            currentQuestState = quest.state;
        }
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
