using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestCount : MonoBehaviour
{
    public static QuestCount instance { get; private set; }
    private int questCount;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        questCount = PlayerPrefs.GetInt("QuestCount", 0);
    }
    private void OnEnable(){
        GameEventManager.instance.questEvents.onFinishQuest += IncrementQuestCount;
    }

    private void OnDisable(){
        GameEventManager.instance.questEvents.onFinishQuest -= IncrementQuestCount;
    }

    private void IncrementQuestCount(String id){
        questCount++;
        SaveQuestCount();
    }

    private void SaveQuestCount(){
        PlayerPrefs.SetInt("QuestCount", questCount);
        PlayerPrefs.Save();
    }

    public int GetQuestCount(){
        return questCount;
    }

    public void SetQuestCount(int q){
        questCount = q;
    }
}
