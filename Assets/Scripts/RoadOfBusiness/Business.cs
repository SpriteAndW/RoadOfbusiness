using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ??????
/// ???????
/// </summary>
public class Business : MonoSingleton<Business>
{
	//=============????????????????========================    
    //????
    [SerializeField]
    public float credit = 0;
    //???
    public float wealth = 0;



    //???????????
    public int playDays = 1;

    //????
    public Shops vocation;

    //???????
    public List<Shops> shops = new List<Shops>();

    //???????????
    public int currentJoinLeague;

    //????????
    public List<MapGridInfo> myLand = new List<MapGridInfo>();

    //???????
    public List<TradeDelegate> tradeDele = new List<TradeDelegate>();

    //?????????????
    public int outdateFoodNum;

    public List<Marrier> wife;

    
    //?????????????
    public int transactionNum = 0;
    
    //?????????????
    public int borrowMoneyCantNum = 0;

    public int tradeSuccessfulNum = 0;
    
    //??????????????
    public bool isInvest;
    
    //????????
    public int saveMoneyNum = 0;

    public List<Shops> outQGPShops = new List<Shops>();
    
    public void ChangeCredit(float val)
    {
        credit += val;
    }

    public void ChangeWealth(float val)
    {
        wealth += val;
    }


}