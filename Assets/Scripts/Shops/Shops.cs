using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Shop", menuName = "Shop / New Shop")]
public class Shops : ScriptableObject
{
    public Inventory myBag;
    //��������
    public string shopName;
    //����۸� �ڿ���ʱ���ȡ
    public float openShopPrice;

    //����һ���غ���Ҫ������ �ڿ����ʱ���Լ�ÿ�غϳ���ȡ ÿ�������ѡ������Ʒ��ȡ
    public Item[] deductionItem;

    //������������
    public int[] costItemNum;

    //������ �����ﶬÿ������ÿ�����̵Ŀ�������ͬ
    public float passengerFlow;

    //�غ����� ���㹫ʽΪitem�ĵ��� * 1.1 * passengerFlow / 1000 
    //��һ�غϿ������ﵽ1000ʱ����С׬10%������ ����������1000���ܻ����
    public float profit;

    //���� ǰ��ûǮʱ���Դ� ÿ����������򹤹��ʲ�� Ҳ�������� ����ְҵ�ᱻ��¼
    public float salary;

    //�����ȼ� 0ĬĬ���� 1Զ������ 
    public float famous = 1;
    public Sprite shopImg;

    public float totalPassengerFlow;


    /// <summary>
    /// �������ʷ��� ÿ�غϳ����� playdays % 10 == 1;
    /// </summary>
    public void CostMaterial()
    {
        //�۳�������
        Business.Instance.wealth -= openShopPrice;
        //�۳�����
        for (int i = 0; i < deductionItem.Length; i++)
        {
            deductionItem[i].itemHeld -= costItemNum[i];
        }
    }

    /// <summary>
    /// ׬Ǯ���� ÿ�յ��� sleep
    /// </summary>
    public void EarnWealth()
    {
        profit += openShopPrice * 0.12f * passengerFlow / 1000;
        for (int i = 0; i < deductionItem.Length; i++)
        {
            profit +=
                deductionItem[i].price * costItemNum[i] * 0.12f * passengerFlow / 1000;
            totalPassengerFlow += passengerFlow;
        }
        Business.Instance.wealth += profit;
        SettleWindow.Instance.settleText.text += string.Format("�������{0}���̿�����Ϊ{1}������{2}�Ƹ�ֵ\n", shopName, (int)passengerFlow, (int)profit);
        profit = 0;
        //�ж��ܿ����������� ���������ȼ��Ƿ����
        if (totalPassengerFlow > 100000 && totalPassengerFlow < 1000000) famous = 1.25f;
        if (totalPassengerFlow >= 1000000 && totalPassengerFlow < 3000000) famous = 1.5f;
        if (totalPassengerFlow >= 3000000) famous = 2f;


    }

    public void CalculatePassengerFlow()
    {
        string season = MainWindow.Instance.season;
        switch (shopName)
        {
            case "��վ":
                if (season == "��") passengerFlow = 1500;
                else if (season == "��") passengerFlow = 1200;
                else if (season == "��") passengerFlow = 1200;
                else if (season == "��") passengerFlow = 1800;
                break;

            case "��ׯ":
                if (season == "��") passengerFlow = 2000;
                else if (season == "��") passengerFlow = 1500;
                
                else if (season == "��") passengerFlow = 2200;
                else if (season == "��") passengerFlow = 3000;
                break;

            case "����":
                if (season == "��") passengerFlow = 1200;
                else if (season == "��") passengerFlow = 1500;
                else if (season == "��") passengerFlow = 1500;
                else if (season == "��") passengerFlow = 1200;
                break;
            case "��ׯ":
                if (season == "��") passengerFlow = 1200;
                else if (season == "��") passengerFlow = 1200;
                else if (season == "��") passengerFlow = 1400;
                else if (season == "��") passengerFlow = 1000;
                break;

            case "�����":
                if (season == "��") passengerFlow = 1000;
                else if (season == "��") passengerFlow = 1000;
                else if (season == "��") passengerFlow = 1000;
                else if (season == "��") passengerFlow = 1000;
                break;

            case "��ׯ":
                if (season == "��") passengerFlow = 1200;
                else if (season == "��") passengerFlow = 1200;
                else if (season == "��") passengerFlow = 1200;
                else if (season == "��") passengerFlow = 1500;
                break;

            default:
                passengerFlow = 0;
                break;
        }
        passengerFlow *= Random.Range(0.8f, 1.2f) * famous;
    }
    //private void Start()
    //{
    //    shopImg = GetComponent<Image>().sprite;
    //}
    public bool JudgeWealth()
    {
        for (int i = 0; i < deductionItem.Length; i++)
        {
            if (!myBag.itemList.Contains(deductionItem[i])
                || deductionItem[i].itemHeld < costItemNum[i])
            {
                return false;
            }
        }
        return true;
    }
}
