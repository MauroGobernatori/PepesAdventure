using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateButton : MonoBehaviour
{

    public GameObject Player;

    private Animator button;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
           button.Play("buttonDown");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            button.Play("buttonUp");
        }
    }
}
