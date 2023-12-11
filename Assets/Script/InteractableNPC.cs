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
                    StartCoroutine(DelayDialogue());
                }
                else
                {
                    dialogueManager.ContinueDialogue();
                }
            }
        }
    }

    // delay for some event that might come up before dialogue 
    //(deliver item window will pause the time and enable before dialogue start)
    private IEnumerator DelayDialogue(){
        yield return new WaitForSeconds(0.01f);
        base.InactiveSymbol();
        dialogueBubble.SetActive(true);
        dialogueManager.StartDialogue();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if (collision.CompareTag("Player"))
            {
                if(dialogueStatus == false)
                {
                    base.ActiveSymbol();
                }
                else
                {
                    base.InactiveSymbol();
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
                    base.ActiveSymbol();
                }
                else if(dialogueManager.isDialogueEnded == false){
                    base.InactiveSymbol();
                }
            }
        }
    }

    protected override void OnTriggerExit2D(Collider2D collision){
        if(collision != null)
        {
            if (collision.CompareTag("Player"))
            {
                base.OnTriggerExit2D(collision);
                playerInCollider = false;
            }
        }
    }
}
