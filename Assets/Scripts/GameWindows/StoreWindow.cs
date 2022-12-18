using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreWindow : UIFunctionWindow
{
    public static StoreWindow instance;
    public Transform grid;
    public Text wealthText;
    public Text creditText;

    protected override void Start()
    {
        // base.Start();
        print("doo");
        instance = this;
        if (FindObjectsOfType<StoreWindow>().Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    public static StoreWindow Instance
    {
        get
        {
            return instance;
        }
    }

    public Inventory store;

    public void Refresh()
    {
        wealthText.text = string.Format("财富值：{0}", Business.Instance.wealth);
        creditText.text = string.Format("信用值：{0}", Business.Instance.credit);
        for (int i = 0; i < 8; i++)
        {
            if (store.itemList[i].itemRemainder == 0)
            {
                grid.GetChild(i).GetChild(1).gameObject.SetActive(true);
                grid.GetChild(i).GetComponent<Button>().enabled = false;

            }

            //如果物品数量不为0
            else
            {
                grid.GetChild(i).GetChild(1).gameObject.SetActive(false);
                Commodity comm = grid.GetChild(i).GetComponent<Commodity>();
                grid.GetChild(i).GetComponent<Button>().enabled = true;
                comm.commodity = store.itemList[i];
                comm.UpdateInfo();
            }
        }
    }

    //进货 每回合初调用一次 playdays % 10 == 1
    public void Purchase()
    {
        for (int i = 0; i < 8; i++)
        {
            Item item = store.itemList[i];
            int index = Random.Range(8, store.itemList.Count);
            store.itemList[i] = store.itemList[index];
            store.itemList[index] = item;
            store.itemList[i].itemRemainder = Random.Range(1, 5) * 100;
            store.itemList[i].price *= Random.Range(0.9f, 1.1f);
        }
        SettleWindow.Instance.settleText.text += "今天商店进货了\n";
    }

    public void BackMainScene()
    {
        gameObject.GetComponent<UIFunctionWindow>().SetVisible(false);
        GameController.Instance.Refresh();
        EventHandler.CallAfterSceneLoadeEvent("MainScene");
    }
}
