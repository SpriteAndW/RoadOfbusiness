using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlotRecordPanel : MonoBehaviour
{
    public DialogueDetial dialogD;
    public Text plotText;
    public Scrollbar scrob;

    public void Refresh()
    {
        plotText.text = "";
        plotText.text += dialogD.plotString + "\n\n";
        for (int i = 0; i < dialogD.DialoguePieces.Count; i++)
        {
            plotText.text += string.Format("{0}:{1}\n\n",
                dialogD.DialoguePieces[i].faceName, dialogD.DialoguePieces[i].dialogueText);
        }
        scrob.value = 1;
    }
}
