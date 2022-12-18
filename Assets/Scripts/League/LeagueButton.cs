using System;
using System.Collections;
using System.Collections.Generic;
using Tool;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeagueButton : MonoBehaviour
{
    public LeagueWindow leagueW;
    void Start()
    {
        GetComponent<UIEventHandler>().PointerClick += Bank;
        Camera.main.GetComponent<AnimationEventbehavior>().OnAnimationEnd += Test;
    }


    private void Bank(PointerEventData eventData)
    {

        Camera.main.GetComponent<Animator>().SetBool("League", true);


    }
    private void Test()
    {
        leagueW.SetVisible(true);
        Camera.main.GetComponent<Animator>().SetBool("League", false);
    }
}
