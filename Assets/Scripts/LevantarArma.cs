using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
