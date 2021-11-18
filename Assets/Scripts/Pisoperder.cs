using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pisoperder : MonoBehaviour
{
    public GameObject Respawn;

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            //other.transform.position = Respawn.transform.position;
        }
    }

}
