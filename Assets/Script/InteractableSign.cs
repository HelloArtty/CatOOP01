using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableSign : InteractableObject
{
    [SerializeField]
    private GameObject signWindowUI;
    private bool playerInCollider;

    void Update(){
        if (Input.GetKeyDown(KeyCode.E) && playerInCollider == true){
            if (!signWindowUI.activeSelf)
            {
                OpenWindow();
            }
            else if(signWindowUI.activeSelf)
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
                base.OnTriggerEnter2D(collision); // call this method in base class
                playerInCollider = true;
            }
        }
    }

    protected override void OnTriggerStay2D(Collider2D collision){
        if(collision != null)
        {
            if (collision.CompareTag("Player"))
            {
                base.OnTriggerStay2D(collision); // call this method in base class
            }
        }
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        if(collision != null)
        {
            if (collision.CompareTag("Player"))
            {
                base.OnTriggerExit2D(collision); // call this method in base class
                playerInCollider = false;
            }
        }
    }

    void OpenWindow(){
        signWindowUI.SetActive(true);
        Time.timeScale = 0f;
    }

    void ExitWindow(){
        signWindowUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
