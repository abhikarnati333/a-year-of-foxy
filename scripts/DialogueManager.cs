﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
       
    //DailogueText
    public void StartDialogue(Dialogue dialogue)

    {
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }


        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
       
    }

    //AnimatedText
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
           
    }

    //EndOfDailogue
    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }

}




