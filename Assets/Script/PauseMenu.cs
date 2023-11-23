using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private GameObject menuScreen;
    void Start(){
        button.onClick.AddListener(TaskOnClick);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            SetMenuStatus();
        }
    }

    void TaskOnClick(){
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
