using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Con este script se elije el tipo de Item que es el objeto
// Está puesto en los objetos "sagrados" de la escena
// Se debe elegir desde el inspector el tipo de Item
public class Collectable : MonoBehaviour
{
    public Item.ItemType itemType;
}
