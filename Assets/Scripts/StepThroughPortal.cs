using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    Este script permite al jugador y a los lasers pasar a traves del portal.

    Este script está puesto en los dos portales ("RigthPortal" "LeftPortal")
*/


public class StepThroughPortal : MonoBehaviour
{

    public GameObject otherPortal;

    // Para instanciar el laser
    public GameObject sphere;

    private bool invocado = false;
    private string portalName = null;

    private Component[] array;

    void OnTriggerEnter(Collider other) {
        //Debug.Log("Something hit the portal");
        if(other.tag == "Player" || other.tag == "CubitoRigidBody") {
            other.transform.position = otherPortal.transform.position + otherPortal.transform.forward * 2f;
        }

        if (other.gameObject.tag == "Laser")
        {
            invocarLaser();
            portalName = gameObject.name;
            //Debug.Log(portalName);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Laser")
        {
            array = sphere.GetComponentsInChildren<CapsuleCollider>();
            foreach (CapsuleCollider capsuleCollider in array)
            {
                capsuleCollider.height = 0;
            }
            Invoke("desinvocarLaser", 1);
        }
    }

    void invocarLaser()
    {
        if (invocado) return;
        if (!sphere.activeInHierarchy)
        {
            sphere.SetActive(true);
            array = sphere.GetComponentsInChildren<CapsuleCollider>();
            foreach (CapsuleCollider capsuleCollider in array)
            {
                capsuleCollider.height = 35;
            }
            sphere.transform.position = otherPortal.transform.position + Vector3.right / 2;
            sphere.transform.rotation = otherPortal.transform.rotation;
            invocado = true;
            return;
        }
        sphere = Instantiate(sphere, otherPortal.transform.position + Vector3.right/2, otherPortal.transform.rotation);
        invocado = true;
    }

    void desinvocarLaser()
    {sphere.SetActive(false);
        invocado = false;
    }
}
