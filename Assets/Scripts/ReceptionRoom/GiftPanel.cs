using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiftPanel : MonoBehaviour
{
    public Transform grid;
    public Inventory myBag;
    public Item tempGift;
    public List<GameObject> allItemSelected;
    public GameObject giftItem;
    public int giftNum;
    public MarryPanel mPanel;

    public void Refresh()
    {
        allItemSelected.Clear();
        tempGift = null;
        for (int i = 0; i < grid.childCount; i++)
        {
            Destroy(grid.GetChild(i).gameObject);
        }
        for (int i = 0; i < myBag.itemList.Count; i++)
        {
            if (myBag.itemList[i].itemHeld < 500)
            {
                continue;
            }
            GameObject tranI = Instantiate<GameObject>(giftItem, grid);
            //���Ǹ������ı�ѡ�е��Ǹ�ȦȦ��������
            allItemSelected.Add(tranI.transform.GetChild(0).gameObject);
            GitfItem transP = tranI.GetComponent<GitfItem>();
            transP.transportItem = myBag.itemList[i];
            tranI.GetComponent<Image>().sprite = myBag.itemList[i].itemImg;
        }
    }

    public void SetAllselectedFalse()
    {
        foreach (var item in allItemSelected)
        {
            item.SetActive(false);
        }
    }

    public void Gifts()
    {

        if (tempGift == null)
        {
            MessageWindow.Instance.ShowMessage("��δѡ����ʲô����,��ѡ��");
            return;
        }
        if (mPanel.marrier.isGift)
        {
            MessageWindow.Instance.ShowMessage("�����Ѿ��͹�������,���������Ͱ�");
            return;
        }

        tempGift.itemHeld -= giftNum;
        if (mPanel.marrier.favoItem.Contains(tempGift))
        {
            MessageWindow.Instance.ShowMessage(mPanel.marrier.mName + "��ϲ�������Ʒ,�øж����", tempGift.itemImg);
            mPanel.marrier.intimacy += 2;
        }
        else if (mPanel.marrier.hateItem.Contains(tempGift))
        {
            MessageWindow.Instance.ShowMessage(mPanel.marrier.mName + "�����������Ʒ,�øжȽ���", tempGift.itemImg);
            mPanel.marrier.intimacy -= 2;
        }
        else
        {
            MessageWindow.Instance.ShowMessage(mPanel.marrier.mName + "�������Ʒ�޸�,�øж�С����", tempGift.itemImg);
            mPanel.marrier.intimacy += 1;
        }
        mPanel.marrier.isGift = true;
        gameObject.SetActive(false);
    }
    


}
