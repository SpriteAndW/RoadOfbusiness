using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "MapInfo", menuName = "MapInventory/MapInfo")]
public class MapGridInfo : ScriptableObject
{
    //初始值设为白色
    public Color mapColor = Color.white;
    
    public int position;
    //运输的物资
    public Item transportItem;
    //运输物资的数量   
    public int itemNum;

    //运输到达的物资
    public Item arriveItem;

    public bool isArrive = false;

    //地的价格
    public float price;
    //地生产的物资 每个回合生产一次
    public Item product;

    //地的名字
    public string mapName;

    //该地的对内贸易产品
    public List<BusinessItem> inTradeItem = new List<BusinessItem>(3);

    //地图图片
    public Sprite mapimg;
}
