using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    Este script se encarga de todo lo relacionado con las propiedades y funcionalidades del jugador.
*/

public class Player : MonoBehaviour
{
    [SerializeField] private UI_Inventory uiInventory = null;
    [SerializeField] private float grabbingDistance = 0f;

    private Collectable collectable;
    private Inventario inventory;
    private Transform UI_Inventory;

    // Canvas de inventario
    private bool showInventory = false;
    private GameObject canvasInventory;

    // Canvas de muerte
    private bool showMuerte = false;
    private GameObject canvasMuerte;
    private GameObject canvasVida;

    //Canvas Crosshair
    private GameObject crosshair;

    private GameObject camera;

    private bool grabInput = false;
    public bool grabbingInput = false;
    private bool ungrabInput = false;
    private GameObject grabbing;
    private GameObject puntoAgarre;

    // Probando pasar la vida
    public float vida = 100;

    private bool invencible = false;
    //private GameObject jugador;
    [SerializeField] private float tiempo_invencible = 1f;

    public GameObject sliderVida;

    [SerializeField] private GameObject[] spawns;
    private int spawnCounter = 0;

    private void Start()
    {
        canvasMuerte = GameObject.Find("MenuMuerte");
        canvasInventory = GameObject.Find("UI_Inventory");
        canvasVida = GameObject.Find("Vida");

        puntoAgarre = GameObject.Find("puntoAgarre");
        grabbing = GameObject.Find("Grabbing");
        crosshair = GameObject.Find("CrossHair");


        // Obtiene el inventario, vacío en la primer escena, con objetos las siguientes escenas
        inventory = GameObject.FindGameObjectWithTag("Inventario").GetComponent<Inventario>();
        uiInventory.setInventory(inventory);

        // Obtener la cámara para ver donde apunto
        camera = GameObject.FindWithTag("PlayerCamera");

        if (canvasInventory.activeInHierarchy)
        {
            // Si el inventario está activo en canvas, desactivarlo
            canvasInventory.SetActive(false);
        }
        if (canvasMuerte.activeInHierarchy)
        {
            // Si la muerte está activa en canvas, desactivarla
            canvasMuerte.SetActive(false);
        }
    }

    private void Update()
    {
        var sliderVidaValue = sliderVida.GetComponent<Slider>();

        sliderVidaValue.value = vida;

        if (Input.GetKeyDown(KeyCode.I))    //Muestra el inventario al apretar la tecla I.
        {
            showInventory = !showInventory;
            if (showInventory)
            {
                // Mostrar el inventario
                canvasInventory.SetActive(true);
            }
            else
            {
                // Esconder el inventario
                canvasInventory.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Z))    //Permite al jugador mover un objeto al apretar la Z 
        {
            if (!grabbingInput)
            {
                grabInput = true;
            }
            else
            {
                ungrabInput = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (grabInput)
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = camera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.GetComponent<cajaMovible>())
                {
                    if (hit.distance < grabbingDistance)
                    {
                        grabInput = false;
                        puntoAgarre.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y + 1, hit.transform.position.z);
                        grabbing = hit.transform.gameObject;
                        grabbed();
                        grabbingInput = true;
                    }
                    else
                    {
                        grabInput = false;
                    }
                }
                else
                {
                    grabInput = false;
                }
            }
        }

        if (ungrabInput)
        {
            released();
        }
    }

    private void OnCollisionEnter(Collision collision)  //Este script hace que al pasar por encima de un objeto collectable este lo almacene en el invetario y lo borre del plano.
    {
        if (collision.gameObject.tag == "Collectable")
        {
            collectable = collision.gameObject.GetComponent<Collectable>();
            Destroy(collision.gameObject);
            switch (collectable.itemType)
            {
                case Item.ItemType.book:
                    inventory.itemList.Add(new Item { itemType = Item.ItemType.book });
                    break;
                case Item.ItemType.bronce_ring:
                    inventory.itemList.Add(new Item { itemType = Item.ItemType.bronce_ring });
                    break;
                case Item.ItemType.clover:
                    inventory.itemList.Add(new Item { itemType = Item.ItemType.clover });
                    break;
                case Item.ItemType.feather:
                    inventory.itemList.Add(new Item { itemType = Item.ItemType.feather });
                    break;
                case Item.ItemType.scroll:
                    inventory.itemList.Add(new Item { itemType = Item.ItemType.scroll });
                    break;
                default:
                    break;
            }
            uiInventory.setInventory(inventory);
        }
        if(collision.gameObject.name == "Checkpoint1")  //Las siguientes lineas se encargan de marcar los checkpoints luego de qu eel jugador pase sobre estos.
        {
            if(spawnCounter < 1)
            {
                spawns[0].tag = "Untagged";
                spawns[1].tag = "Respawn";
                spawnCounter++;
            }
        }
        if (collision.gameObject.name == "Checkpoint2")
        {
            if (spawnCounter < 2)
            {
                spawns[1].tag = "Untagged";
                spawns[2].tag = "Respawn";
                spawnCounter++;
            }
        }
        if (collision.gameObject.name == "Checkpoint3")
        {
            if (spawnCounter < 3)
            {
                spawns[2].tag = "Untagged";
                spawns[3].tag = "Respawn";
                spawnCounter++;
            }
        }
    }

    private void grabbed() //Script para mover objetos.
    {
        grabbing.GetComponent<Rigidbody>().useGravity = false;
        grabbing.GetComponent<Rigidbody>().isKinematic = true;
        grabbing.transform.position = puntoAgarre.transform.position;
        grabbing.transform.rotation = puntoAgarre.transform.rotation;
        grabbing.transform.parent = puntoAgarre.transform;
    }

    public void released()  //Script para soltar objetos.
    {
        grabbingInput = false;
        grabbing.GetComponent<Rigidbody>().useGravity = true;
        grabbing.GetComponent<Rigidbody>().isKinematic = false;
        grabbing.transform.parent = null;
        grabbing.transform.position = puntoAgarre.transform.position;
        grabbing = null;
        ungrabInput = false;
    }

    private void OnTriggerEnter(Collider other) //Script que si el jugador toca los lasers pierde instanteamente.
    {
        if (other.gameObject.tag == "Laser")
        {
            RestarVida(100f);
        }
    }

    // Funciones de la vida
    public void RestarVida(float cantidad) //Script que resta la vida al jugador al pasar por encima de la lava.
    {
        if (!invencible && vida > 0)
        {
            vida -= cantidad;

            StartCoroutine(Invulnerabilidad());

            if (vida <= 0)
            {
                GameOver();
            }
        }
    }

    private void GameOver() //Script de fin de juego al momento de que el jugador muera.
    {
        showMuerte = !showMuerte;
        if (showMuerte)
        {
            crosshair.SetActive(false);
            Cursor.lockState = CursorLockMode.None;

            canvasMuerte.SetActive(true);
            showMuerte = !showMuerte;

            canvasVida.SetActive(false);

            GetComponent<ComportamientoPersonaje>().enabled = false;
        }
    }

    //Crea una especie de tiempo de invencibilidad para evitar que se le reste vida de la forma default (con cada frame) ya que es demasiado rapida.
    IEnumerator Invulnerabilidad()
    {
        invencible = true;
        yield return new WaitForSeconds(tiempo_invencible);
        invencible = false;
    }

    public void RestarVidaTorreta(int cantidad) //Script que se encarga de restar la vida del jugador cuando es impactado por una bala de la torreta.
    {
        if (vida > 0)
        {
            vida -= cantidad;
            if (vida == 0)
            {
                GameOver();
            }
        }
    }
}

