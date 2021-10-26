using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateButton : MonoBehaviour
{

    private bool bajarBoton = false;
    private bool subirBoton = false;
    private bool abrirPuerta = false;
    private bool cerrarPuerta = false;

    [SerializeField] private GameObject door = null;

    private GameObject objeto = null;

    private void FixedUpdate()
    {
        if (bajarBoton)
        {
            if(abrirPuerta)
            {
                return;
            }
            abrirPuerta = true;
            transform.position -= new Vector3(0, 1.1f, 0) * Time.deltaTime;
        }
        if (abrirPuerta)
        {
            Debug.Log("Hola");
            if (door.transform.localPosition.x >= -182)
            {
                abrirPuerta = false;
                return;
            }
            door.transform.position += new Vector3(1.1f, 0, 0) * Time.deltaTime;
        }
        if (subirBoton)
        {
            if (transform.localPosition.y >= -0.4201205)
            {
                subirBoton = false;
                return;
            }
            transform.position += new Vector3(0, 1.1f, 0) * Time.deltaTime;
        }
        if (cerrarPuerta)
        {
            if (door.transform.localPosition.x  <= - 191.643)
            {
                cerrarPuerta = false;
                return;
            }
            door.transform.position -= new Vector3(1.1f, 0, 0) * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<cajaMovible>().isActiveAndEnabled)
        {
            bajarBoton = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<cajaMovible>().isActiveAndEnabled)
        {
            bajarBoton = false;
            subirBoton = true;
            cerrarPuerta = true;
        }
    }
}
