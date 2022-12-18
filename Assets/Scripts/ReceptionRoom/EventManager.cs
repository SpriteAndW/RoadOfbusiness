using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoSingleton<EventManager>
{
    [Header("是否触发随机事件")] public bool isTriggerEvent;



    private void Update()
    {
        JudgeEvent();
    }

    /// <summary>
    /// 判断事件发生条件
    /// </summary>
    private void JudgeEvent()
    {

    }


}
