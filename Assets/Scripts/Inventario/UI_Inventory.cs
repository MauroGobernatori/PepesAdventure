using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Este script se encarga de mostrar los objetos que están en el inventario

// Este script está puesto en un objeto del canvas "UI_Inventory)

public class UI_Inventory : MonoBehaviour
{

    private Inventario inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    private void Awake()
    {
        itemSlotContainer = transform.Find("ItemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
    }

    public void setInventory(Inventario inventory)
    {
        this.inventory = inventory;
        refreshInventory();
    }

    private void refreshInventory()
    {
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 50f;
        foreach (Item item in inventory.getItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
            image.sprite = item.getSprite();
            x++;
            if (x > 4) x = 0;
        }
    }
}
