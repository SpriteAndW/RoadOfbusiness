using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tool;
using UnityEngine;

public class SetActionSaver : MonoSingleton<SetActionSaver>
{
    public List<Item> allitem;
    public MapGridInfo[] allgridInfo;
    public Inventory[] allbags;
    public Shops[] shops;
    public MapInventory mapBag;
    public TradeDelegate[] Tdelegate;
    public BusinessItem[] allboss;
    public Marrier[] allMarriers;
    public TradeDelegateBar tradeBar;

    
    
    /// <summary>
    /// 创建初始存档在0档位

    /// </summary>
    void Start()
    {
        for (int i = 0; i < allitem.Count; i++)
        {
            allitem[i].itemHeld = 0;
            allitem[i].itemRemainder = 0;
            allitem[i].price = allitem[i].basePrice;
        }

        for (int i = 0; i < allgridInfo.Length; i++)
        {
            allgridInfo[i].arriveItem = null;
            allgridInfo[i].itemNum = 0;
            allgridInfo[i].transportItem = null;
            allgridInfo[i].mapColor = Color.white;
        }
        for (int i = 0; i < allbags.Length; i++)
        {

            allbags[i].itemList = allitem;
        }
        for (int i = 0; i < shops.Length; i++)
        {
            shops[i].totalPassengerFlow = 0;
        }
        for (int i = 0; i < allMarriers.Length; i++)
        {
            allMarriers[i].intimacy = 0;
            allMarriers[i].isGift = false;
        }
        mapBag.index = 0;
        mapBag.road0.Clear();
        mapBag.road1.Clear();
        mapBag.road2.Clear();
        mapBag.road3.Clear();
        mapBag.road4.Clear();
        mapBag.road5.Clear();
        mapBag.road6.Clear();
        mapBag.road7.Clear();
        mapBag.road8.Clear();
        mapBag.road9.Clear();
        mapBag.road10.Clear();
        mapBag.road11.Clear();
        mapBag.road12.Clear();
        mapBag.road13.Clear();
        mapBag.road14.Clear();

        for (int i = 0; i < Tdelegate.Length; i++)
        {
            Tdelegate[i].playdays = 0;
            Tdelegate[i].deadline = 0;
            Tdelegate[i].address = null;
            Tdelegate[i].Deposit = 0;
            Tdelegate[i].rewardCredit = 0;
            Tdelegate[i].rewardWealth = 0;
            Tdelegate[i].itemNum = 0;
            Tdelegate[i].isAccept = false;
        }

        for (int i = 0; i < allboss.Length; i++)
        {
            allboss[i].intimacy = 0;
            allboss[i].isRec = false;
        }

        tradeBar.delegateBar = Tdelegate.ToList();
        
        BankManager.Instance.saveRecordDetailList.savrRecordList.Clear();
        
        //将引导状态也更新
        PlayerPrefs.SetInt(Const.BankNovice, 0);
        PlayerPrefs.SetInt(Const.ShopNovice, 0);
        PlayerPrefs.SetInt(Const.ReceptionRoomNovice, 0);
        
        //已经对话清空
        DialogueManager.instance.MainDoneDialogue.Clear();
        DialogueManager.instance.BranchDoneDialogue.Clear();



        //存档放在最后
        GameSaveManger.Instance.SaveAllData(0);

    }


}
