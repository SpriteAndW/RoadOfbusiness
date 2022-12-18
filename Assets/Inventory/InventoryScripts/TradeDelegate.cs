using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tool;

[CreateAssetMenu(fileName = "TradeDelegate", menuName = "TradeDelegate/delegate")]
public class TradeDelegate : ScriptableObject
{
    //贸易路线判断委托是否完成功能
    //在plays<=接受委托那天的playdays+期限时都判断一次 判断gridInfo格子的arriveItem是否等于接受的物资

    //接受的总委托是一个列表 遍历列表 参数是一个类 那个类的值有
    //int 接受任务时的天数 int 期限 item 物资 float 奖励财富（与物资的价格及数量有关）
    //float 奖励信用 float 定金 GridInfo 地点
    //int 物资数量 大于等于才有奖励 但是没有额外奖励 小于就等于失败 少一个都失败
    //一个scriptableObj就出来了！
    //接受委托列表可以加入在business内
    //任务栏也存在一个scriptobj怎么生成任务呢？？

    public int playdays;
    public int deadline;
    public Item reqItem;
    public MapGridInfo address;
    public float rewardWealth;
    public float rewardCredit;
    //定金
    public float Deposit;
    public int itemNum;
    //这个任务是否被接受
    //委托人
    public BusinessItem boss;
    public bool isAccept;
    //是否是特殊贸易路线
    public bool isSpecial;
    public virtual void GenerateRandomDelegate()
    {
        //开始日期等于当前日期
        playdays = Business.Instance.playDays;
        //期限等于随机3-6天
        deadline = Random.Range(3, 7);
        reqItem = GameSaveManger.Instance.itemList[Random.Range(0, GameSaveManger.Instance.itemList.Length)];
        address = GameSaveManger.Instance.gridInfo[Random.Range(0, GameSaveManger.Instance.gridInfo.Length)];
        itemNum = 100 * Random.Range(5, 11);
        //价格直接翻倍
        rewardWealth = itemNum * reqItem.price * 2;
        //定金是总金额的20%
        Deposit = rewardWealth * 0.2f;
        //奖励信用
        boss = address.inTradeItem[Random.Range(0, 3)];

    }

}
