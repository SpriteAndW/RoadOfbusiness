using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Shop", menuName = "Shop / New Shop")]
public class Shops : ScriptableObject
{
    public Inventory myBag;
    //店铺名字
    public string shopName;
    //开店价格 在开店时候扣取
    public float openShopPrice;

    //开店一个回合需要的物资 在开店的时候以及每回合初扣取 每个店最多选两个物品扣取
    public Item[] deductionItem;

    //消耗物资数量
    public int[] costItemNum;

    //客流量 春夏秋冬每个季度每个店铺的客流量不同
    public float passengerFlow;

    //回合利润 计算公式为item的单价 * 1.1 * passengerFlow / 1000 
    //即一回合客流量达到1000时可以小赚10%的利润 客流量不足1000可能会亏损
    public float profit;

    //工资 前面没钱时可以打工 每个店铺整体打工工资差不多 也看客流量 而且职业会被记录
    public float salary;

    //闻名等级 0默默无闻 1远近闻名 
    public float famous = 1;
    public Sprite shopImg;

    public float totalPassengerFlow;


    /// <summary>
    /// 消耗物资方法 每回合初调用 playdays % 10 == 1;
    /// </summary>
    public void CostMaterial()
    {
        //扣除开店金额
        Business.Instance.wealth -= openShopPrice;
        //扣除物资
        for (int i = 0; i < deductionItem.Length; i++)
        {
            deductionItem[i].itemHeld -= costItemNum[i];
        }
    }

    /// <summary>
    /// 赚钱方法 每日调用 sleep
    /// </summary>
    public void EarnWealth()
    {
        profit += openShopPrice * 0.12f * passengerFlow / 1000;
        for (int i = 0; i < deductionItem.Length; i++)
        {
            profit +=
                deductionItem[i].price * costItemNum[i] * 0.12f * passengerFlow / 1000;
            totalPassengerFlow += passengerFlow;
        }
        Business.Instance.wealth += profit;
        SettleWindow.Instance.settleText.text += string.Format("今天你的{0}店铺客流量为{1}，收益{2}财富值\n", shopName, (int)passengerFlow, (int)profit);
        profit = 0;
        //判断总客流量到多少 看下名声等级是否提高
        if (totalPassengerFlow > 100000 && totalPassengerFlow < 1000000) famous = 1.25f;
        if (totalPassengerFlow >= 1000000 && totalPassengerFlow < 3000000) famous = 1.5f;
        if (totalPassengerFlow >= 3000000) famous = 2f;


    }

    public void CalculatePassengerFlow()
    {
        string season = MainWindow.Instance.season;
        switch (shopName)
        {
            case "驿站":
                if (season == "春") passengerFlow = 1500;
                else if (season == "夏") passengerFlow = 1200;
                else if (season == "秋") passengerFlow = 1200;
                else if (season == "冬") passengerFlow = 1800;
                break;

            case "酒庄":
                if (season == "春") passengerFlow = 2000;
                else if (season == "夏") passengerFlow = 1500;
                
                else if (season == "秋") passengerFlow = 2200;
                else if (season == "冬") passengerFlow = 3000;
                break;

            case "饭店":
                if (season == "春") passengerFlow = 1200;
                else if (season == "夏") passengerFlow = 1500;
                else if (season == "秋") passengerFlow = 1500;
                else if (season == "冬") passengerFlow = 1200;
                break;
            case "粮庄":
                if (season == "春") passengerFlow = 1200;
                else if (season == "夏") passengerFlow = 1200;
                else if (season == "秋") passengerFlow = 1400;
                else if (season == "冬") passengerFlow = 1000;
                break;

            case "古玩店":
                if (season == "春") passengerFlow = 1000;
                else if (season == "夏") passengerFlow = 1000;
                else if (season == "秋") passengerFlow = 1000;
                else if (season == "冬") passengerFlow = 1000;
                break;

            case "布庄":
                if (season == "春") passengerFlow = 1200;
                else if (season == "夏") passengerFlow = 1200;
                else if (season == "秋") passengerFlow = 1200;
                else if (season == "冬") passengerFlow = 1500;
                break;

            default:
                passengerFlow = 0;
                break;
        }
        passengerFlow *= Random.Range(0.8f, 1.2f) * famous;
    }
    //private void Start()
    //{
    //    shopImg = GetComponent<Image>().sprite;
    //}
    public bool JudgeWealth()
    {
        for (int i = 0; i < deductionItem.Length; i++)
        {
            if (!myBag.itemList.Contains(deductionItem[i])
                || deductionItem[i].itemHeld < costItemNum[i])
            {
                return false;
            }
        }
        return true;
    }
}
