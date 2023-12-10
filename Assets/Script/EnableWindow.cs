using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableWindow : MonoBehaviour
{
    private Button open;
    [SerializeField] private GameObject window;

    void Start(){
        open = GetComponent<Button>();
        open.onClick.AddListener(OpenWindow);
    }

    void OpenWindow(){
        if(window.activeSelf == false){
            window.SetActive(true);
        }
        else{
            Debug.Log("No window to open.");
        }
    }
}
