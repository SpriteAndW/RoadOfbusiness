using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Marrier", menuName = "Boss/Daughter")]
public class Marrier : ScriptableObject
{
    //提示
    [TextArea]
    public string[] Info;

    //样貌 
    public Sprite face;

    //父亲
    public BusinessItem father;

    //喜欢的物品
    public List<Item> favoItem;

    //讨厌的物品
    public List<Item> hateItem;

    //亲密度
    public float intimacy;

    public string mName;

    //今天是否送过礼物了
    public bool isGift;
    private void OnEnable()
    {
        Info = new string[] {
            "她的父亲好像叫" + father.bossName,
            "她的父亲好像是" + father.tradeItem.itemName + "的供货商",
            "她好像喜欢" + favoItem[0].itemName,
            "她好像喜欢" + favoItem[1].itemName,
            "她好像喜欢" + favoItem[2].itemName,
            "她好像讨厌" + hateItem[0].itemName,
            "她好像讨厌" + hateItem[1].itemName,
            "她好像讨厌" + hateItem[2].itemName,
            "她的名字好像叫" + mName
        };
        //Info = new string[] {
        //    "aaa", "aaa"
        //};
    }
}
