using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tool;

[CreateAssetMenu(fileName = "TradeDelegate", menuName = "TradeDelegate/delegate")]
public class TradeDelegate : ScriptableObject
{
    //ó��·���ж�ί���Ƿ���ɹ���
    //��plays<=����ί�������playdays+����ʱ���ж�һ�� �ж�gridInfo���ӵ�arriveItem�Ƿ���ڽ��ܵ�����

    //���ܵ���ί����һ���б� �����б� ������һ���� �Ǹ����ֵ��
    //int ��������ʱ������ int ���� item ���� float �����Ƹ��������ʵļ۸������йأ�
    //float �������� float ���� GridInfo �ص�
    //int �������� ���ڵ��ڲ��н��� ����û�ж��⽱�� С�ھ͵���ʧ�� ��һ����ʧ��
    //һ��scriptableObj�ͳ����ˣ�
    //����ί���б���Լ�����business��
    //������Ҳ����һ��scriptobj��ô���������أ���

    public int playdays;
    public int deadline;
    public Item reqItem;
    public MapGridInfo address;
    public float rewardWealth;
    public float rewardCredit;
    //����
    public float Deposit;
    public int itemNum;
    //��������Ƿ񱻽���
    //ί����
    public BusinessItem boss;
    public bool isAccept;
    //�Ƿ�������ó��·��
    public bool isSpecial;
    public virtual void GenerateRandomDelegate()
    {
        //��ʼ���ڵ��ڵ�ǰ����
        playdays = Business.Instance.playDays;
        //���޵������3-6��
        deadline = Random.Range(3, 7);
        reqItem = GameSaveManger.Instance.itemList[Random.Range(0, GameSaveManger.Instance.itemList.Length)];
        address = GameSaveManger.Instance.gridInfo[Random.Range(0, GameSaveManger.Instance.gridInfo.Length)];
        itemNum = 100 * Random.Range(5, 11);
        //�۸�ֱ�ӷ���
        rewardWealth = itemNum * reqItem.price * 2;
        //�������ܽ���20%
        Deposit = rewardWealth * 0.2f;
        //��������
        boss = address.inTradeItem[Random.Range(0, 3)];

    }

}
