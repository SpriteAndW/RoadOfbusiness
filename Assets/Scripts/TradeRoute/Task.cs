using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    public Text description;
    public TradeDelegate dele;
    public void UpdateDescription()
    {
        description.text = string.Format("在第{0}回合第{1}天前将{5}个{2}送往{3}地点,如果失败将要赔付{4}财富并扣取2信用值", (dele.playdays + dele.deadline) % 90 / 10, (dele.playdays + dele.deadline) % 10, dele.reqItem.itemName, dele.address.mapName, dele.Deposit * 3, dele.itemNum);
    }
}