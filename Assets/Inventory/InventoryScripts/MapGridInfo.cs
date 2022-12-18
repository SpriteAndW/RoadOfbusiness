using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "MapInfo", menuName = "MapInventory/MapInfo")]
public class MapGridInfo : ScriptableObject
{
    //��ʼֵ��Ϊ��ɫ
    public Color mapColor = Color.white;
    
    public int position;
    //���������
    public Item transportItem;
    //�������ʵ�����   
    public int itemNum;

    //���䵽�������
    public Item arriveItem;

    public bool isArrive = false;

    //�صļ۸�
    public float price;
    //������������ ÿ���غ�����һ��
    public Item product;

    //�ص�����
    public string mapName;

    //�õصĶ���ó�ײ�Ʒ
    public List<BusinessItem> inTradeItem = new List<BusinessItem>(3);

    //��ͼͼƬ
    public Sprite mapimg;
}
