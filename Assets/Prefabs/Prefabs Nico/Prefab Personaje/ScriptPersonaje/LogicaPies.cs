using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPies : MonoBehaviour
{
    public ComportamientoPersonaje comportamientoPersonaje;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Suelo")
        {
            comportamientoPersonaje.puedoSaltar = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Suelo")
        {
            comportamientoPersonaje.puedoSaltar = false;
        }
    }

}
