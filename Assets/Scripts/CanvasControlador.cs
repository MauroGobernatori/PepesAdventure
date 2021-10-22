using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        respawn = GameObject.Find("SpawnPoint");
        crosshair = GameObject.Find("CrossHair");
        canvasVida = GameObject.Find("Vida");
    }
    public void respawnPlayer()
    {
        player.transform.position = respawn.transform.position;
        player.GetComponent<FirstPersonMovement>().enabled = true;
        player.GetComponent<Jump>().enabled = true;
        player.GetComponent<Crouch>().enabled = true;
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

    public void MenuRedirect()
    {
        SceneManager.LoadScene("Menub");
    }

}
