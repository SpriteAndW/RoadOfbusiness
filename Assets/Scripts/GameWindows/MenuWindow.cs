using System;
using System.Collections;
using System.Collections.Generic;
using Tool;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class MenuWindow : UIFunctionWindow
{
    public TradeDelegateBar tradeBar;
    SaveDataWindow saveW;
    MainWindow mainW;
    InventoryWindow inveW;
    TaskWindow taskW;
    IntimacyWindow intiW;
    HelpWindow HelpW;
    private SettingWindow settingW;
    public MapInventory mapInven;
    public Marrier[] marriers;
    public static MenuWindow Instance;


    //商店进货标志 如果到了场景5 且这个标志位true则进货
    //public bool purchaseFlag;
    protected override void Start()
    {
        base.Start();
        GetUIeventhandler("Save").PointerClick += SaveData;
        GetUIeventhandler("Sleep").PointerClick += Sleep;
        GetUIeventhandler("Inventory").PointerClick += OpenBag;
        GetUIeventhandler("Task").PointerClick += OpenTask;
        GetUIeventhandler("Intimacy").PointerClick += Intimacy;
        GetUIeventhandler("Setting").PointerClick += Setting;
        GetUIeventhandler("Help").PointerClick += Help;

        //GetUIeventhandler("Load").PointerClick += LoadData;
        saveW = UIManger.Instance.Getwindows<SaveDataWindow>();
        mainW = UIManger.Instance.Getwindows<MainWindow>();
        inveW = UIManger.Instance.Getwindows<InventoryWindow>();
        taskW = UIManger.Instance.Getwindows<TaskWindow>();
        intiW = UIManger.Instance.Getwindows<IntimacyWindow>();
        settingW = UIManger.Instance.Getwindows<SettingWindow>();
        HelpW = UIManger.Instance.Getwindows<HelpWindow>();
        Instance = this;
    }

    private void Setting(PointerEventData eventData)
    {
        settingW.SetVisible(true);
        settingW.Refresh();
    }

    private void Intimacy(PointerEventData eventData)
    {
        intiW.SetVisible(true);
        intiW.Refresh();
    }

    private void OpenTask(PointerEventData eventData)
    {
        taskW.SetVisible(true);
        taskW.Refresh();
    }

    private void Help(PointerEventData eventData)
    {
        HelpW.SetVisible(true);
    }

    private void OpenBag(PointerEventData eventData)
    {
        InventoryWindow.Refresh();
        inveW.SetVisible(true);
    }

    private void Sleep(PointerEventData eventData)
    {
            SettleWindow.Instance.settleText.text = "";
            Business.Instance.playDays += 1;
            if (Business.Instance.playDays % 10 == 1 || Business.Instance.playDays % 10 == 9 || Business.Instance.playDays % 10 == 5)
            {
                //商店进货
                //purchaseFlag = true;
                if (StoreWindow.Instance != null)
                {
                    StoreWindow.Instance.Purchase();
                }

            }
            if (Business.Instance.playDays % 10 == 2 || Business.Instance.playDays % 10 == 5 || Business.Instance.playDays % 10 == 8)
            {

                //贸易路线对外贸易刷新功能
                for (int i = 0; i < tradeBar.delegateBar.Count; i++)
                {
                    if (Business.Instance.tradeDele.Contains(tradeBar.delegateBar[i]))
                    {
                        continue;
                    }

                    tradeBar.delegateBar[i].isAccept = false;
                    tradeBar.delegateBar[i].GenerateRandomDelegate();
                    //在结算面板加一下
                }

                SettleWindow.Instance.settleText.text += "贸易路线对外贸易任务刷新了\n";
            }
            
            //钱庄功能还钱   2022.10.26 把10天收一次款改成3天
            if (Business.Instance.playDays % 3 == 0)
            {
                //钱庄贷款存款利息
                if (Business.Instance.playDays % 3 == 0)
                {
                    //如果玩家还不起钱,扣去信用值并且财富为负数
                    if (BankManager.Instance.PlayerWealthChangeOnBank() < 0 &&
                        Business.Instance.wealth < -BankManager.Instance.PlayerWealthChangeOnBank())
                    {
                        // Business.Instance.credit -= 5f;
                        Business.Instance.wealth += BankManager.Instance.PlayerWealthChangeOnBank();
                        Business.Instance.borrowMoneyCantNum++;
                    }
                    else
                    {
                        Business.Instance.wealth += BankManager.Instance.PlayerWealthChangeOnBank();
                    }
                }

                //扣取店铺的相对应物资
                for (int i = 0; i < Business.Instance.shops.Count; i++)
                {
                    //如果钱够 物资够 直接扣取
                    if (Business.Instance.shops[i].JudgeWealth() &&
                        Business.Instance.wealth >= Business.Instance.shops[i].openShopPrice)
                    {
                        Business.Instance.shops[i].CostMaterial();
                        foreach (var item in Business.Instance.shops[i].deductionItem)
                        {

                            if (item.QGP <= 0)
                            {
                                SettleWindow.Instance.settleText.text += string.Format("你的{0}店铺使用了过期的{1}\n",
                                    Business.Instance.shops[i].shopName, Business.Instance.shops[i].deductionItem[i].itemName);
                                Business.Instance.outQGPShops.Add(Business.Instance.shops[i]);
                            }
                        }

                    }

                    //如果不够 倒闭 扣取信用值 在结算面板生成记录
                    else
                    {
                        SettleWindow.Instance.bankruptcyShopName.Add(Business.Instance.shops[i].shopName);
                        Bankruptcy(Business.Instance.shops[i]);
                    }
                }




                //玩家购买的地块产出物资 每回合产出一次 随机300-1000
                for (int i = 0; i < Business.Instance.myLand.Count; i++)
                {
                    int random = Random.Range(3, 10) * 100;
                    Business.Instance.myLand[i].product.AddItemHeld(random);
                    SettleWindow.Instance.settleText.text += string.Format("你购买的地为你产出了{0}个{1}\n", (int)random,
                        Business.Instance.myLand[i].product.itemName);
                }

                for (int i = 0; i < GameSaveManger.Instance.allboss.Length; i++)
                {
                    GameSaveManger.Instance.allboss[i].isRec = false;
                }
            }

            SetVisible(false);
            mainW.isOpenMenu = false;


            //店铺赚钱功能 每天赚
            foreach (var item in Business.Instance.shops)
            {
                if (item != null)
                {
                    //同时在这判断今天的客流量
                    item.CalculatePassengerFlow();
                    item.EarnWealth();
                }

            }

            //贸易路线 路线行走功能
            for (int i = 0; i < mapInven.allRoads.Count; i++)
            {
                if (mapInven.allRoads[i].Count == 0) continue;
                if (mapInven.allRoads[i][0].isArrive)
                {
                    //然后送达的第二天 把格子的东西全部清空
                    mapInven.allRoads[i][0].isArrive = false;
                    mapInven.allRoads[i][0].itemNum = 0;
                    mapInven.allRoads[i][0].arriveItem = null;
                    mapInven.allRoads[i][0].transportItem = null;
                    mapInven.allRoads[i][0].mapColor = Color.white;
                    //删掉第一个
                    mapInven.allRoads[i].RemoveAt(0);
                }
                else
                {
                    //如果剩下一个了 就是路线的最后一个就是送达了 第一次送达 把送达物资给到那个格子 然后在下面判断
                    if (mapInven.allRoads[i].Count == 1)
                    {
                        SettleWindow.Instance.settleText.text +=
                            string.Format("你的{0}送达了\n", mapInven.allRoads[i][0].transportItem.itemName);
                        mapInven.allRoads[i][0].arriveItem = mapInven.allRoads[i][0].transportItem;
                        mapInven.allRoads[i][0].isArrive = true;
                        continue;
                    }

                    //把第一个的信息给设置好
                    mapInven.allRoads[i][0].itemNum = 0;
                    mapInven.allRoads[i][0].transportItem = null;
                    mapInven.allRoads[i][0].mapColor = Color.white;
                    //删掉第一个
                    mapInven.allRoads[i].RemoveAt(0);
                }
            }


            //贸易路线判断委托是否完成功能
            //在plays<=接受委托那天的playdays+期限时都判断一次 格子的arriveItem是否等于接受的物资

            //接受的总委托是一个列表 遍历列表 参数是一个类 那个类的值有
            //int 接受任务时的天数 int 期限 item 物资 float 奖励财富（与物资的价格及数量有关）
            //float 奖励信用 float 定金
            //int 物资数量 大于等于才有奖励 但是没有额外奖励 小于就等于失败 少一个都失败
            //一个scriptableObj就出来了！
            //接受委托列表可以加入在business内
            //任务栏也存在一个scriptobj怎么生成任务呢？？
            for (int i = 0; i < Business.Instance.tradeDele.Count; i++)
            {
                if (Business.Instance.playDays <=
                    Business.Instance.tradeDele[i].playdays + Business.Instance.tradeDele[i].deadline)
                {
                    //在期限内每天都判断一次
                    if (Business.Instance.tradeDele[i].address.arriveItem == Business.Instance.tradeDele[i].reqItem
                        && Business.Instance.tradeDele[i].address.itemNum >= Business.Instance.tradeDele[i].itemNum)
                    {
                        Business.Instance.tradeDele[i].boss.intimacy += 1;
                        Business.Instance.wealth += Business.Instance.tradeDele[i].rewardWealth;
                        //信用奖励 10% 几率信用+1
                        int random = Random.Range(0, 10) == 1 ? 1 : 0;
                        Business.Instance.credit += random;
                        SettleWindow.Instance.settleText.text += string.Format("今天完成了送达{0}的任务,奖励{1}财富值,信用值增长{2}\n",
                            Business.Instance.tradeDele[i].reqItem.itemName, (int)Business.Instance.tradeDele[i].rewardWealth,
                            random);
                        //这就算送达成功了
                        Business.Instance.tradeDele.Remove(Business.Instance.tradeDele[i]);
                        //获得奖励
                        //财富奖励
                        //委托人亲密度上升1
                        Business.Instance.tradeSuccessfulNum++;
                    }
                    else
                    {
                        //其他情况都算送达不成功 等到期限结束就算任务失败
                    }
                }
                else
                {
                    //任务失败
                    //扣除双倍定金
                    Business.Instance.wealth -= Business.Instance.tradeDele[i].Deposit * 3;
                    Business.Instance.credit -= 2;
                    SettleWindow.Instance.settleText.text += string.Format("今天配送{0}的任务失败了,扣除{1}财富值,信用值减少2\n",
                        Business.Instance.tradeDele[i].reqItem.itemName, (int)Business.Instance.tradeDele[i].Deposit * 3);
                    //如果到期限了
                    Business.Instance.tradeDele.Remove(Business.Instance.tradeDele[i]);
                    //委托人亲密度下降
                    Business.Instance.tradeDele[i].boss.intimacy -= 1;
                }
            }

            //娶亲每日送礼刷新
            for (int i = 0; i < marriers.Length; i++)
            {
                marriers[i].isGift = false;
            }

            //会客厅特殊设施
            if (BuildingsManager.Instance.JudgeDay())
            {
                if (BuildingsManager.Instance.buildingType == 1)
                    SettleWindow.Instance.settleText.text += string.Format("孤儿院期限已到，扣除了{0}财富值，转换为了{1}信用值\n",
                        (int)BuildingsManager.Instance.defuctWealth, BuildingsManager.Instance.increaseCredit);
                else
                    SettleWindow.Instance.settleText.text += string.Format("死士营期限已到，扣除了{0}信用值，转换为了{1}财富值\n",
                        (int)BuildingsManager.Instance.defuctCredit, BuildingsManager.Instance.increaseWealth);
            }


            //TODO 加载睡觉动画
            //TODO 跳转回主场景

            //TODO 加载每日结算界面
            SettleWindow.Instance.Refresh();

            SettleWindow.Instance.SetVisible(true);


            mainW.Refresh();
        

        //private void LoadData(PointerEventData eventData)
        //{
        //    GameSaveManger.Instance.LoadAllSaveData();
        //}
        //倒闭方法
    }
    
    
    public void Bankruptcy(Shops shop)
    {
        Business.Instance.shops.Remove(shop);
        shop.totalPassengerFlow = 0;
        shop.famous = 1;
        Business.Instance.credit -= 2;
        //BankruptcyWindow.Instance.Refresh();
    }

    public void SaveData(PointerEventData eventData)
    {
        mainW.Refresh();
        //以后存档要存什么数据在这里加 什么商铺的
        //现在只存business对象
        //GameSaveManger.Instance.SaveAllData();
        saveW.SetVisible(true);
        saveW.IsSave = true;
        //TODO 在按出存档窗口的时候应该把存档数据同步一下
    }
}