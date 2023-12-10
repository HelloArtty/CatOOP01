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

    // private void SubmitPressed(){
    //     StartCoroutine(HideWindow());
    // }

    // void Update(){
    //     if(Input.GetKey(KeyCode.E) && successfullyDeliverWindow.activeSelf){
    //         successfullyDeliverWindow.SetActive(false);
    //     }
    // }

    public void DeliverItem()
    {
        StartCoroutine(ShowDeliverWindow(windowCloseSec));
        // successfullyDeliverWindow.SetActive(true);
        // ShowDeliverWindow();
        // StartCoroutine(ShowDeliverWindow());
    }

    // private IEnumerator ShowDeliverWindow(){
    //     successfullyDeliverWindow.SetActive(true);
    //     yield return new WaitForSeconds(3);
    //     successfullyDeliverWindow.SetActive(false);
    // }

    // private IEnumerator ShowDeliverWindow(){
    //     successfullyDeliverWindow.SetActive(true);
    //     float startTime = Time.realtimeSinceStartup;
        
    //     while (Time.realtimeSinceStartup < startTime + windowCloseSec)
    //     {
    //         yield return null;
    //     }

    //     successfullyDeliverWindow.SetActive(false);
    // }

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
    
    // private IEnumerator HideWindow(){
    //     yield return null;
    //     if(successfullyDeliverWindow.activeSelf){
    //         successfullyDeliverWindow.SetActive(false);
    //     }
    // }

    // private void ShowDeliverWindow(){
    //     successfullyDeliverWindow.SetActive(true);
    // }

    // private IEnumerator ShowDeliverWindow(){
    //     successfullyDeliverWindow.SetActive(true);
    //     yield return new WaitForSeconds(windowCloseSec);
    // }
}
