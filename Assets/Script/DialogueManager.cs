using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.05f;
    [SerializeField] private float dialogueCloseSec = 4.0f;

    [SerializeField] private GameObject dialogueBubble;
    [SerializeField] private TextMeshProUGUI npcDialogueText;
    
    [TextArea]
    [SerializeField] private string[] npcDialogueSentences;

    [SerializeField] private int npcIndex = 0;
    [SerializeField] private int dialogueLength;
    private InteractableNPC interactableNPC;

    [HideInInspector] public bool isDialogueFinished;
    [HideInInspector] public bool isDialogueEnded;

    private void Start(){
        interactableNPC = GetComponent<InteractableNPC>();
        StartDialogue();
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

    private void EndDialogue(){
        npcIndex = 0;
        interactableNPC.dialogueStatus = false;
        isDialogueEnded = true;
        dialogueBubble.SetActive(false);
    }
}
