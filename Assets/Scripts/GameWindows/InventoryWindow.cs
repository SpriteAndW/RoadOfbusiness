using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tool;

public class InventoryWindow : UIFunctionWindow
{
    //这是窗口的对象
    public static InventoryWindow Instance;
    //这是背包 里面有一个列表
    public Inventory myBag;
    //那个物品栏的表格
    public Transform slotGrid;
    //物品栏预制件
    public Slot slotPrefab;
    //物品描述信息
    public Text itemInfo;
    protected override void Start()
    {
        base.Start();
        Instance = this;
        slotGrid = transform.GetchildByname("Grid");
        slotPrefab = ResourcesManger.Load<Slot>("Slot");
        //itemInfo = transform.GetchildByname("Description").GetComponent<Text>();
    }
    
    public static void CreateNewItem(Item item)
    {
        //先创建一个预制件 他是没有任何东西的 单纯的设置那个格子为父物体
        Slot newItem = Instantiate(Instance.slotPrefab, Instance.slotGrid);
        //把item的信息传到物品的item信息内
        newItem.slotItem = item;
        //把图片也置换
        newItem.itemSprite.sprite = item.itemImg;
        //把持有度也置换
        newItem.slotNum.text = item.itemHeld.ToString();
    }
    
    public static void Refresh()
    {
        for (int i = 0; i < Instance.slotGrid.childCount; i++)
        {
            //把格子下的子物体全部删掉
            Destroy(Instance.slotGrid.GetChild(i).gameObject);
        }

        //在把背包的那个物品列表生成一下
        foreach (var item in Instance.myBag.itemList)
        {
            if(item.itemHeld != 0) CreateNewItem(item);
        }
    }

}
