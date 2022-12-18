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
        description.text = string.Format("�ص㣺{0}    ��Ҫ���ʣ�{3} x {4}��                      ����{1}\nʱ�䣺{2}������   ί����:{5}",
            dele.address.mapName, dele.Deposit, dele.deadline, dele.reqItem.itemName, dele.itemNum, dele.boss.bossName);
        needItem.sprite = dele.reqItem.itemImg;
        itemNum.text = dele.itemNum.ToString(); 
    }

    //��������
    public void AcceptTask()
    {
        //��delegate��isAccept���true
        //��business�����Ǹ�dele
        //������destroy
        dele.isAccept = true;
        Business.Instance.tradeDele.Add(dele);
        //�Ѷ������
        Business.Instance.wealth += dele.Deposit;
        dele.playdays = Business.Instance.playDays;
        MessageWindow.Instance.ShowMessage("ί���ѽ��ܣ������ѵ���");
        Destroy(this.gameObject);

    }

    
}