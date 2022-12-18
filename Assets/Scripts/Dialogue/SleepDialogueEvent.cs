using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Tool;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 加到睡觉动画
/// </summary>
public class SleepDialogueEvent : MonoSingleton<SleepDialogueEvent>
{
    [Header("贸易路线相关")] public TradeDelegateBar tradeDelegateBar;
    public SpecialTrade specialTrade;

    private bool isFirst1001;
    private bool isFirst20012;
    private bool isFirst20041;
    private bool isFirst20042;
    private bool isFirst20051;
    private bool isFirst20052;
    private bool isFirst20071;
    private bool isFirst20081;
    private bool isFirst20082;
    private bool isFirst20152;
    private bool isFirst20262;
    private bool isFirst20282;


    //睡觉最后哦一帧加入该事件
    public void DialogueEvent()
    {
        //支线
        BranchPlot();
        //支线选择
        // ChoosePlotDone();

        //主线
        MainPlot();


        GameController.Instance.Refresh();
    }


    //public IEnumerator MainJudge()
    //{
    //    while (MainPlot())
    //    {
    //        yield return new WaitWhile(() => DialogueUI.Instance.transform.GetChild(0) == false &&
    //                DialogueUI.Instance.transform.GetChild(1) == false &&
    //                DialogueUI.Instance.transform.GetChild(2) == false);
    //    }

    //}

    /// <summary>
    /// 主线剧情根据时间回合数量触发
    /// </summary>
    private void MainPlot()
    {
        if (Business.Instance.playDays == 5)
        {
            DialogueManager.instance.ShowDialogueOnDayID(1002);
        }

        if (Business.Instance.playDays == 15)
        {
            DialogueManager.instance.ShowDialogueOnDayID(1003);
        }

        if (Business.Instance.playDays == 20)
        {
            DialogueManager.instance.ShowDialogueOnDayID(1004);
        }

        //时间大于51天时
        if (Business.Instance.playDays == 25)
        {
            //触发过1004.2（开粮店被吴老板坑了）
            if (DialogueManager.instance.MainDoneDialogue.Contains(
                    DialogueManager.instance.dialogueData.GetDialogueDetail(1004.2f)))
            {
                DialogueManager.instance.ShowDialogueOnDayID(1005);
            }
            else
            {
                DialogueManager.instance.ShowDialogueOnDayID(2029);
            }
        }

        if (Business.Instance.playDays == 30)
        {
            DialogueManager.instance.ShowDialogueOnDayID(1006);
        }

        if (Business.Instance.playDays == 35)
        {
            DialogueManager.instance.ShowDialogueOnDayID(1007);
        }

        if (Business.Instance.playDays >= 50)
        {
            DialogueManager.instance.ShowDialogueOnDayID(1008);
        }
    }


    /// <summary>
    /// 支线剧情根据条件触发
    /// </summary>
    private void BranchPlot()
    {
        if (Business.Instance.playDays <= 10)
        {
            return;
        }

        //使用过期食品次数超过2次
        if (Business.Instance.outdateFoodNum > 2)
        {
            DialogueManager.instance.ShowDialogueOnDayID(2001);
        }

        //交易所交易10次
        if (Business.Instance.transactionNum > 10)
        {
            if (Business.Instance.credit > 60)
            {
                DialogueManager.instance.ShowDialogueOnDayID(2002);
            }

            //交易所交易20次
            if (Business.Instance.transactionNum > 20)
            {
                if (Business.Instance.credit > 50 && Business.Instance.wealth > 500000)
                {
                    DialogueManager.instance.ShowDialogueOnDayID(2003);
                }
            }
        }


        //钱庄第一次还不起钱
        if (Business.Instance.borrowMoneyCantNum > 0)
        {
            DialogueManager.instance.ShowDialogueOnDayID(2004);

            //钱庄第二次还不起钱
            if (Business.Instance.borrowMoneyCantNum > 1)
            {
                DialogueManager.instance.ShowDialogueOnDayID(2005);
            }
        }


        //娶公主任务,古大人的试炼1
        if (CanShowDialogue(80, 600000, 2))
            // if (Business.Instance.credit > 80 && Business.Instance.wealth > 5000000) //还有个秋天条件,后续加或不加
        {
            DialogueManager.instance.ShowDialogueOnDayID(2006);

            //娶公主任务,古大人的试炼2
            if (CanShowDialogue(90, 8000000, 2) && Business.Instance.wealth > 8000000 && BranchPlotIsDone(2006.5f))
                // if (Business.Instance.credit > 90 && Business.Instance.wealth > 8000000 && BranchPlotIsDone(2006.5f))
            {
                DialogueManager.instance.ShowDialogueOnDayID(2007);
            }
        }


        //有十家店铺以上
        if (Business.Instance.shops.Count > 10)
        {
            DialogueManager.instance.ShowDialogueOnDayID(2008);
        }

        //店铺满足升级条件
        // if (Business.Instance.shops) 
        // {
        //     DialogueManager.instance.ShowDialogueOnDayID(2009);
        // }

        //存钱超过五次
        if (CanShowDialogue(60, 800000, 3) && Business.Instance.saveMoneyNum > 5)
        {
            DialogueManager.instance.ShowDialogueOnDayID(2010);
        }


        //（货物在仓库中被流氓霸占，索取保护费）
        if (CanShowDialogue(40, 1000000))
        {
            DialogueManager.instance.ShowDialogueOnDayID(2011);
        }

        //交易所完成五十笔交易 2012
        if (CanShowDialogue(50, 600000) && Business.Instance.transactionNum > 50)
        {
            DialogueManager.instance.ShowDialogueOnDayID(2012);
        }

        //（有人说自己弄到一批非常便宜的货（是真的，但保质期很短）2013
        if (CanShowDialogue(60, 800000, 0))
        {
            DialogueManager.instance.ShowDialogueOnDayID(2013);
        }

        //2014	80	1000000	秋天	-1	1	买下10块资源产地
        if (CanShowDialogue(80, 1000000, 2) && Business.Instance.myLand.Count >= 10)
        {
            DialogueManager.instance.ShowDialogueOnDayID(2014);
        }

        //2015	80	1000000	-1	-1	1	手里拥有五条长期贸易路线
        if (CanShowDialogue(80, 1000000) && Business.Instance.tradeSuccessfulNum > 4) //拥有五条长期贸易路线  改成  贸易路线成功5次以上
        {
            DialogueManager.instance.ShowDialogueOnDayID(2015);
        }

        //2016	60	800000	-1	-1	1	累计完成过三十次贸易委托
        if (CanShowDialogue(60, 800000))
        {
            DialogueManager.instance.ShowDialogueOnDayID(2016);
        }

        //2017	-1	500000	-1	1	-1	（2016——后续任务）
        if (CanShowDialogue(0, 600000) && BranchPlotIsDone(2016.1f))
        {
            DialogueManager.instance.ShowDialogueOnDayID(2017);
        }

        //2018	50	100000	春天	-1	-1	寒食节剧情
        if (CanShowDialogue(50, 600000, 0))
        {
            DialogueManager.instance.ShowDialogueOnDayID(2018);
        }

        //2019	50	100000	冬天	-1	-1	春节
        if (CanShowDialogue(50, 600000, 3))
        {
            DialogueManager.instance.ShowDialogueOnDayID(2019);
        }

        //2020	50	100000	秋天	-1	-1	中秋节
        if (CanShowDialogue(50, 600000, 2))
        {
            DialogueManager.instance.ShowDialogueOnDayID(2020);
        }

        //2021	50	100000	夏天	-1	-1	端午节
        if (CanShowDialogue(50, 600000, 2))
        {
            DialogueManager.instance.ShowDialogueOnDayID(2021);
        }

        //2022	50	100000	春天			元宵节（春节之后）
        if (CanShowDialogue(50, 600000, 0))
        {
            DialogueManager.instance.ShowDialogueOnDayID(2022);
        }

        //2023	60	400000	夏天			七夕节
        if (CanShowDialogue(60, 600000, 1))
        {
            DialogueManager.instance.ShowDialogueOnDayID(2023);
        }

        //2024	50	400000	秋天	-1	-1	重阳节
        if (CanShowDialogue(50, 600000, 2))
        {
            DialogueManager.instance.ShowDialogueOnDayID(2024);
        }

        //2025	70	300000	春天	-1	1	和福老板亲密度90以上
        if (CanShowDialogue(70, 600000, 0) && GameSaveManger.Instance.allboss[4].intimacy > 90)
        {
            DialogueManager.instance.ShowDialogueOnDayID(2025);
        }

        //2026	40	2000000	-1	1	-1	2023-后续事件
        if (CanShowDialogue(40, 2000000) && BranchPlotIsDone(2023.2f))
        {
            DialogueManager.instance.ShowDialogueOnDayID(2026);
        }

        //2027	-1	200000	-1	-1	1	开了一家以上绸缎铺
        if (CanShowDialogue(0, 600000) && GameSaveManger.Instance.shopList.Length > 1)
        {
            DialogueManager.instance.ShowDialogueOnDayID(2027);
        }

        //2028	80	5000000	-1	1	-1	2025后续事件
        if (CanShowDialogue(60, 600000) && BranchPlotIsDone(2025.1f))
        {
            DialogueManager.instance.ShowDialogueOnDayID(2028);
        }

        //2030	-1	20000000	-1	-1	-1	开仓放粮
        if (CanShowDialogue(0, 20000000))
        {
            DialogueManager.instance.ShowDialogueOnDayID(2030);
        }

        //2031	60	500000	-1	-1	-1	借钱不还
        if (CanShowDialogue(60, 600000))
        {
            DialogueManager.instance.ShowDialogueOnDayID(2031);
        }
    }


    /// <summary>
    /// 支线选择
    /// </summary>
    public void ChoosePlotDone()
    {
        if (MainPlotIsDone(1001) && !isFirst1001)
        {
            isFirst1001 = true;
            Business.Instance.shops.Add(SetActionSaver.Instance.shops[5]);
            // InventoryWindow.Instance.myBag.itemList.Add();
            foreach (var item in InventoryWindow.Instance.myBag.itemList)
            {
                item.AddItemHeld(500);
            }
        }

        if (MainPlotIsDone(1008.2f))
        {
            DialogueManager.instance.ShowDialogueOnDayID(1008.3f);
        }

        if (MainPlotIsDone(1008.1f) || MainPlotIsDone(1008.5f) || MainPlotIsDone(1008.7f))
        {
            //TODO:游戏Demo到此结束
            EventHandler.CallShowGameOver();
        }

        //2001.2 坦白从宽,后倒闭饭店
        if (BranchPlotIsDone(2001.2f) && !isFirst20012)
        {
            isFirst20012 = true;

            for (int i = 0; i < Business.Instance.outQGPShops.Count; i++)
            {
                MenuWindow.Instance.Bankruptcy(Business.Instance.outQGPShops[i]);
            }

            Business.Instance.outQGPShops.Clear();
        }

        // //2003.1 交易所大佬 给货物
        // if (BranchPlotIsDone(2003.1f) && !isFirst20031)
        // {
        //     isFirst20031 = true;
        //
        //     //已在SO文件里添加
        // }

        //2004.1欠钱不换第一次     扣钱并关闭两家店铺
        if (BranchPlotIsDone(2004.1f) && !isFirst20041)
        {
            isFirst20041 = true;
            if (Business.Instance.shops.Count == 0)
            {
                return;
            }

            if (Business.Instance.shops.Count >= 2)
            {
                for (int i = 0; i < 2; i++)
                {
                    MenuWindow.Instance.Bankruptcy(Business.Instance.shops[i]);
                }
            }
            else
            {
                foreach (var item in Business.Instance.shops)
                {
                    MenuWindow.Instance.Bankruptcy(item);
                }
            }
        }

        //2004.2欠钱不还第一次  减利息
        if (BranchPlotIsDone(2004.2f) && !isFirst20042)
        {
            isFirst20042 = true;
            //利息减免20%
            BankManager.Instance.interestRate = 0.8f;
        }

        //2005.1 欠钱不还第二次 卖店铺
        if (BranchPlotIsDone(2005.1f) && !isFirst20051)
        {
            isFirst20051 = true;
            foreach (var item in Business.Instance.shops)
            {
                MenuWindow.Instance.Bankruptcy(item);
            }
        }

        //2005.2 欠钱不还第二次 卖货物
        if (BranchPlotIsDone(2005.2f) && !isFirst20052)
        {
            isFirst20052 = true;
            foreach (var item in GameSaveManger.Instance.itemList)
            {
                item.itemHeld = 0;
            }
        }

        //2007.1 古大人的试炼通过，获得迎娶公主资格
        if (BranchPlotIsDone(2007.1f) && !isFirst20071)
        {
            isFirst20071 = true;
            //TODO:获得迎娶公主资格（在busine中添加个bool值）
            MenuWindow.Instance.marriers[1].intimacy += 60;
        }

        //2008.1 珠光宝气 拒绝苏先生，被杭州商会看重
        if (BranchPlotIsDone(2008.1f) && !isFirst20081)
        {
            isFirst20081 = true;

            tradeDelegateBar.delegateBar.Add(specialTrade);

            // var bar = AssetDatabase.LoadAssetAtPath<TradeDelegateBar>(
            //     "Assets/Inventory/TradeDelegate/TradeDelegateBar.asset");
            // bar.delegateBar.Add(
            //     AssetDatabase.LoadAssetAtPath<SpecialTrade>("Assets/Inventory/TradeDelegate/SpecialTradeDele.asset"));
        }

        //2008.1 珠光宝气 答应苏先生，扣钱后,获得专属贸易路线,每回合获得钱庄的20000利息
        if (BranchPlotIsDone(2008.2f) && !isFirst20082)
        {
            isFirst20082 = true;

            tradeDelegateBar.delegateBar.Add(specialTrade);

            // var bar = AssetDatabase.LoadAssetAtPath<TradeDelegateBar>(
            //     "Assets/Inventory/TradeDelegate/TradeDelegateBar.asset");
            // bar.delegateBar.Add(
            //     AssetDatabase.LoadAssetAtPath<SpecialTrade>("Assets/Inventory/TradeDelegate/SpecialTradeDele.asset"));
            //投资钱庄,每回合获得利息
            Business.Instance.isInvest = true;
        }

        if (BranchPlotIsDone(2015.2f) && !isFirst20152)
        {
            isFirst20152 = true;
            //添加特殊贸易路线
            tradeDelegateBar.delegateBar.Add(specialTrade);

            // var bar = AssetDatabase.LoadAssetAtPath<TradeDelegateBar>(
            //     "Assets/Inventory/TradeDelegate/TradeDelegateBar.asset");
            // bar.delegateBar.Add(
            //     AssetDatabase.LoadAssetAtPath<SpecialTrade>("Assets/Inventory/TradeDelegate/SpecialTradeDele.asset"));
        }

        //2026.2 七夕节后续事件 答应岗绿倚 获得迎娶岗绿倚资格 
        if (BranchPlotIsDone(2026.2f) && !isFirst20262)
        {
            isFirst20262 = true;
            //TODO:获得迎娶岗绿倚资格
            MenuWindow.Instance.marriers[8].intimacy += 60;
        }

        //2028.2 福老板后续任务 取悦福老板妹妹，获得迎娶她妹资格  福缕云
        if (BranchPlotIsDone(2028.2f) && !isFirst20282)
        {
            isFirst20282 = true;
            //TODO:获得福缕云绿倚资格
            MenuWindow.Instance.marriers[3].intimacy += 60;
        }
    }

    /// <summary>
    /// 判断支线剧情是否触发
    /// </summary>
    /// <returns>布尔值</returns>
    private bool BranchPlotIsDone(float dialogueID)
    {
        if (DialogueManager.instance.BranchDoneDialogue.Contains(
                DialogueManager.instance.dialogueData.GetDialogueDetail(dialogueID)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 判断主线剧情是否触发
    /// </summary>
    /// <param name="dialogueID"></param>
    /// <returns></returns>
    public bool MainPlotIsDone(float dialogueID)
    {
        if (DialogueManager.instance.MainDoneDialogue.Contains(
                DialogueManager.instance.dialogueData.GetDialogueDetail(dialogueID)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    /// <summary>
    /// 判断触发剧情对话是否满足需求
    /// (0123分别代表春夏秋冬)
    /// </summary>
    /// <param name="credit">信用需求</param>
    /// <param name="wealth">财富需求</param>
    /// <param name="seasonIndex(0123分别代表春夏秋冬)">季节需求</param>
    /// <returns></returns>
    private bool CanShowDialogue(float credit, float wealth, int seasonIndex = -1)
    {
        if (Business.Instance.credit > credit && Business.Instance.wealth > wealth)
        {
            if (seasonIndex != -1)
            {
                if (Business.Instance.playDays % 360 / 90 == seasonIndex)
                {
                    return true;
                }

                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }
    }
}