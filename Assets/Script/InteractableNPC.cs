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
    public bool dialogueStatus;

    void Start(){
        dialogueManager = GetComponent<DialogueManager>();
        dialogueStatus = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (playerInCollider == true)
            {
                if (dialogueStatus == false)
                {
                    buttonPrefab.SetActive(false);
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
                    buttonPrefab.SetActive(true);
                }
                else
                {
                    buttonPrefab.SetActive(false);
                }
                playerInCollider = true;
            }
        }
        
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        if(collision != null)
        {
            if (collision.CompareTag("Player"))
            {
                buttonPrefab.SetActive(false);
                playerInCollider = false;
            }
        }
    }
}
