using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarrierButton : MonoBehaviour
{
    public Marrier marrier;
    public MarryPanel panel;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OpenMarryPanel);
    }

    private void OpenMarryPanel()
    {
        panel.marrier = marrier;
        panel.gameObject.SetActive(true);
        panel.Refresh();

        if (DialogueManager.instance.isReceptionGuideing)
        {
            NoviceGuidePanel._instance.NextStep(ReceptionRoomGuideConst.ChooseGril);
        }


    }
}
