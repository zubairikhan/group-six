using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    [SerializeField] Dialogue dialogue;
    [SerializeField] GameObject dialogueTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag == "Player")
        {
            TriggerDialogue();
            dialogueTrigger.SetActive(false);
        }
    }



    public void TriggerDialogue()
    {

        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

    }

}
