using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este script hace que cuando el jugador interacciona con un objeto con el tag DialogueTrigger
// (Uno en la primer escena, un cubo grande que toca cuando cae, y en la segunda escena, en un objeto hijo del último objeto que tiene que agarrar)
// empieza el diálogo que se escribió en el inspector, bajo este script

// Este script está puesto en el personaje

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "DialogueTrigger")
        {
            TriggerDialogue();
            Destroy(other.gameObject);
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
