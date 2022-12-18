using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/New Item")]
public class Item : ScriptableObject
{
    //物品名字
    public string itemName;
    //物品图像精灵
    [SerializeField]
    public Sprite itemImg;
    //持有数量
    public int itemHeld;
    //商店可购买数量
    public int itemRemainder;
    //售价
    public float price;
    //保质期
    public float basePrice;
    public int QGP;

    //基础保质期
    public int BaseQGP;
    //物品描述
    [TextArea]
    public string itemInfo;

    public void AddItemHeld(int num)
    {
        //保质期百分比公式
        QGP = (itemHeld / (itemHeld + num)) * QGP + (num / (itemHeld + num)) * BaseQGP;
        itemHeld += num;
    }
    
}
