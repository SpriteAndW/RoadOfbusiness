using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "TradeDelegateBar", menuName = "TradeDelegate/delegateBar")]
public class TradeDelegateBar : ScriptableObject
{
    //�������б�
    public List<TradeDelegate> delegateBar = new List<TradeDelegate>();
}
