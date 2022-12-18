using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InTradeBoss : MonoBehaviour
{
    public BusinessItem boss;
    public BossPanel panel;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OpenBossPanel);
    }

    private void OpenBossPanel()
    {
        panel.boss = boss;
        panel.gameObject.SetActive(true);
        
        panel.Refresh();
    }
}
