using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public static GameEventManager instance { get; private set; }
    public QuestEvents questEvents;
    public QuestItemEvent questItemEvents;
    public SubmitPressEvent submitPressEvent;
    public SceneEvent sceneEvent;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Game Events Manager in the scene.");
        }

        instance = this;
        questEvents = new QuestEvents();
        questItemEvents = new QuestItemEvent();
        submitPressEvent = new SubmitPressEvent();
        sceneEvent = new SceneEvent();
    }
}
