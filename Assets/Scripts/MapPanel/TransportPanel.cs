using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransportPanel : MonoBehaviour
{
    public Inventory myBag;

    public Transform grid;

    public GameObject transportItem;

    public List<GameObject> allItemSelected = new List<GameObject>();

    public Slider numSlider;

    public Text num;

    public bool isSubmited;

    public MessageText message;

    //用于暂存点击的物品的item
    public Item tempTranportItem;

    public void Refresh()
    {
        for (int i = 0; i < grid.childCount; i++)
        {
            Destroy(grid.GetChild(i).gameObject);
        }
        for (int i = 0; i < myBag.itemList.Count; i++)
        {
            if(myBag.itemList[i].itemHeld <= 0)
            {
                continue;
            }
            GameObject tranI = Instantiate<GameObject>(transportItem, grid);
            //把那个东西的被选中的那个圈圈给存起来
            allItemSelected.Add(tranI.transform.GetChild(0).gameObject);
            TransportItem transP = tranI.GetComponent<TransportItem>();
            transP.transportItem = myBag.itemList[i];
            transP.itemHeld = myBag.itemList[i].itemHeld;
            tranI.GetComponent<Image>().sprite = myBag.itemList[i].itemImg;
        }
    }

    //private void Start()
    //{
    //    Refresh();
    //}
    public void SetAllselectedFalse()
    {
        foreach (var item in allItemSelected)
        {
            item.SetActive(false);
        }
    }

    public void Update()
    {
        num.text = (numSlider.value* tempTranportItem.itemHeld).ToString();
    }

    /// <summary>
    /// 确认发货
    /// </summary>
    public void ConfirmTransport()
    {
        if(tempTranportItem == null || numSlider.value == 0)
        {
            message.ShowMessage("你还未选择运输物品或者运输数量为0");
            return;
        }
        //把tempItem提交上去给
        tempTranportItem.itemHeld -= (int)(numSlider.value * tempTranportItem.itemHeld);
        isSubmited = true;
        gameObject.SetActive(false);
        for (int i = 0; i < grid.childCount; i++)
        {
            Destroy(grid.GetChild(i).gameObject);
        }
        allItemSelected.Clear();
    }
    public void ClosePanel()
    {
        gameObject.SetActive(false);
        allItemSelected.Clear();
    }
}
