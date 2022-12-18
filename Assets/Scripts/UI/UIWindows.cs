using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Tool;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 这是放在画布的组件 每个画布就是一个窗口 可以控制画布的显隐等等...
/// </summary>

public class UIWindows : MonoBehaviour
{
    CanvasGroup canvasgroup;
    Canvas canvas;
    Dictionary<string, UIEventHandler> uieventDic;

    protected virtual void Awake()
    {
        canvasgroup = GetComponent<CanvasGroup>();
        canvas = GetComponent<Canvas>();
        uieventDic = new Dictionary<string, UIEventHandler>();
    }
    public void SetVisible(bool state, float delay=0)
    {
        //用启用协程来实现设置属性的这个方法
        StartCoroutine(visibledelay(state, delay));
    }

    public IEnumerator visibledelay(bool state, float delay)
    {
        //延时delay秒
        //用的协程 只有一次循环（应该说不是循环）
        //yield return 后面加waitforseconds这个对象 里面加一个float控制时间
        yield return new WaitForSeconds(delay);
        //if (state)
        //{
        //    transform.GetChild(0).localScale = new Vector3(1, 0, 1);
        //    transform.GetChild(0).DOScale(new Vector3(1, 1, 1), 1);
        //}
        //else
        //{
        //    transform.GetChild(0).DOScale(new Vector3(0, 1, 1), 1);
        //}

        //Sequence seq = DOTween.Sequence();

        //画布组（）canvasgroup这个组件的alpha属性决定着画布的透明度 1是显 0是隐
        canvasgroup.alpha = state ? 1 : 0;
        //canvas的是否启用
        canvas.enabled = state;

    }

    public UIEventHandler GetUIeventhandler(string name)
    {
        //如果字典中不包含这个名字的对象引用
        if (!uieventDic.ContainsKey(name))
        {
            //就把这个这个对象引用存进去字典 下次调用的时候
            //因为存在了 就直接return字典[name]出去了
            UIEventHandler uievent = UIEventHandler.GetUIeventhandlerByTransform(transform.GetchildByname(name));
            uieventDic.Add(name, uievent);
        }
        return uieventDic[name];
    }

}
