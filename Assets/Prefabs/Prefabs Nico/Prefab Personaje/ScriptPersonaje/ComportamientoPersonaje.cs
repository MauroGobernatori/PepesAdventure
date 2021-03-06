using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este script hace todos los movimientos del personaje

// Este script está puesto en el personaje

public class ComportamientoPersonaje : MonoBehaviour
{

    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;
    private Animator anim;
    public float x, y;


    public Rigidbody rb;
    public float fuerzaDeSalto = 5f;
    public bool puedoSaltar;

    public float velocidadInicial;
    public float velocidadAgachado;


    // Start is called before the first frame update
    void Start()
    {
        puedoSaltar = false;
        anim = GetComponent<Animator>();
        velocidadInicial = velocidadMovimiento;
        velocidadAgachado = velocidadMovimiento * 0.5f;
    }
    

    void FixedUpdate()
    {
        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        transform.Translate(0,0, y * Time.deltaTime * velocidadMovimiento);
    }


    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        if(puedoSaltar)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("salte", true);
                rb.AddForce(new Vector3(0, fuerzaDeSalto, 0), ForceMode.Impulse);
            }

            if (Input.GetKey(KeyCode.LeftControl))
            {
                anim.SetBool("agachado", true);
                velocidadMovimiento = velocidadAgachado;
                gameObject.GetComponent<CapsuleCollider>().height = 1.5f;
            } 
            else 
            {
                anim.SetBool("agachado", false);
                velocidadMovimiento = velocidadInicial;
                gameObject.GetComponent<CapsuleCollider>().height = 1.9f;
            }

            anim.SetBool("tocoSuelo", true);
        } 
        else
        {
            EstoyCayendo();
        }
    } 

    public void EstoyCayendo()
    {
        anim.SetBool("tocoSuelo", false);
        anim.SetBool("salte", false);
    }
}