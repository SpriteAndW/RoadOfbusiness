using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tool;
using UnityEngine.UI;
using TMPro;

public class BuyPanel : MonoBehaviour
{
    public Item commdity;
    public Image commdityImage;
    public Inventory myBag;
    //总共花费价格
    public int cost;
    //描述
    public TextMeshProUGUI description;
    public StoreWindow storeW;

    public void UpdateInfo()
    {
        cost = (int)(commdity.price * commdity.itemRemainder);
        commdityImage.sprite = commdity.itemImg;
        description.text = string.Format("共购买{0}个{1}，总共花费{2}元，是否确认购买？"
            , commdity.itemRemainder, commdity.itemName, cost);
    }

    public void Cancel()
    {
        gameObject.SetActive(false);
    }

    public void Buy()
    {
        if(Business.Instance.wealth >= cost)
        {
            //扣钱
            Business.Instance.wealth -= cost;
            //把商品那个加上去
            if (myBag.itemList.Contains(commdity))
            {
                commdity.AddItemHeld( commdity.itemRemainder);
                commdity.itemRemainder = 0;
            }
            else
            {
                myBag.itemList.Add(commdity);
                commdity.itemHeld = commdity.itemRemainder;
                commdity.itemRemainder = 0;
            }

            storeW.Refresh();
            gameObject.SetActive(false);
            
            //添加交易次数
            Business.Instance.transactionNum++;
        }
        else
        {
            description.text = "钱不够哦";
        }
        
        GameController.Instance.Refresh();
    }
}
