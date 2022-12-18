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
        description.text = string.Format("�ڵ�{0}�غϵ�{1}��ǰ��{5}��{2}����{3}�ص�,���ʧ�ܽ�Ҫ�⸶{4}�Ƹ�����ȡ2����ֵ", (dele.playdays + dele.deadline) % 90 / 10, (dele.playdays + dele.deadline) % 10, dele.reqItem.itemName, dele.address.mapName, dele.Deposit * 3, dele.itemNum);
    }
}