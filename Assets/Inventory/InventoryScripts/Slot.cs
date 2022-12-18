using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image itemSprite;
    public Item slotItem;
    public Text slotNum;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(AddDescription);
    }

    private void AddDescription()
    {
        InventoryWindow.Instance.itemInfo.text = string.Format("{0}\n价格:{1}   保质期:{2}天", slotItem.itemInfo, slotItem.price, slotItem.QGP);
    }
}
