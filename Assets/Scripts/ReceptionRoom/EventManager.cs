using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoSingleton<EventManager>
{
    [Header("�Ƿ񴥷�����¼�")] public bool isTriggerEvent;



    private void Update()
    {
        JudgeEvent();
    }

    /// <summary>
    /// �ж��¼���������
    /// </summary>
    private void JudgeEvent()
    {

    }


}
