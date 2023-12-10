using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableWindow : MonoBehaviour
{
    private Button close;
    [SerializeField] private GameObject window;

    void Start(){
        close = GetComponent<Button>();
        close.onClick.AddListener(CloseWindow);
    }

    void CloseWindow(){
        if(window.activeSelf == true){
            window.SetActive(false);
        }
        else{
            Debug.Log("No window to close.");
        }
    }
}
