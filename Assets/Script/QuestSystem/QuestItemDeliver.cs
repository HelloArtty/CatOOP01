using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestItemDeliver : MonoBehaviour
{
    [SerializeField] private GameObject successfullyDeliverWindow;
    private float windowCloseSec = 1.5f;

    private void Awake()
    {
        successfullyDeliverWindow.SetActive(false);
    }

    public void DeliverItem()
    {
        StartCoroutine(ShowDeliverWindow(windowCloseSec));
    }

    private IEnumerator ShowDeliverWindow(float windowCloseSec){
        Time.timeScale = 0; // Pause the game
        successfullyDeliverWindow.SetActive(true);

        float timer = 0f;
        while (timer < windowCloseSec){
            timer += Time.unscaledDeltaTime; // Use unscaledDeltaTime for paused time
            yield return null;
        }

        Time.timeScale = 1; // Resume the game
        successfullyDeliverWindow.SetActive(false);
    }
}
