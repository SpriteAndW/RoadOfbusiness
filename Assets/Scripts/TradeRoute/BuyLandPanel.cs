using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyLandPanel : MonoBehaviour
{
    public MapGridInfo mgInfo;
    public Text description;
    public Image itemImg;
    public void Refresh()
    {
        description.text = string.Format("花费{0}财富值购买{1}，土地每回合将产出随机数量以下产物", mgInfo.price, mgInfo.mapName);
        itemImg.sprite = mgInfo.product.itemImg;
    }


    public void ConfirmBuy()
    {
        if (Business.Instance.myLand.Contains(mgInfo))
        {
            MessageWindow.Instance.ShowMessage(string.Format("你已经拥有{0}，请勿重复购买", mgInfo.mapName));
            return;
        }
        if(Business.Instance.wealth < mgInfo.price)
        {
            MessageWindow.Instance.ShowMessage("你的财富值不足以购买");
            return;
        }
        //确认购买 把地加在business中 然后关闭窗口
        Business.Instance.myLand.Add(mgInfo);
        Business.Instance.wealth -= mgInfo.price;
        MessageWindow.Instance.ShowMessage("购买成功");
        gameObject.SetActive(false);
        MainWindow.Instance.Refresh();
    }

    public void CancelBuy()
    {
        gameObject.SetActive(false);
    }
}
