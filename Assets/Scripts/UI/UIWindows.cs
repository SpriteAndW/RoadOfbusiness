using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Tool;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���Ƿ��ڻ�������� ÿ����������һ������ ���Կ��ƻ����������ȵ�...
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
        //������Э����ʵ���������Ե��������
        StartCoroutine(visibledelay(state, delay));
    }

    public IEnumerator visibledelay(bool state, float delay)
    {
        //��ʱdelay��
        //�õ�Э�� ֻ��һ��ѭ����Ӧ��˵����ѭ����
        //yield return �����waitforseconds������� �����һ��float����ʱ��
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

        //�����飨��canvasgroup��������alpha���Ծ����Ż�����͸���� 1���� 0����
        canvasgroup.alpha = state ? 1 : 0;
        //canvas���Ƿ�����
        canvas.enabled = state;

    }

    public UIEventHandler GetUIeventhandler(string name)
    {
        //����ֵ��в�����������ֵĶ�������
        if (!uieventDic.ContainsKey(name))
        {
            //�Ͱ��������������ô��ȥ�ֵ� �´ε��õ�ʱ��
            //��Ϊ������ ��ֱ��return�ֵ�[name]��ȥ��
            UIEventHandler uievent = UIEventHandler.GetUIeventhandlerByTransform(transform.GetchildByname(name));
            uieventDic.Add(name, uievent);
        }
        return uieventDic[name];
    }

}
