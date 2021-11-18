using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este script hace que el jugador se convierta en hijo de las plataformas al tocarlas, para que el jugador siga el movimiento de las plataformas

// Este script está puesto en las tres plataformas del primer nivel

public class evitarCaidaPlataforma : MonoBehaviour
{
    public GameObject Player;

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject == Player)
        {
            Player.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = null;
        }
    }

}
