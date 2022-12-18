using System.Collections;
using System.Collections.Generic;
using Tool;
using UnityEngine;
using UnityEngine.EventSystems;

public class ReceptionButton : MonoBehaviour
{
    public ReceptionRoomUI recepW;
    void Start()
    {
        GetComponent<UIEventHandler>().PointerClick += ShopWindowVis;
        Camera.main.GetComponent<AnimationEventbehavior>().OnAnimationEnd += Test;
    }

    private void ShopWindowVis(PointerEventData eventData)
    {
        Camera.main.GetComponent<Animator>().SetBool("Recp", true);
    }
    private void Test()
    {
        recepW.SetVisible(true);
        Camera.main.GetComponent<Animator>().SetBool("Recp", false);
    }


}
