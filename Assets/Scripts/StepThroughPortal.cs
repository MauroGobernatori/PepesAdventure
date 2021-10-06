using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepThroughPortal : MonoBehaviour
{

    public GameObject otherPortal;

    // Para instanciar el laser
    public GameObject sphere;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    void OnTriggerEnter(Collider other) {
        //Debug.Log("Something hit the portal");
        if(other.tag == "Player" || other.tag == "CubitoRigidBody") {
            other.transform.position = otherPortal.transform.position + otherPortal.transform.forward * 2f;
        }
        Debug.Log("Toca");

        if (other.gameObject.tag == "Laser")
        {
            Debug.Log("Toca laser");
            sphere = Instantiate(sphere, otherPortal.transform.position, otherPortal.transform.rotation);
        }
    }
}
