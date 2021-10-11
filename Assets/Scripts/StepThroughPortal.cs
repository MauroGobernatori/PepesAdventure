using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepThroughPortal : MonoBehaviour
{

    public GameObject otherPortal;

    // Para instanciar el laser
    public GameObject sphere;

    private bool invocado = false;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if (invocado)
        {
            if (sphere.activeInHierarchy)
            {

            }
        }
    }

    void OnTriggerEnter(Collider other) {
        //Debug.Log("Something hit the portal");
        if(other.tag == "Player" || other.tag == "CubitoRigidBody") {
            other.transform.position = otherPortal.transform.position + otherPortal.transform.forward * 2f;
        }

        if (other.gameObject.tag == "Laser")
        {
            invocarLaser();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Laser")
        {
            desinvocarLaser();
        }
    }

    void invocarLaser()
    {
        if (invocado) return;
        if (!sphere.activeInHierarchy) sphere.SetActive(true);
        sphere = Instantiate(sphere, otherPortal.transform.position + Vector3.right/2, otherPortal.transform.rotation);
        invocado = true;
    }

    void desinvocarLaser()
    {
        sphere.SetActive(false);
        invocado = false;
    }
}
