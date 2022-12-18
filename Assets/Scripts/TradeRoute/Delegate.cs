using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tool;
using UnityEngine.UI;

public class Delegate : MonoBehaviour
{
    public MessageText message;
    public TradeDelegate dele;
    public Button accept;
    public Text description;
    public Image needItem;
    public Text itemNum;

    public void Start()
    {
        //accept = transform.GetchildByname("Accept").GetComponent<Button>();
        //description = transform.GetchildByname("Description").GetComponent<Text>();
        //needItem = transform.GetchildByname("NeedItem").GetComponent<Image>();
        //itemNum = transform.GetchildByname("ItemNum").GetComponent<Text>();
        accept.onClick.AddListener(AcceptTask);
        //message = GameObject.FindGameObjectWithTag("message").GetComponent<MessageText>();

    }

    public void DisplayUIval()
    {
        description.text = string.Format("地点：{0}    需要物资：{3} x {4}个                      定金：{1}\n时间：{2}天以内   委托人:{5}",
            dele.address.mapName, dele.Deposit, dele.deadline, dele.reqItem.itemName, dele.itemNum, dele.boss.bossName);
        needItem.sprite = dele.reqItem.itemImg;
        itemNum.text = dele.itemNum.ToString(); 
    }

    //接受任务
    public void AcceptTask()
    {
        //让delegate的isAccept变成true
        //在business加上那个dele
        //将自身destroy
        dele.isAccept = true;
        Business.Instance.tradeDele.Add(dele);
        //把定金给上
        Business.Instance.wealth += dele.Deposit;
        dele.playdays = Business.Instance.playDays;
        MessageWindow.Instance.ShowMessage("委任已接受，定金已到账");
        Destroy(this.gameObject);

    }

    
}