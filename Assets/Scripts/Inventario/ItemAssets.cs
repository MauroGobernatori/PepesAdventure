using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este script tiene los Sprites de los objetos "sagrados" para que se vean en el inventario
// Está puesto en un objeto vació en la escena
public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Sprite book;
    public Sprite bronce_Ring;
    public Sprite clover;
    public Sprite feather;
    public Sprite scroll;
}
