﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventorySlot : MonoBehaviour
{

    public Item item;
    public Button removeButton;


    private Text Amount;
    private Image Icon;



    public void Awake()
    {

        Amount = transform.Find("Ammo").GetComponent<Text>();
        Icon = transform.Find("Icon").GetComponent<Image>();


    }

    public void OnSlotClicked()
    {
        if (item != null)
        {

            item.Equip();
        }
        
    }

    public void AddItem(Item newItem)
    {
        item = newItem;


        if(item.slotCategory == Category.Equipment)
        {
            Amount.gameObject.SetActive(false);

        }
        Icon.sprite = item.icon;
        Icon.enabled = true;
        //removeButton.interactable = true;

        
    }



    public void ClearSlot()
    {


        item = null;

        Amount.gameObject.SetActive(false);

        Icon.sprite = null;
        Icon.enabled = false;
        //removeButton.interactable = false;

    }
  
}
