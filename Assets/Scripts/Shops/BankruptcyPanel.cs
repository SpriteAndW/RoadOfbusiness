using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankruptcyPanel : MonoBehaviour
{
    public Shops shop;

    public void Cancel()
    {
        gameObject.SetActive(false);
    }


    public void Bankruptcy()
    {
        Business.Instance.shops.Remove(shop);
        shop.totalPassengerFlow = 0;
        shop.famous = 1;
        gameObject.SetActive(false);
        BankruptcyWindow.Instance.Refresh();
    }
}
