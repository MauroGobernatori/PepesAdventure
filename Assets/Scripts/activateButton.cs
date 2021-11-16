using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este script abre y cierra la puerta de la habitación 3, dependiendo de si está o nó activado, con una caja arriba

// Este script está puesto en el botón de la habitación 2

public class activateButton : MonoBehaviour
{

    private bool abrirPuerta = false;
    private bool cerrarPuerta = false;

    [SerializeField] private GameObject door = null;

    private Material material;

    private void Start()
    {
        // Agarro el material para cambiarle el color a verde si esta activado, y rojo si no
        material = GetComponent<Renderer>().material;
    }

    private void FixedUpdate()
    {
        if (abrirPuerta)
        {
            if (door.transform.localPosition.x >= -182)
            {
                abrirPuerta = false;
                return;
            }
            door.transform.position += new Vector3(1.1f, 0, 0) * Time.deltaTime;
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
            material.color = Color.green;
            abrirPuerta = true;
            cerrarPuerta = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<cajaMovible>().isActiveAndEnabled)
        {
            material.color = Color.red;
            cerrarPuerta = true;
            abrirPuerta = false;
        }
    }
}
