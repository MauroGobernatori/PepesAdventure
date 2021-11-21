using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    Este script es para que al tocar panel de la pared con el laser, levante la escalera, si el laser deja de tocar el panel de la pared, se baja la escalera

    Este script esta puesto en el panel de la habitación 4 ("Panel")
*/

public class MoverEscalera : MonoBehaviour
{

    private bool subirEscalera = false;

    private bool bajarEscalera = false;

    public GameObject escalera = null; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Laser")
        {
            if (subirEscalera) return;
            if (bajarEscalera) return;
            
            if(!(escalera.transform.position.y <= 54.53))
            {
                Debug.Log("Enter");
                bajarEscalera = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        subirEscalera = true;
        bajarEscalera = false;
    }

    private void FixedUpdate()
    {
        Debug.Log(bajarEscalera);
        if (subirEscalera)
        {
            if (escalera.transform.localPosition.y >= 5.72)
            {
                subirEscalera = false;
                return;
            }
            escalera.transform.position += new Vector3(0, 1.5f, 0) * Time.deltaTime * 2;
        }
        if (bajarEscalera)
        {
            
            if (escalera.transform.position.y <= 54.53)
            {
                bajarEscalera = false;
                return;
            }
            escalera.transform.position -= new Vector3(0, 2f, 0) * Time.deltaTime * 2;
        }
    }



}
