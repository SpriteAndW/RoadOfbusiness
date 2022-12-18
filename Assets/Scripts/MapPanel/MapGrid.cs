using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MapGrid : MonoBehaviour
{
    public MapPanel panel;
    public bool isTrade;
    public MapGridInfo gridInfo;
    public Button buyLandBut;
    public MessageText message;
    public BuyLandPanel B_panel;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(onMapClick);
        //B_panel = FindObjectOfType<BuyLandPanel>();
    }

    private void onMapClick()
    {
        if(panel.buttonFun == ButtonFun.transport)
        {
            if (panel.mapBag.tempRoad.Contains(gridInfo))
            {
                message.ShowMessage("这个格子已经被占用了");
                return;
            }
            for (int i = 0; i < panel.mapBag.allRoads.Count; i++)
            {
                for (int j = 0; j < panel.mapBag.allRoads[i].Count; j++)
                {
                    if (panel.mapBag.allRoads[i].Contains(gridInfo))
                    {
                        MessageWindow.Instance.ShowMessage("这个格子已经被占用了");
                        return;
                    }
                }
            }


            if (panel.isFirstRoute)
            {
                if (!Business.Instance.myLand.Contains(gridInfo))
                {
                    MessageWindow.Instance.ShowMessage("你还没有购买该地哦，不能从此地发货");
                    return;
                }
                buyLandBut.gameObject.SetActive(false);
                panel.mapBag.tempRoad.Clear();
                panel.mapBag.tempRoad.Add(gridInfo);
                gridInfo.mapColor = Random.ColorHSV();
                GetComponent<Image>().color = gridInfo.mapColor;

                panel.isFirstRoute = false;
            }

            else
            {
                //如果格子的位置和上一个格子是相邻的
                if (Mathf.Abs(gridInfo.position -
                    panel.mapBag.tempRoad[panel.mapBag.tempRoad.Count - 1].position) != 10
                    && Mathf.Abs(gridInfo.position -
                    panel.mapBag.tempRoad[panel.mapBag.tempRoad.Count - 1].position) != 1)
                {
                    message.ShowMessage("请选择相邻的格子");
                    return;
                }

                gridInfo.mapColor = panel.mapBag.tempRoad[panel.mapBag.tempRoad.Count - 1].mapColor;
                GetComponent<Image>().color = gridInfo.mapColor;
                panel.mapBag.tempRoad.Add(gridInfo);
            }
        }
        else
        {
            //买地模式
            B_panel.gameObject.SetActive(true);
            B_panel.mgInfo = gridInfo;
            B_panel.Refresh();
        }
    }
        
}
