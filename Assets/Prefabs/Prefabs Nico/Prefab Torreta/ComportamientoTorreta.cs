using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoTorreta : MonoBehaviour
{
    public Transform target;
    public Transform torreta;
    public Transform bala;
    public Transform balaSpawn;
    public float ultimoDisparo;
    public float frecuenciaDisparo = 2.0f;


    void Start() {
        ultimoDisparo = Time.time;
    }


    void OnTriggerStay(Collider other){
        
        if (other.transform == target){
            torreta.transform.LookAt(target);

            if(ultimoDisparo < Time.time){
                Instantiate(bala, balaSpawn.position, balaSpawn.rotation);
                ultimoDisparo = Time.time + frecuenciaDisparo;
            }
        }
    }
}
