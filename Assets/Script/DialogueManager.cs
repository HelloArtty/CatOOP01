using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.05f;

    [SerializeField] private GameObject bubbleDialogue;
    [SerializeField] private TextMeshProUGUI npcDialogueText;
    
    [TextArea]
    [SerializeField] private string[] npcDialogueSentences;

    [SerializeField] private int npcIndex = 0;
    [SerializeField] private int dialogueLength;
    private InteractableNPC interactableNPC;
    public bool isDialogueFinished;

    private void Start(){
        interactableNPC = GetComponent<InteractableNPC>();
        StartDialogue();
        dialogueLength = npcDialogueSentences.Length;
        isDialogueFinished = true;
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

    public void StartDialogue(){
        interactableNPC.dialogueStatus = true;
        if(npcIndex < dialogueLength)
        {
            StartCoroutine(TypeNPCDialogue());
            npcIndex += 1;
        }
        else
        {
            npcIndex = 0;
            interactableNPC.dialogueStatus = false;
            bubbleDialogue.SetActive(false);
        }
    }

    public void ContinueDialogue(){
        if(npcIndex < dialogueLength)
        {
            StartCoroutine(TypeNPCDialogue());
            npcIndex += 1;
        }
        else
        {
            npcIndex = 0;
            interactableNPC.dialogueStatus = false;
            bubbleDialogue.SetActive(false);
        }
    }
}
