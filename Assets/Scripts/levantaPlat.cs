using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este script es para que al tocar panel de la pared con el laser, levante las plataformas para que formen un "puente"
// Si el laser deja de tocar el panel de la pared, se baja el puente

// Este script está puesto en la panel de la pared
public class levantaPlat : MonoBehaviour
{

    // Dos bool para decirle a las plataformas si subir o bajar
    private bool subirPlats = false;
    private bool bajarPlats = false;
    // Tomar las plataformas que tienen que subir/bajar
    [SerializeField] private GameObject platform1;
    [SerializeField] private GameObject platform2;
    [SerializeField] private GameObject platform3;

    // Capaz algun cambio de esto sea de ponerle un array, para que a cada panel se le puedan poner cantidades diferentes de plataformas

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Laser")
        {
            if (subirPlats) return;
            if (bajarPlats) return;
            subirPlats = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        subirPlats = false;
        bajarPlats = true;
    }

    private void FixedUpdate()
    {
        if (subirPlats)
        {
            if (platform1.transform.position.y >= 11.5 && platform2.transform.position.y >= 11.5 && platform3.transform.position.y >= 11.5) return;
            platform1.transform.position += new Vector3(0, 3.1f, 0) * Time.deltaTime * 2;
            platform2.transform.position += new Vector3(0, 3.1f, 0) * Time.deltaTime * 2;
            platform3.transform.position += new Vector3(0, 3.1f, 0) * Time.deltaTime * 2;
        }

        if (bajarPlats)
        {
            if (platform1.transform.position.y <=0 && platform2.transform.position.y <= 0 && platform3.transform.position.y <=0)
            {
                bajarPlats = false;
                return;
            }
            platform1.transform.position -= new Vector3(0, 3.1f, 0) * Time.deltaTime * 2;
            platform2.transform.position -= new Vector3(0, 3.1f, 0) * Time.deltaTime * 2;
            platform3.transform.position -= new Vector3(0, 3.1f, 0) * Time.deltaTime * 2;
        }
    }
}
