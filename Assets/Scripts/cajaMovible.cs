using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este script permite al jugador agarrar al cubo, ademas lo respawnea si cae en lava

// Este script está puesto en las cajas que se pueden mover con "Z"

public class cajaMovible : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private GameObject spawn = null;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Este if es para que el jugador tenga que estar apuntando al cubo cuando toca "Z" para agarrarlo
        if (!player.GetComponent<Player>().grabbingInput) return;
        // Si toca alguna pared u otra cosa, se suelta
        if(collision.gameObject.name != "Piso")
        {
            player.GetComponent<Player>().released();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Lava")
        {
            transform.position = spawn.transform.position;
        }
    }
}
