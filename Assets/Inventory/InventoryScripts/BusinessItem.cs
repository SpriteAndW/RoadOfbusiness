using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boss", menuName = "Boss/Boss")]
public class BusinessItem : ScriptableObject
{
    //���ϰ彻�׵���Ʒ
    public Item tradeItem;

    //�ϰ�����
    public string bossName;

    //���ܶ�
    public float intimacy;

    //�ϰ�����
    [TextArea]
    public string description;

    //�Ƿ���ܹ�
    public bool isRec;
}
