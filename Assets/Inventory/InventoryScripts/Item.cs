using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/New Item")]
public class Item : ScriptableObject
{
    //��Ʒ����
    public string itemName;
    //��Ʒͼ����
    [SerializeField]
    public Sprite itemImg;
    //��������
    public int itemHeld;
    //�̵�ɹ�������
    public int itemRemainder;
    //�ۼ�
    public float price;
    //������
    public float basePrice;
    public int QGP;

    //����������
    public int BaseQGP;
    //��Ʒ����
    [TextArea]
    public string itemInfo;

    public void AddItemHeld(int num)
    {
        //�����ڰٷֱȹ�ʽ
        QGP = (itemHeld / (itemHeld + num)) * QGP + (num / (itemHeld + num)) * BaseQGP;
        itemHeld += num;
    }
    
}
