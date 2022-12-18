using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tool;

public class InventoryWindow : UIFunctionWindow
{
    //���Ǵ��ڵĶ���
    public static InventoryWindow Instance;
    //���Ǳ��� ������һ���б�
    public Inventory myBag;
    //�Ǹ���Ʒ���ı��
    public Transform slotGrid;
    //��Ʒ��Ԥ�Ƽ�
    public Slot slotPrefab;
    //��Ʒ������Ϣ
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
        //�ȴ���һ��Ԥ�Ƽ� ����û���κζ����� �����������Ǹ�����Ϊ������
        Slot newItem = Instantiate(Instance.slotPrefab, Instance.slotGrid);
        //��item����Ϣ������Ʒ��item��Ϣ��
        newItem.slotItem = item;
        //��ͼƬҲ�û�
        newItem.itemSprite.sprite = item.itemImg;
        //�ѳ��ж�Ҳ�û�
        newItem.slotNum.text = item.itemHeld.ToString();
    }
    
    public static void Refresh()
    {
        for (int i = 0; i < Instance.slotGrid.childCount; i++)
        {
            //�Ѹ����µ�������ȫ��ɾ��
            Destroy(Instance.slotGrid.GetChild(i).gameObject);
        }

        //�ڰѱ������Ǹ���Ʒ�б�����һ��
        foreach (var item in Instance.myBag.itemList)
        {
            if(item.itemHeld != 0) CreateNewItem(item);
        }
    }

}
