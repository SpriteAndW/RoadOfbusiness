using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyLandPanel : MonoBehaviour
{
    public MapGridInfo mgInfo;
    public Text description;
    public Image itemImg;
    public void Refresh()
    {
        description.text = string.Format("����{0}�Ƹ�ֵ����{1}������ÿ�غϽ���������������²���", mgInfo.price, mgInfo.mapName);
        itemImg.sprite = mgInfo.product.itemImg;
    }


    public void ConfirmBuy()
    {
        if (Business.Instance.myLand.Contains(mgInfo))
        {
            MessageWindow.Instance.ShowMessage(string.Format("���Ѿ�ӵ��{0}�������ظ�����", mgInfo.mapName));
            return;
        }
        if(Business.Instance.wealth < mgInfo.price)
        {
            MessageWindow.Instance.ShowMessage("��ĲƸ�ֵ�����Թ���");
            return;
        }
        //ȷ�Ϲ��� �ѵؼ���business�� Ȼ��رմ���
        Business.Instance.myLand.Add(mgInfo);
        Business.Instance.wealth -= mgInfo.price;
        MessageWindow.Instance.ShowMessage("����ɹ�");
        gameObject.SetActive(false);
        MainWindow.Instance.Refresh();
    }

    public void CancelBuy()
    {
        gameObject.SetActive(false);
    }
}
