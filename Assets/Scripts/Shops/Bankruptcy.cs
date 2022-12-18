using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bankruptcy : MonoBehaviour
{
    public Shops shop;
    public BankruptcyPanel panel;
    private void Awake()
    {
        panel = Resources.FindObjectsOfTypeAll<BankruptcyPanel>()[0];
        GetComponent<Button>().onClick.AddListener(openBankruptcyPanel);

    }

    private void openBankruptcyPanel()
    {
        panel.shop = shop;
        panel.gameObject.SetActive(true);
    }
}
