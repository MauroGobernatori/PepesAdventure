using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
Este script se encarga de destruir la bala una vez que esta impacta con el objetivo o se va del mapa.
*/

public class ComportamientoBala : MonoBehaviour
{

    public float velocidad = 20.0f;
    public int cantidad = 10;


    private int[] limitesMapa = new int[2] { 500, -500 };


    void Update()
    {
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);


        // if (gameObject.transform.position.x >= limitesMapa[0] || gameObject.transform.position.x <= limitesMapa[1] || gameObject.transform.position.y >= limitesMapa[0]
        // || gameObject.transform.position.y <= limitesMapa[1] || gameObject.transform.position.z >= limitesMapa[0] || gameObject.transform.position.z <= limitesMapa[1])
        // {
        //     Debug.Log("La bala salió del mapa");
        //     Destroy(gameObject);
        // }
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
