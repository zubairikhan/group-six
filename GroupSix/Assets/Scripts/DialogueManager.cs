using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{

    [SerializeField] Text dialogueText;
    [SerializeField] Animator animator;

    private Queue<string> sentences; 

    void Start()
    {

        sentences = new Queue<string>();
            
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting Conversation");

        animator.SetBool("IsOpen", true);


        sentences.Clear();


        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();


    }



    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }
    
    private void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        Debug.Log("Conversation End");
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }


}
