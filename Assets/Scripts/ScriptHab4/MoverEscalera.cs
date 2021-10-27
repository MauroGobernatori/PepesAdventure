﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    Este script es para que al tocar panel de la pared con el laser, levante la escalera, si el laser deja de tocar el panel de la pared, se baja el puente
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
            subirEscalera = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        subirEscalera = false;
        bajarEscalera = true;
    }

    private void FixedUpdate()
    {

        Debug.Log(escalera.transform.position.y);

        if (subirEscalera)
        {
            if (escalera.transform.position.y >= 63.55) return;
            escalera.transform.position += new Vector3(0, 3.1f, 0) * Time.deltaTime * 2;
        }

        if (bajarEscalera)
        {
            if (escalera.transform.position.y <= 54.53)
            {
                bajarEscalera = false;
                return;
            }
            escalera.transform.position -= new Vector3(0, 3.1f, 0) * Time.deltaTime * 2;
        }
    }



}