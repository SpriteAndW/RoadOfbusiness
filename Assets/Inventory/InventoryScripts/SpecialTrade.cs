using System.Collections;
using System.Collections.Generic;
using Tool;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "SpecialDete", menuName = "TradeDelegate/SpecialDelegate")]
public class SpecialTrade : TradeDelegate
{

    public override void GenerateRandomDelegate()
    {
        isSpecial = true;
        //开始日期等于当前日期
        playdays = Business.Instance.playDays;
        //期限等于随机3-6天
        deadline = 5;
        reqItem = GameSaveManger.Instance.itemList[Random.Range(0, GameSaveManger.Instance.itemList.Length)];
        address = GameSaveManger.Instance.gridInfo[Random.Range(0, GameSaveManger.Instance.gridInfo.Length)];
        itemNum = 100 * Random.Range(10, 21);
        //价格直接翻倍
        rewardWealth = itemNum * reqItem.price * 5;
        //定金是总金额的20%
        Deposit = rewardWealth * 0.2f;
        //奖励信用
        boss = address.inTradeItem[Random.Range(0, 3)];
    }
}
