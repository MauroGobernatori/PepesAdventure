using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Con este script se elije el tipo de Item que es el objeto
// Se debe elegir desde el inspector el tipo de Item

// Está puesto en los objetos "sagrados" de la escena
public class Collectable : MonoBehaviour
{
    public Item.ItemType itemType;
}
