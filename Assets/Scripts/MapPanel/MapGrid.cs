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
                message.ShowMessage("��������Ѿ���ռ����");
                return;
            }
            for (int i = 0; i < panel.mapBag.allRoads.Count; i++)
            {
                for (int j = 0; j < panel.mapBag.allRoads[i].Count; j++)
                {
                    if (panel.mapBag.allRoads[i].Contains(gridInfo))
                    {
                        MessageWindow.Instance.ShowMessage("��������Ѿ���ռ����");
                        return;
                    }
                }
            }


            if (panel.isFirstRoute)
            {
                if (!Business.Instance.myLand.Contains(gridInfo))
                {
                    MessageWindow.Instance.ShowMessage("�㻹û�й���õ�Ŷ�����ܴӴ˵ط���");
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
                //������ӵ�λ�ú���һ�����������ڵ�
                if (Mathf.Abs(gridInfo.position -
                    panel.mapBag.tempRoad[panel.mapBag.tempRoad.Count - 1].position) != 10
                    && Mathf.Abs(gridInfo.position -
                    panel.mapBag.tempRoad[panel.mapBag.tempRoad.Count - 1].position) != 1)
                {
                    message.ShowMessage("��ѡ�����ڵĸ���");
                    return;
                }

                gridInfo.mapColor = panel.mapBag.tempRoad[panel.mapBag.tempRoad.Count - 1].mapColor;
                GetComponent<Image>().color = gridInfo.mapColor;
                panel.mapBag.tempRoad.Add(gridInfo);
            }
        }
        else
        {
            //���ģʽ
            B_panel.gameObject.SetActive(true);
            B_panel.mgInfo = gridInfo;
            B_panel.Refresh();
        }
    }
        
}
