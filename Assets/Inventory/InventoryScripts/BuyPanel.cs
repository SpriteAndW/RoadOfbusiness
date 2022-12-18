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
    //�ܹ����Ѽ۸�
    public int cost;
    //����
    public TextMeshProUGUI description;
    public StoreWindow storeW;

    public void UpdateInfo()
    {
        cost = (int)(commdity.price * commdity.itemRemainder);
        commdityImage.sprite = commdity.itemImg;
        description.text = string.Format("������{0}��{1}���ܹ�����{2}Ԫ���Ƿ�ȷ�Ϲ���"
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
            //��Ǯ
            Business.Instance.wealth -= cost;
            //����Ʒ�Ǹ�����ȥ
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
            
            //��ӽ��״���
            Business.Instance.transactionNum++;
        }
        else
        {
            description.text = "Ǯ����Ŷ";
        }
        
        GameController.Instance.Refresh();
    }
}
