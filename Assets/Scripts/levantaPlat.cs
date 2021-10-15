using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este script es para que al tocar la pared con el laser, levante las plataformas para que formen un "puente"
public class levantaPlat : MonoBehaviour
{

    //Tomar los objetos para subir las plataformas
    private bool subirPlats = false;
    private bool bajarPlats = false;
    [SerializeField] private GameObject cylinder1;
    [SerializeField] private GameObject cylinder2;
    [SerializeField] private GameObject cylinder3;
    [SerializeField] private GameObject cube1;
    [SerializeField] private GameObject cube2;
    [SerializeField] private GameObject cube3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Laser")
        {
            if (subirPlats) return;
            subirPlats = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Saliendo");
        /*
        subirPlats = false;
        bajarPlats = true;
        cube1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        cube1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        cube1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
        cube1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
        cube2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        cube2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        cube2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
        cube2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
        cube3.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        cube3.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        cube3.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
        cube3.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
        */
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Quedando");
    }

    private void FixedUpdate()
    {
        if (cube1.transform.position.y >= 29.656f)
        {
            cube1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            cube1.transform.position = new Vector3(cube1.transform.position.x, 29.656f, cube1.transform.position.z);
        }
        if (cube2.transform.position.y >= 29.656f)
        {
            cube2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            cube2.transform.position = new Vector3(cube2.transform.position.x, 29.656f, cube2.transform.position.z);
        }
        if (cube3.transform.position.y >= 29.656f)
        {
            cube3.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            cube3.transform.position = new Vector3(cube3.transform.position.x, 29.656f, cube3.transform.position.z);
        }
        if (subirPlats)
        {
            if (cylinder1.transform.localScale.y >= 12.4 && cylinder2.transform.localScale.y >= 12.4 && cylinder3.transform.localScale.y >= 12.4) return;
            cylinder1.transform.localScale += new Vector3(0, 3.1f, 0) * Time.deltaTime * 2;
            cylinder2.transform.localScale += new Vector3(0, 3.1f, 0) * Time.deltaTime * 2;
            cylinder3.transform.localScale += new Vector3(0, 3.1f, 0) * Time.deltaTime * 2;
        }
        if (bajarPlats)
        {
            if (cylinder1.transform.localScale.y <= 1 && cylinder2.transform.localScale.y <= 1 && cylinder3.transform.localScale.y <= 1) return;
            cylinder1.transform.localScale -= new Vector3(0, 3.1f, 0) * Time.deltaTime * 2;
            cylinder2.transform.localScale -= new Vector3(0, 3.1f, 0) * Time.deltaTime * 2;
            cylinder3.transform.localScale -= new Vector3(0, 3.1f, 0) * Time.deltaTime * 2;
        }
    }
}
