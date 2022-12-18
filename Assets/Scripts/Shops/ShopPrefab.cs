using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPrefab : MonoBehaviour
{
    public OpenShopPanel shopPanel;
    public Shops shop;
    public void OpenBuyPanel()
    {
        shopPanel.gameObject.SetActive(true);
        shopPanel.shop = shop;
        shopPanel.Refresh();
    }
    private void Start()
    {
        //shop = GetComponent<Shops>();
        shop.shopImg = GetComponent<Image>().sprite;    
        GetComponentInChildren<Text>().text = shop.shopName;
        GetComponent<Button>().onClick.AddListener(OpenBuyPanel);
    }
}
