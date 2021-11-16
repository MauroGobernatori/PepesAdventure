using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este script es el inventario que no se destruye en el cambio de escena
// Cada vez que se agarra un objeto, es agregado a una lista

// Este script esta puesto en un objeto vacío "Inventario"
public class Inventario : MonoBehaviour
{
    public List<Item> itemList;

    private void Awake()
    {
        itemList = new List<Item>();

        DontDestroyOnLoad(this.gameObject);
    }

    public List<Item> getItemList()
    {
        return itemList;
    }

}
