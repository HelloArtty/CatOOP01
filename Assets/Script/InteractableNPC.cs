using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class InteractableNPC : InteractableObject
{
    [SerializeField] private GameObject dialogueBubble;
    private DialogueManager dialogueManager;
    private bool playerInCollider;

    [HideInInspector]
    public bool dialogueStatus;
    

    void Start(){
        dialogueManager = GetComponent<DialogueManager>();
        dialogueStatus = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInCollider == true)
        {
            if (dialogueManager.isDialogueFinished == true)
            {
                if (dialogueStatus == false)
                {
                    interactSymbol.SetActive(false);
                    dialogueBubble.SetActive(true);
                    dialogueManager.StartDialogue();
                }
                else
                {
                    dialogueManager.ContinueDialogue();
                }
            }
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if (collision.CompareTag("Player"))
            {
                if(dialogueStatus == false)
                {
                    interactSymbol.SetActive(true);
                }
                else
                {
                    interactSymbol.SetActive(false);
                }
                playerInCollider = true;
            }
        }
    }

    protected override void OnTriggerStay2D(Collider2D collision){
        if(collision != null)
        {
            if (collision.CompareTag("Player"))
            {
                if(dialogueManager.isDialogueEnded == true){
                    interactSymbol.SetActive(true);
                }
                else if(dialogueManager.isDialogueEnded == false){
                    interactSymbol.SetActive(false);
                }
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
}
