using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tool;

public class BankruptcyWindow : UIFunctionWindow
{
    public Shops[] shops;
    public GameObject BankruptcyPrefab;
    public Transform grid;
    public static BankruptcyWindow Instance;
    protected override void Start()
    {
        base.Start();
        Instance = this;
    }

    public void Refresh()
    {

        for (int i = 0; i < grid.childCount; i++)
        {
            grid.GetChild(i).gameObject.SetActive(false);
        }
        for (int i = 0; i < Business.Instance.shops.Count; i++)
        {
            if(Business.Instance.shops[i] == null)
            {
                continue;
            }
            //grid.GetchildByname(Business.Instance.shops[i].shopName).gameObject.SetActive(true);
            //grid.GetchildByname(Business.Instance.shops[i].shopName).GetComponent<Bankruptcy>().shop = Business.Instance.shops[i];
            //grid.GetchildByname(Business.Instance.shops[i].shopName).GetComponentInChildren<Text>().text = Business.Instance.shops[i].shopName;
            Bankruptcy bkryp = Instantiate(BankruptcyPrefab, grid).GetComponent<Bankruptcy>();
            bkryp.shop = Business.Instance.shops[i];
            bkryp.GetComponentInChildren<Text>().text = Business.Instance.shops[i].shopName;
            bkryp.GetComponent<Image>().sprite = Business.Instance.shops[i].shopImg;
        }
    }

}
