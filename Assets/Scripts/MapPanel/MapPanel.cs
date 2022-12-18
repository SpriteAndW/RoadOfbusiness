using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ButtonFun
{
    buyLand,
    transport
}


public class MapPanel : MonoBehaviour
{
    public bool isFirstRoute = true;

    public MapInventory mapBag;

    public ButtonFun buttonFun = ButtonFun.buyLand;

    public Button confirmBut;

    public Button cancelBut;

    public Button buyLandBut;

    public Button transBut;

    public TransportPanel transPanel;

    public MessageText message;



    /// <summary>
    /// 让网格变成路线的颜色
    /// </summary>
    public void Refresh()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            //遍历每一个子物体的颜色变成那个颜色

            if(transform.GetChild(i).GetComponent<MapGrid>().gridInfo.transportItem != null)
            {
                transform.GetChild(i).GetChild(0).gameObject.SetActive(true);
                transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite =
                    transform.GetChild(i).GetComponent<MapGrid>().gridInfo.transportItem.itemImg;
            }
            else
            {
                transform.GetChild(i).GetChild(0).gameObject.SetActive(false);
                if (Business.Instance.myLand.Contains(transform.GetChild(i).GetComponent<MapGrid>().gridInfo))
                {
                    transform.GetChild(i).GetComponent<Image>().color = new Color(255, 255, 255, 255);
                }
                else
                {
                    transform.GetChild(i).GetComponent<Image>().color = new Color(150, 150, 150, 255);
                }
            }
            transform.GetChild(i).GetComponent<Image>().color = transform.GetChild(i).GetComponent<MapGrid>().gridInfo.mapColor;

            

            //if(transform.GetChild(i).GetComponent<MapGrid>())
        }
    }

    /// <summary>
    /// 设置为买地模式
    /// </summary>
    public void setBuyLand()
    {
        buttonFun = ButtonFun.buyLand;
        buyLandBut.gameObject.SetActive(false);
        transBut.gameObject.SetActive(true);
        confirmBut.gameObject.SetActive(false);
        cancelBut.gameObject.SetActive(false);
    }

    /// <summary>
    /// 设置为运输模式
    /// </summary>
    public void setTransport()
    {
        print(mapBag.GetType().GetField("road1").GetValue(mapBag) as List<MapGridInfo>);
        print(mapBag.allRoads);
        print(mapBag.allRoads.Count);
        buttonFun = ButtonFun.transport;
        mapBag.tempRoad.Clear();
        //不该把设置买地模式的给取消了
        buyLandBut.gameObject.SetActive(true);
        transBut.gameObject.SetActive(false);
        confirmBut.gameObject.SetActive(true);
        cancelBut.gameObject.SetActive(true);
        Refresh();
    }

    /// <summary>
    /// 取消运输
    /// </summary>
    public void CancelTrans()
    {
        //取消运输要把点击的格子的颜色变回白色
        for (int i = 0; i < mapBag.tempRoad.Count; i++)
        {
            mapBag.tempRoad[i].mapColor = Color.white;
            transform.GetChild(mapBag.tempRoad[i].position / 10 * 5
                + mapBag.tempRoad[i].position % 10).GetComponent<Image>().color = Color.white;
        }

        isFirstRoute = true;
        buyLandBut.gameObject.SetActive(true);
        //confirmBut.gameObject.SetActive(false);
        //cancelBut.gameObject.SetActive(false);
        mapBag.tempRoad.Clear();
    }

    public void ConfirmTrans()
    {
        StopAllCoroutines();
        //TODO打开选择运输物品panel
        if (mapBag.tempRoad.Count == 0)
        {
            MessageWindow.Instance.ShowMessage("你还未选择运输路线");
            return;
        }
        transPanel.gameObject.SetActive(true);
        transPanel.Refresh();
        transPanel.isSubmited = false;
        StartCoroutine(SubmitTransportItem());
    }

    public IEnumerator SubmitTransportItem()
    {

        yield return new WaitUntil(Submited);

        //Business.Instance.wealth -= mapBag.tempRoad.Count * 100; 扣取运费
        List<MapGridInfo> road = mapBag.GetType().GetField("road" + mapBag.index.ToString()).GetValue(mapBag) as List<MapGridInfo>;
        //print(mapBag.GetType().GetField("index").GetValue(mapBag).ToString());
        foreach (var item in mapBag.tempRoad)
        {
            //把滑条的数值传输为运输的数量
            item.itemNum = (int)transPanel.numSlider.value;
            item.transportItem = transPanel.tempTranportItem;
            road.Add(item);
        }
        MessageWindow.Instance.ShowMessage(string.Format("这个时候开始传输{0}", mapBag.tempRoad[0].transportItem.itemName));
        //mapBag.allRoads.Add(road);
        mapBag.index += 1;
        if(mapBag.index > 14)
        {
            mapBag.index = 0;
        }
        mapBag.tempRoad.Clear();
        isFirstRoute = true;
        buyLandBut.gameObject.SetActive(true);
        //confirmBut.gameObject.SetActive(false);
        //cancelBut.gameObject.SetActive(false);
        Refresh();
    }

    public bool Submited()
    {
        return transPanel.isSubmited;
    }


}

