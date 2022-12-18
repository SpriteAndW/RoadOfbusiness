using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransportItem : MonoBehaviour
{
    public Item transportItem;
    public int itemHeld;
    public Slider numSlide;
    public GameObject selected;
    public TransportPanel panel;

    private void Start()
    {
        selected = transform.GetChild(0).gameObject;
        numSlide = FindObjectOfType<Slider>();
        panel = FindObjectOfType<TransportPanel>();
        GetComponent<Button>().onClick.AddListener(onTransItemClick);


    }

    private void onTransItemClick()
    {
        //������ȡ��ѡ�� ����ǰ����Ϊѡ��
        panel.SetAllselectedFalse();
        
        selected.gameObject.SetActive(true);

        panel.tempTranportItem = transportItem;
        numSlide.value = 0;
        numSlide.maxValue = itemHeld;
    }
}
