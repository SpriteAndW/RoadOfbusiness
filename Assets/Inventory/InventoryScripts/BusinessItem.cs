using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boss", menuName = "Boss/Boss")]
public class BusinessItem : ScriptableObject
{
    //该老板交易的物品
    public Item tradeItem;

    //老板名字
    public string bossName;

    //亲密度
    public float intimacy;

    //老板描述
    [TextArea]
    public string description;

    //是否接受过
    public bool isRec;
}
