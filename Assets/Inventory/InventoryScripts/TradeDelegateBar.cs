using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "TradeDelegateBar", menuName = "TradeDelegate/delegateBar")]
public class TradeDelegateBar : ScriptableObject
{
    //任务栏列表
    public List<TradeDelegate> delegateBar = new List<TradeDelegate>();
}
