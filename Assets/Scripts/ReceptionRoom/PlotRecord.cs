using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlotRecord : MonoBehaviour
{
    public DialogueDetial dialogD;

    public PlotRecordPanel panel;

    public Text plotName;

    public void Init()
    {
        panel = Resources.FindObjectsOfTypeAll<PlotRecordPanel>()[0];
        plotName.text = dialogD.plotName;
        GetComponentInChildren<Button>().onClick.AddListener(OpenPlotRecordPanel);
    }
    public void OpenPlotRecordPanel()
    {
        
        panel.dialogD = dialogD;
        panel.Refresh();
        panel.gameObject.SetActive(true);
    }
}
