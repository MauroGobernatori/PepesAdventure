using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoTorreta : MonoBehaviour
{

/**/

    public Transform target;
    public Transform torreta;
    public Transform bala;
    public Transform balaSpawn;
    public float ultimoDisparo;
    public float frecuenciaDisparo = 2.0f;

    public float tiempoDisparo = 0;
    



    void Start() {
        ultimoDisparo = Time.time;
        
        
    }

    void Update()
    {
        tiempoDisparo = Time.time;
        Debug.Log(tiempoDisparo);
        if (tiempoDisparo % 8 == 0) 
        {
            StartCoroutine("RecargandoTorreta");
            
        }
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

    IEnumerator RecargandoTorreta()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Torreta Recargando");
    }


}
