using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Esta clase es el enum de los objetos "sagrados", que van a ser tomados por cada objeto sagrado de la escena
// Tienen un nombre y un sprite, el sprite tomado de ItemAssets.cs
public class Item {
    public enum ItemType
    {
        book,
        bronce_ring,
        clover,
        feather,
        scroll
    }
    public ItemType itemType;

    // Esta función toma los scripts de cada objeto
    public Sprite getSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.book:
                return ItemAssets.Instance.book;
            case ItemType.bronce_ring:
                return ItemAssets.Instance.bronce_Ring;
            case ItemType.clover:
                return ItemAssets.Instance.clover;
            case ItemType.feather:
                return ItemAssets.Instance.feather;
            case ItemType.scroll:
                return ItemAssets.Instance.scroll;
        }
    }
}
