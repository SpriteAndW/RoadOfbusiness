using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsManager : MonoSingleton<BuildingsManager>
{
    [Header("建筑类型")] public int buildingType = 0; //0为未建造 1为孤儿院 2为死士营

    [Header("建筑数量")][Range(0,5)] public int buildingNum = 1;

    private int countDay =0;

    [Header("定期天数")] public int fixedDay;

    [Header("孤儿院数值")] public int defuctWealth = 10000;
    public int increaseCredit = 1;
    public int guPrice = 20000;

    [Header("死士营数值")]public int defuctCredit = 1;
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
    /// 每天进行一次计数，判断是否到达定期天数
    /// 达到则进行下一次轮回
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
