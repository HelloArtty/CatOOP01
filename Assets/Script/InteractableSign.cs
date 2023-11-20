using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableSign : InteractableObject
{
    [SerializeField]
    private GameObject signWindowUI;
    private bool playerInCollider;
    private bool signActive;

    void Start(){
        signActive = false;
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.E) && playerInCollider == true){
            if (signActive == false)
            {
                OpenWindow();
            }
            else if(signActive == true)
            {
                ExitWindow();
            }
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if (collision.CompareTag("Player"))
            {
                interactSymbol.SetActive(true);
                playerInCollider = true;
            }
        }
    }

    protected override void OnTriggerStay2D(Collider2D collision){
        if(collision != null)
        {
            if (collision.CompareTag("Player"))
            {
                interactSymbol.SetActive(true);
            }
        }
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        if(collision != null)
        {
            if (collision.CompareTag("Player"))
            {
                interactSymbol.SetActive(false);
                playerInCollider = false;
            }
        }
    }

    void OpenWindow(){
        signWindowUI.SetActive(true);
        signActive = true;
        Time.timeScale = 0f;
    }

    void ExitWindow(){
        signWindowUI.SetActive(false);
        signActive = false;
        Time.timeScale = 1f;
    }
}
