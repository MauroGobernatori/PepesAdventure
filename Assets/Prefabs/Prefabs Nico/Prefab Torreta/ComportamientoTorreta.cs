using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoTorreta : MonoBehaviour
{

/*
Este script se encarga de manipular el comportamiento de la torreta, asignandole un objetivo, balas, spawns de balas y demas. Cada vez que el usuario entra dentro del rango
de disparo de la torreta ésta instancia el prefab de la bala y con el lookAt dirige la bala al objetivo.
*/

    public Transform target;
    public Transform torreta;
    public Transform bala;
    public Transform balaSpawn;
    public float ultimoDisparo;
    public float frecuenciaDisparo = 2.0f;

    // public float tiempoDisparo = 0;
    



    void Start() {
        ultimoDisparo = Time.time;
        
        
    }

    // void Update()
    // {
    //     tiempoDisparo = Time.time;
    //     Debug.Log(tiempoDisparo);
    //     if (tiempoDisparo % 8 == 0) 
    //     {
    //         StartCoroutine("RecargandoTorreta");
            
    //     }
    // }

    void OnTriggerStay(Collider other){
        
        if (other.transform == target){
            torreta.transform.LookAt(target);

            if(ultimoDisparo < Time.time){
                Instantiate(bala, balaSpawn.position, balaSpawn.rotation);
                ultimoDisparo = Time.time + frecuenciaDisparo;
            }
        }
    }

    // IEnumerator RecargandoTorreta()
    // {
    //     yield return new WaitForSeconds(3);
    //     Debug.Log("Torreta Recargando");
    // }


}
