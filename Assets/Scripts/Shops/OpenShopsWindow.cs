using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenShopsWindow : MonoBehaviour
{
    public Shops[] shops;
    public string[] shopsName;
    public static OpenShopsWindow Instance;
    public Transform grid;

    
    protected  void Start()
    {
        // base.Start();
        //shops = new Shops[6]; 
        /***********               ��ջ��  ˮ���꣬  �鱦�꣬    �͹ݣ�       ��Ժ��      ��ׯ ***/
        //shopsName = new string[] { "Inn", "Fruit", "Jade", "Restaurant", "Brothel", "Cloth" };
        
        //for (int i = 0; i < shopsName.Length; i++)
        //{
        //    //��ÿ�����̶��󶼴��������������������
        //    shops[i] = ChooseFactory.CreateShops(shopsName[i]);

        //    shops[i].shopImg = ResourcesManger.Load<GameObject>(shopsName[i]).GetComponent<Image>().sprite;
        //}
        //print(shops);
        Instance = this;
        Refresh();
    }

    public void Refresh()
    {
        //for (int i = 0; i < shops.Length; i++)
        //{
        //    grid.GetChild(i).GetComponent<Image>().sprite = shops[i].shopImg;
        //    //grid.GetChild(i).GetComponent<ShopPrefab>().shop = shops[i];
        //}
    }

    public void ShopGuideChooseShopDetail()
    {
        
        if (DialogueManager.instance.isShopGuideing)
        {
            NoviceGuidePanel._instance.NextStep(ShopGuideConst.ChooseShopDetail);
        }
    }
    
    public void ShopGuideCloseShop()
    {
        gameObject.SetActive(false);

        
        if (DialogueManager.instance.isShopGuideing)
        {
            NoviceGuidePanel._instance.NextStep(ShopGuideConst.CloseShop);
        }
    }

    

}
