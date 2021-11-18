using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Este script se encarga de mostrar el arma del jugador en su pantalla una vez que la agarra del suelo y la hace desaparecer del plano.
*/

public class LevantarArma : MonoBehaviour
{

    public GameObject armaEnSuelo;
    public GameObject armaJugador;

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "ArmaPortal"){
            armaEnSuelo.SetActive(false);
            armaJugador.SetActive(true);
        }
    }


}
