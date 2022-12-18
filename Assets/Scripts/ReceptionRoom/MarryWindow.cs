using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MarryWindow : MonoBehaviour
{

    public Scrollbar scrollB;
    public Button nextBut;
    public Button lastBut;
    public int currentIndex = 1;
    public RectTransform grid;
    public float size;

    private void Start()
    {
        for (int i = 0; i < grid.childCount; i++)
        {
            grid.GetChild(i).localScale = new Vector3(1f, 1f, 1);
        }
        grid.GetChild(currentIndex).localScale = new Vector3(1, 1, 1);
    }

    // public void ReceptionRoomGuide()
    // {
    //     if (DialogueManager.instance.isReceptionGuideing)
    //     {
    //         NoviceGuidePanel._instance.NextStep(ReceptionRoomGuideConst.CloseMarry);
    //     }
    // }

    public void NextStep()
    {
        scrollB.value += size;
        grid.GetChild(currentIndex).localScale = new Vector3(1f, 1f, 1);
        currentIndex += 1;
        grid.GetChild(currentIndex).localScale = new Vector3(1f, 1f, 1);

        if (DialogueManager.instance.isReceptionGuideing)
        {
            NoviceGuidePanel._instance.NextStep(ReceptionRoomGuideConst.NextGril);
        }
    }
    public void LastStep()
    {
        scrollB.value -= size;
        grid.GetChild(currentIndex).localScale = new Vector3(1f, 1f, 1);
        currentIndex -= 1;
        grid.GetChild(currentIndex).localScale = new Vector3(1f, 1f, 1);
    }

    private void Update()
    {
        if(scrollB.value < 0.1f)
        {
            lastBut.interactable = false;
        }
        else
        {
            lastBut.interactable = true;
        }
        if (scrollB.value > 0.9f)
        {
            nextBut.interactable = false;
        }
        else
        {
            nextBut.interactable = true;
        }
    }

    public void ReceptionRoomNextGuideClose()
    {
        gameObject.SetActive(false);
        
        if (DialogueManager.instance.isReceptionGuideing)
        {
            NoviceGuidePanel._instance.NextStep(ReceptionRoomGuideConst.CloseMarry);
        }
    }

}
