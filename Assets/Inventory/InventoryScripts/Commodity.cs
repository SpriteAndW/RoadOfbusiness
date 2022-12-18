using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Commodity : MonoBehaviour
{
    //商品挂载的脚本

    //提供点击购买的功能
    //购买面板的引用
    public BuyPanel buyPanel;
    public Item commodity;
    public void UpdateInfo()
    {
        GetComponent<Image>().sprite = commodity.itemImg;
        GetComponentInChildren<Text>().text = commodity.itemRemainder.ToString();
    }

    public void OpenBuyPanel()
    {
        buyPanel.gameObject.SetActive(true);
        buyPanel.commdity = commodity;
        buyPanel.UpdateInfo();
    }
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OpenBuyPanel);
    }
}
