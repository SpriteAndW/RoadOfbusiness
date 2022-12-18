using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsManager : MonoSingleton<BuildingsManager>
{
    [Header("��������")] public int buildingType = 0; //0Ϊδ���� 1Ϊ�¶�Ժ 2Ϊ��ʿӪ

    [Header("��������")][Range(0,5)] public int buildingNum = 1;

    private int countDay =0;

    [Header("��������")] public int fixedDay;

    [Header("�¶�Ժ��ֵ")] public int defuctWealth = 10000;
    public int increaseCredit = 1;
    public int guPrice = 20000;

    [Header("��ʿӪ��ֵ")]public int defuctCredit = 1;
    public int increaseWealth = 10000;
    public int siPrice = 30000;
    public void BuildNew()
    {
        if(buildingNum!=5)
            buildingNum++;
    }

    public void DismantleOld()
    {
        if(buildingNum!=0)
            buildingNum--;
    }

    /// <summary>
    /// ÿ�����һ�μ������ж��Ƿ񵽴ﶨ������
    /// �ﵽ�������һ���ֻ�
    /// </summary>
    public bool JudgeDay()
    {
        if (buildingType == 0) return false;
        countDay++;
        if(countDay==fixedDay)
        {
            countDay = 0;
            if(buildingType==1)
            {
                Business.Instance.ChangeCredit(increaseCredit);
                Business.Instance.ChangeWealth(defuctWealth);
                
            }
            else
            {
                Business.Instance.ChangeCredit(defuctCredit);
                Business.Instance.ChangeWealth(increaseWealth);
            }
            return true;
        }
        return false;
    }

}
