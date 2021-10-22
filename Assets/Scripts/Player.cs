using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField] private float tiempo_frenado = 0.2f;



    private void Awake()
    {


    }

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
        if (Input.GetKeyDown(KeyCode.I))
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
        if (Input.GetKeyDown(KeyCode.Z))
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

    private void OnCollisionEnter(Collision collision)
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
    }

    private void grabbed()
    {
        grabbing.GetComponent<Rigidbody>().useGravity = false;
        grabbing.GetComponent<Rigidbody>().isKinematic = true;
        grabbing.transform.position = puntoAgarre.transform.position;
        grabbing.transform.rotation = puntoAgarre.transform.rotation;
        grabbing.transform.parent = puntoAgarre.transform;
    }

    public void released()
    {
        grabbingInput = false;
        grabbing.GetComponent<Rigidbody>().useGravity = true;
        grabbing.GetComponent<Rigidbody>().isKinematic = false;
        grabbing.transform.parent = null;
        grabbing.transform.position = puntoAgarre.transform.position;
        grabbing = null;
        ungrabInput = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Laser")
        {
            RestarVida(100f);
        }
    }

    // Funciones de la vida
    public void RestarVida(float cantidad)
    {
        if (!invencible && vida > 0)
        {
            vida -= cantidad;
            StartCoroutine(Invulnerabilidad());
            StartCoroutine(FrenarVelocidad());

            if (vida == 0)
            {
                GameOver();
            }
        }
    }

    private void GameOver()
    {
        //Poner aqui script para menu de muerte.
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

    //Guarda en la variable velocidadActual la velocidad con la que el jugador toca la lava.
    IEnumerator FrenarVelocidad()
    {
        var velocidadActual = GetComponent<FirstPersonMovement>().speed;
        GetComponent<FirstPersonMovement>().speed = 0;
        yield return new WaitForSeconds(tiempo_frenado);
        GetComponent<FirstPersonMovement>().speed = velocidadActual;
    }
    public void RestarVidaTorreta(int cantidad)
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

