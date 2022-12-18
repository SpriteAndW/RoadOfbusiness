using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenShopPanel : MonoBehaviour
{
    //���Ҫ���ĵ�
    public Shops shop;

    //����Ҫ���ѵ���Ʒ
    public Item[] items;

    //����������Ϣ
    public Text description;

    public Image shopImg;

    //�ֿ���Ϣ
    public Inventory myBag;

    

    /// <summary>
    /// ˢ�¹���panel
    /// </summary>
    public void Refresh()
    {
        shopImg.sprite = shop.shopImg;
        description.text = string.Format
            ("�㽫ҪӪҵ{0}�����������ĲƸ�ֵ{1}�Լ���������",
            shop.shopName, shop.openShopPrice);
        for (int i = 0; i < shop.deductionItem.Length; i++)
        {
            description.transform.GetChild(i).gameObject.SetActive(true);
            //���������Ʒ�������ж��ٸ��ͰѶ��ٸ��Ǹ�ͼƬ����ȥ

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
        //    description.text = "���Ѿ�ӵ�и�������";
        //    return;
        //}
        if (Business.Instance.shops.Count >= 30)
        {
            MessageWindow.Instance.ShowMessage( "���Ѿ�����30�ҵ����ˣ������ٿ�������");
            return;
        }
        if (shop.shopName == "�����" || shop.shopName == "����")
        {
            if(Business.Instance.currentJoinLeague < 2)
            {
                MessageWindow.Instance.ShowMessage("������˲�����Ӫҵ�õ���");
                return;
            }
        }
        if(Business.Instance.wealth >= shop.openShopPrice && JudgeWealth() )
        {
            Business.Instance.wealth -= shop.openShopPrice;
            Business.Instance.shops.Add(shop);
            MessageWindow.Instance.ShowMessage("����ɹ�");
            gameObject.SetActive(false);
            for (int i = 0; i < shop.deductionItem.Length; i++)
            {
                shop.deductionItem[i].itemHeld -= shop.costItemNum[i];
            }
        }
        else
        {
            MessageWindow.Instance.ShowMessage("��û���㹻��Ǯ������ȥ����");
        }
        //���ˢ������
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
