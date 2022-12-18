using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GitfItem : MonoBehaviour
{
    public Item transportItem;


    public GameObject selected;
    public GiftPanel panel;

    private void Start()
    {
        selected = transform.GetChild(0).gameObject;

        panel = FindObjectOfType<GiftPanel>();
        GetComponent<Button>().onClick.AddListener(onTransItemClick);


    }

    private void onTransItemClick()
    {
        //������ȡ��ѡ�� ����ǰ����Ϊѡ��
        panel.SetAllselectedFalse();

        selected.gameObject.SetActive(true);

        panel.tempGift = transportItem;
    }
}
