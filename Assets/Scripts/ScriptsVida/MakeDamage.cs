using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Este script se encarga de ejecutar la funcion de restarVida que se encuentra en el archivo healt_and_damge, lo que hace es sacarle cierta cantidad a la variable
    vida que se encuentra en el personaje.
*/

public class MakeDamage : MonoBehaviour
{
    public float cantidad = 10;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            other.GetComponent<Player>().RestarVida(cantidad);
        }
    }
     private void OnTriggerStay(Collider other) {
        if (other.tag == "Player") {
            other.GetComponent<Player>().RestarVida(cantidad);
        }
    }
}
