﻿using System.Collections;
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

    //Canvas Crosshair
    private GameObject crosshair;

    private GameObject camera;

    private bool grabInput = false;
    public bool grabbingInput = false;
    private bool ungrabInput = false;
    private GameObject grabbing;
    private GameObject puntoAgarre;

    //Probando subir la platform
    private bool pruebaPlat = false;
    [SerializeField] private GameObject cylinder1;
    [SerializeField] private GameObject cylinder2;
    [SerializeField] private GameObject cylinder3;
    [SerializeField] private GameObject cube1;
    [SerializeField] private GameObject cube2;
    [SerializeField] private GameObject cube3;

    // Probando pasar la vida
    public float vida = 100;
    private bool invencible = false;
    //private GameObject jugador;
    [SerializeField] private float tiempo_invencible = 1f;
    [SerializeField] private float tiempo_frenado = 0.2f;

    private void Awake()
    {
        puntoAgarre = GameObject.Find("puntoAgarre");
        grabbing = GameObject.Find("Grabbing");
        crosshair = GameObject.Find("CrossHair");
        canvasInventory = GameObject.Find("UI_Inventory");
        if (canvasInventory.activeInHierarchy)
        {
            // Si el inventario está activo en canvas, desactivarlo
            canvasInventory.SetActive(false);
        }

        // Obtiene el inventario, vacío en la primer escena, con objetos las siguientes escenas
        inventory = GameObject.FindGameObjectWithTag("Inventario").GetComponent<Inventario>();
        uiInventory.setInventory(inventory);

        // Obtener la cámara para ver donde apunto
        camera = GameObject.FindWithTag("PlayerCamera");

        canvasMuerte = GameObject.Find("MenuMuerte");
        
    }

    private void Start()
    {
        if (canvasMuerte.activeInHierarchy)
        {
            // Si la muerte está activo en canvas, desactivarlo
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
        if (Input.GetKeyDown(KeyCode.G))
        {
            pruebaPlat = true;
        }
    }

    private void FixedUpdate()
    {
        //Para que no reboten las plataformas (No se por qué rebotaban a veces)
        if (cube1.transform.position.y >= 29.656f)
        {
            cube1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            cube1.transform.position = new Vector3(cube1.transform.position.x, 29.656f , cube1.transform.position.z);
        }
        if (cube2.transform.position.y >= 29.656f)
        {
            cube2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            cube2.transform.position = new Vector3(cube2.transform.position.x, 29.656f, cube2.transform.position.z);
        }
        if (cube3.transform.position.y >= 29.656f)
        {
            cube3.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            cube3.transform.position = new Vector3(cube3.transform.position.x, 29.656f, cube3.transform.position.z);
        }
        if (grabInput)
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = camera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x,y));
            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.gameObject.GetComponent<cajaMovible>())
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

        if (pruebaPlat)
        {
            cylinder1.transform.localScale += new Vector3(0, 3.1f, 0) * Time.deltaTime * 2;
            cylinder2.transform.localScale += new Vector3(0, 3.1f, 0) * Time.deltaTime * 2;
            cylinder3.transform.localScale += new Vector3(0, 3.1f, 0) * Time.deltaTime * 2;
            if (cylinder1.transform.localScale.y >= 12.4 && cylinder2.transform.localScale.y >= 12.4 && cylinder3.transform.localScale.y >= 12.4) pruebaPlat = false;
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
        if(other.gameObject.tag == "Laser")
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

            GetComponent<FirstPersonMovement>().enabled = false;
            GetComponent<Jump>().enabled = false;
            GetComponent<Crouch>().enabled = false;
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
}
