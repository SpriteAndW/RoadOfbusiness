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
        //��ʼ���ڵ��ڵ�ǰ����
        playdays = Business.Instance.playDays;
        //���޵������3-6��
        deadline = 5;
        reqItem = GameSaveManger.Instance.itemList[Random.Range(0, GameSaveManger.Instance.itemList.Length)];
        address = GameSaveManger.Instance.gridInfo[Random.Range(0, GameSaveManger.Instance.gridInfo.Length)];
        itemNum = 100 * Random.Range(10, 21);
        //�۸�ֱ�ӷ���
        rewardWealth = itemNum * reqItem.price * 5;
        //�������ܽ���20%
        Deposit = rewardWealth * 0.2f;
        //��������
        boss = address.inTradeItem[Random.Range(0, 3)];
    }
}
