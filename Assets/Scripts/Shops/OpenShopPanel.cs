using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenShopPanel : MonoBehaviour
{
    //点击要开的店
    public Shops shop;

    //开店要花费的物品
    public Item[] items;

    //购买描述信息
    public Text description;

    public Image shopImg;

    //仓库信息
    public Inventory myBag;

    

    /// <summary>
    /// 刷新购买panel
    /// </summary>
    public void Refresh()
    {
        shopImg.sprite = shop.shopImg;
        description.text = string.Format
            ("你将要营业{0}店铺所需消耗财富值{1}以及消耗物资",
            shop.shopName, shop.openShopPrice);
        for (int i = 0; i < shop.deductionItem.Length; i++)
        {
            description.transform.GetChild(i).gameObject.SetActive(true);
            //如果消耗物品的数组有多少个就把多少个那个图片整上去

            description.transform.GetChild(i).GetComponent<Image>().sprite = 
                shop.deductionItem[i].itemImg;
            description.transform.GetChild(i).GetComponentInChildren<Text>().text = shop.costItemNum[i].ToString();
        }
        for (int i = 1; i >= shop.deductionItem.Length; i--)
        {
            description.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void OpenShop()
    {
        //if (Business.Instance.shops.Contains(shop))
        //{
        //    description.text = "你已经拥有该商铺了";
        //    return;
        //}
        if (Business.Instance.shops.Count >= 30)
        {
            MessageWindow.Instance.ShowMessage( "你已经开了30家店铺了，不能再开启店铺");
            return;
        }
        if (shop.shopName == "古玩店" || shop.shopName == "粮店")
        {
            if(Business.Instance.currentJoinLeague < 2)
            {
                MessageWindow.Instance.ShowMessage("你的商盟不够格营业该店铺");
                return;
            }
        }
        if(Business.Instance.wealth >= shop.openShopPrice && JudgeWealth() )
        {
            Business.Instance.wealth -= shop.openShopPrice;
            Business.Instance.shops.Add(shop);
            MessageWindow.Instance.ShowMessage("购买成功");
            gameObject.SetActive(false);
            for (int i = 0; i < shop.deductionItem.Length; i++)
            {
                shop.deductionItem[i].itemHeld -= shop.costItemNum[i];
            }
        }
        else
        {
            MessageWindow.Instance.ShowMessage("你没有足够的钱或物资去购买");
        }
        //添加刷新属性
        GameController.Instance.Refresh();
    }

    private bool JudgeWealth()
    {
        for (int i = 0; i < shop.deductionItem.Length; i++)
        {
            if(!myBag.itemList.Contains(shop.deductionItem[i]) 
                || shop.deductionItem[i].itemHeld < shop.costItemNum[i])
            {
                return false;
            }
        }
        return true;
    }

    public void Cancel()
    {
        gameObject.SetActive(false);
        if (DialogueManager.instance.isShopGuideing)
        {
            NoviceGuidePanel._instance.NextStep(ShopGuideConst.CloseShopDetail);
        }
    }
}
