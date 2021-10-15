using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour
{

    public Transform personaje;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }

        transform.position = new Vector3(personaje.position.x, personaje.position.y, personaje.position.z);

        transform.rotation = personaje.rotation;
    }
}
