using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Script encargado de subir y bajar la plataforma donde se encuentra la torreta en la habitación 3.
*/

public class subirBajarTorreta : MonoBehaviour
{

    private bool subir = true;
    private bool bajar = false;

    private void FixedUpdate()
    {
        if (subir)
        {
            transform.position += new Vector3(0, 3.1f, 0) * Time.deltaTime / 2;
        }
        if (bajar)
        {
            transform.position -= new Vector3(0, 3.1f, 0) * Time.deltaTime / 2;
        }

        if(transform.localPosition.y >= 19)
        {
            subir = false;
            bajar = true;
        }
        if(transform.localPosition.y <= 2)
        {
            subir = true;
            bajar = false;
        }

    }

}
