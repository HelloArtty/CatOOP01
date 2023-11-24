using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Button resume;
    [SerializeField] private GameObject menuScreen;
    private Canvas[] allCanvases; // Get all Canvas components in the scene
    private int canvasIndexCheck = 1;
    void Start(){
        allCanvases = FindObjectsOfType<Canvas>();
        button.onClick.AddListener(OpenPauseMenu);
        resume.onClick.AddListener(OpenPauseMenu);
    }

    // void Update(){
    //     if(Input.GetKeyDown(KeyCode.Escape)){
    //         checkOpenCanvas();
    //     }
    // }

    void OpenPauseMenu(){
        SetMenuStatus();
    }

    void ClickedResume(){
        SetMenuStatus();
    }

    void checkOpenCanvas(){ 
        foreach (Canvas canvas in allCanvases)
        {
            if (canvas != null && canvas.isActiveAndEnabled && canvas.sortingOrder != 0) // not working
            {
                Debug.Log(canvas.transform.parent.name);
                return;
            }
        }
        SetMenuStatus();
    }

    void SetMenuStatus(){
        if(menuScreen.activeSelf == false){
            menuScreen.SetActive(true);
            button.gameObject.SetActive(false);
            Time.timeScale = 0f;
        }
        else if(menuScreen.activeSelf == true){
            menuScreen.SetActive(false);
            button.gameObject.SetActive(true);
            Time.timeScale = 1f;
        }
    }
}
