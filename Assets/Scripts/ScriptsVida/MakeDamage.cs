using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
