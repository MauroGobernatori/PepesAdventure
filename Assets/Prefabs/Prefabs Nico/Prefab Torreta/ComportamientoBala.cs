using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
Este script se encarga de destruir la bala una vez que esta impacta con el objetivo o se va del mapa.

Este script está puesto en cada torreta
*/

public class ComportamientoBala : MonoBehaviour
{

    public float velocidad = 20.0f;
    public int cantidad = 5;

    void Update()
    {
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("La bala choco con el player");
            Destroy(gameObject);
            other.gameObject.GetComponent<Player>().RestarVidaTorreta(cantidad);
        }
        if(other.gameObject.tag == "Suelo" || other.gameObject.tag == "Pared")
        {
            Debug.Log("La bala choco con una pared");
            Destroy(gameObject);
        }
    }
}
