using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Marrier", menuName = "Boss/Daughter")]
public class Marrier : ScriptableObject
{
    //��ʾ
    [TextArea]
    public string[] Info;

    //��ò 
    public Sprite face;

    //����
    public BusinessItem father;

    //ϲ������Ʒ
    public List<Item> favoItem;

    //�������Ʒ
    public List<Item> hateItem;

    //���ܶ�
    public float intimacy;

    public string mName;

    //�����Ƿ��͹�������
    public bool isGift;
    private void OnEnable()
    {
        Info = new string[] {
            "���ĸ��׺����" + father.bossName,
            "���ĸ��׺�����" + father.tradeItem.itemName + "�Ĺ�����",
            "������ϲ��" + favoItem[0].itemName,
            "������ϲ��" + favoItem[1].itemName,
            "������ϲ��" + favoItem[2].itemName,
            "����������" + hateItem[0].itemName,
            "����������" + hateItem[1].itemName,
            "����������" + hateItem[2].itemName,
            "�������ֺ����" + mName
        };
        //Info = new string[] {
        //    "aaa", "aaa"
        //};
    }
}
