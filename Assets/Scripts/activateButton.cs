using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateButton : MonoBehaviour
{

    private bool abrirPuerta = false;
    private bool cerrarPuerta = false;

    [SerializeField] private GameObject door = null;

    private Material material;

    private void Start()
    {
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
