using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este script le avisa al script ComportamientoPersonaje.cs si el jugador está en el aire o en el piso

// Este script está puesto en los pies del personajes ("Pies")

public class LogicaPies : MonoBehaviour
{
    public ComportamientoPersonaje comportamientoPersonaje;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Suelo" || other.tag == "Lava")
        {
            comportamientoPersonaje.puedoSaltar = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Suelo" || other.tag == "Lava")
        {
            comportamientoPersonaje.puedoSaltar = false;
        }
    }

}
