using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
