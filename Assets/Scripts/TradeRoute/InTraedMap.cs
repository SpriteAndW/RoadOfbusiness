using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InTraedMap : MonoBehaviour
{
    [SerializeField]
    public MapGridInfo gridInfo;
    public InTradePanel panel;
    public Text description;
    public void Start()
    {
        description.text = gridInfo.mapName;
        GetComponentInChildren<Button>().onClick.AddListener(OpenInTradePanel);
        panel = Resources.FindObjectsOfTypeAll<InTradePanel>()[0];
    }

    private void OpenInTradePanel()
    {
        panel.gridInfo = gridInfo;
        panel.gameObject.SetActive(true);
        panel.Refresh();
    }
}
