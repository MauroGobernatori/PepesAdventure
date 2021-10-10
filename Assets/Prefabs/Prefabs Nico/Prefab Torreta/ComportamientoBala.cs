using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoBala : MonoBehaviour
{

    public float velocidad = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other){
        if (other.gameObject.tag == "Player"){
            Debug.Log("La bala choco con el player");
            Destroy(gameObject, 0.5f);
        }
    }


}
