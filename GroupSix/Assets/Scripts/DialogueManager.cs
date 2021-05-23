using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    private Queue <string> sentences; //A queue is like a list but has a more restricted workability // FIFO
    [SerializeField] Text nameText;
    [SerializeField] private Text dialogueText;
    [SerializeField] Animator animator;







    void Start()
    {

        sentences = new Queue<string>();
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        Debug.Log("Starting conversation with " + dialogue.name);


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

        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        StopAllCoroutines(); // making sure that if a TypeSentence Coroutine is already running, it will stop so that we can start a new one. 

        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {

        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return 2; // wait for a single frame
        }

    }


    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);

    }


}
