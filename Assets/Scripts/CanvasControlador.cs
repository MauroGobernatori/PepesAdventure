using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Este script controla el canvas, activa y desactiva la muerte cuando llega la vida a 0, activa y desactiva el crosshair
// también respawnea al jugador y cierra el juego si se elije salir cuando se meure

// Este script está puesto en un objeto vacío "CanvasControlador"

public class CanvasControlador : MonoBehaviour
{

    private GameObject player;
    private GameObject respawn;
    private GameObject canvasVida;

    private GameObject canvasMuerte;
    private GameObject crosshair;

    private void Awake()
    {
        canvasMuerte = GameObject.Find("MenuMuerte");
        player = GameObject.FindWithTag("Player");
        crosshair = GameObject.Find("CrossHair");
        canvasVida = GameObject.Find("Vida");
    }
    public void respawnPlayer()
    {
        respawn = GameObject.FindWithTag("Respawn");
        player.transform.position = respawn.transform.position;
        player.GetComponent<ComportamientoPersonaje>().enabled = true;
        if (canvasMuerte.activeInHierarchy)
        {
            canvasMuerte.SetActive(false);
        }
        if (!canvasVida.activeInHierarchy)
        {
            canvasVida.SetActive(true);
        }
        if (!crosshair.activeInHierarchy)
        {
            crosshair.SetActive(true);
        }
        Cursor.lockState = CursorLockMode.Locked;
        player.GetComponent<Player>().vida = 100;
    }

    public void quit()
    {
        Application.Quit();
    }

}
