using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System;
using UnityEngine;

// Este script crea los lasers verdes desde el punto "FirePoint", cada laser se destruye y se van instanciando nuevos
// para darle el efecto de movimiento

// Este script está puesto en la esfera, hija del objeto que crea que los lasers, el objeto se llama "Laser"
public class EGA_DemoLasers2 : MonoBehaviour
{
    public GameObject FirePoint;
    public float MaxLength;
    // Prefabs es un array, porque hay varios lasers diferentes que se le puede poner
    public GameObject[] Prefabs;

    // Con el valor de Prefab se elije el laser que se usa, no hay forma dentro del juego de cambiar el laser
    private int Prefab = 0;
    private GameObject Instance;

    void Update()
    {
        Destroy(Instance,0.02f);
        Instance = Instantiate(Prefabs[Prefab], FirePoint.transform.position, FirePoint.transform.rotation);
        // Le añadimos al laser tag y componentes para que al tocar al jugador, que le baje toda la vida
        Instance.gameObject.tag = "Laser";
        Instance.gameObject.AddComponent<CapsuleCollider>();
        Instance.gameObject.GetComponent<CapsuleCollider>().isTrigger = true;
        Instance.gameObject.GetComponent<CapsuleCollider>().radius = 0.15f;
        Instance.gameObject.GetComponent<CapsuleCollider>().height = 35f;
        Instance.gameObject.GetComponent<CapsuleCollider>().direction = 2;
        // Center a la mitad del height
        Instance.gameObject.GetComponent<CapsuleCollider>().center = new Vector3(0,0,17.5f);
        Instance.transform.parent = transform;
    }
}
