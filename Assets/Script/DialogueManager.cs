using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.05f;
    [SerializeField] private float dialogueCloseSec = 3.0f;

    [SerializeField] protected GameObject dialogueBubble;
    [SerializeField] protected TextMeshProUGUI npcDialogueText;
    
    [TextArea]
    [SerializeField] protected string[] npcDialogueSentences;

    [SerializeField] protected int npcIndex = 0;
    [SerializeField] protected int dialogueLength;
    protected InteractableNPC interactableNPC;

    [HideInInspector] public bool isDialogueFinished;
    [HideInInspector] public bool isDialogueEnded;

    private void Start(){
        interactableNPC = GetComponent<InteractableNPC>();
        dialogueLength = npcDialogueSentences.Length;
        isDialogueFinished = true;
        isDialogueEnded = true;
    }

    private IEnumerator TypeNPCDialogue()
    {
        isDialogueFinished = false;
        npcDialogueText.text = "";
        foreach(char letter in npcDialogueSentences[npcIndex].ToCharArray())
        {
            npcDialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isDialogueFinished = true;
    }

    private IEnumerator CloseDialogue(){
        yield return new WaitForSeconds(dialogueCloseSec);
        EndDialogue();
    }

    public void StartDialogue(){
        dialogueLength = npcDialogueSentences.Length;
        interactableNPC.dialogueStatus = true;
        isDialogueEnded = false;
        if(npcIndex < dialogueLength)
        {
            StartCoroutine(TypeNPCDialogue());
            npcIndex += 1;
            if(npcIndex == dialogueLength)
            {
                StartCoroutine(CloseDialogue());
            }
        }
        else
        {
            EndDialogue();
        }
    }

    public void ContinueDialogue(){
        if(npcIndex < dialogueLength)
        {
            StartCoroutine(TypeNPCDialogue());
            npcIndex += 1;
            if(npcIndex == dialogueLength)
            {
                StartCoroutine(CloseDialogue());
            }
        }   
        else
        {
            EndDialogue();
        }
    }

    protected virtual void EndDialogue(){
        npcIndex = 0;
        interactableNPC.dialogueStatus = false;
        isDialogueEnded = true;
        dialogueBubble.SetActive(false);
    }
}
