using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Este script carga la primera escena o sale del juego, depende qué botón se toque

// Este script esta puesto en un objeto vacío ("MenuManejador") en la escena del menu

public class MenuManejador : MonoBehaviour
{

    public void loadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("Salir del juego");
    }

}
