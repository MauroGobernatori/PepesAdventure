using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cajaMovible : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!player.GetComponent<Player>().grabbingInput) return;
        if(collision.gameObject.name != "Piso")
        {
            player.GetComponent<Player>().released();
        }
    }
}
