using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Este script cambia la escena, de la primera a la segunda (para elegir a que escena se cambia, se pone el nombre en el inspector)

// Este script esta puesto en el level001, en una esfera en el medio del tubo del final

public class cambioLevel1A2 : MonoBehaviour
{

    [SerializeField] private string level = null;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SceneManager.LoadScene(level);
        }
    }
}
