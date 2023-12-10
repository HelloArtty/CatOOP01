using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Button resume;
    [SerializeField] private GameObject menuScreen;

    void Start(){
        button.onClick.AddListener(OpenPauseMenu);
        resume.onClick.AddListener(ClickedResume);
    }
    
    void OpenPauseMenu(){
        SetMenuStatus();
    }

    void ClickedResume(){
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
