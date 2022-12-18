using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// UI�¼������� 
/// �̳��˲������UI�¼�����
/// </summary>
public class UIEventHandler : MonoBehaviour, IPointerClickHandler, 
    IPointerDownHandler, IPointerUpHandler, IDragHandler, IDropHandler, 
    IBeginDragHandler, IEndDragHandler
{
    /********  ����ί����  *********/
    //�ȶ���һ��ί�� ���ί�л�ʵ��handler����ķ���
    public delegate void UIeventListener(PointerEventData eventData);


    //������������ ÿ���¼���Ҫ����һ��ί�ж���
    //����event��Ϊ����ί�и�ֵ��ʱ���һ�θ�ֵҲ����+= ������ӵ�һ�ε���=
    
    /// <summary>
    /// ��ʼ��קʱ
    /// </summary>
    public event UIeventListener BeginDrag;
    /// <summary>
    /// ��ק
    /// </summary>
    public event UIeventListener Drag;
    /// <summary>
    /// ����ק�ɿ�ʱ
    /// </summary>
    public event UIeventListener Drop;
    /// <summary>
    /// ������קʱ
    /// </summary>
    public event UIeventListener EndDrag;
    /// <summary>
    /// ���ʱ
    /// </summary>
    public event UIeventListener PointerClick;
    /// <summary>
    /// �������ʱ
    /// </summary>
    public event UIeventListener PointerDown;
    /// <summary>
    /// ����ɿ�ʱ
    /// </summary>
    public event UIeventListener PointerUp;
    /******************* ʵ�ֽӿ��� **********************/
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(BeginDrag!=null)
            BeginDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(Drag!=null)
        Drag(eventData);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(Drop!=null)
            Drop(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (EndDrag != null)
            EndDrag(eventData);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (PointerClick != null)
            PointerClick(eventData);

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (PointerDown != null)
            PointerDown(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (PointerUp != null)
            PointerUp(eventData);
    }

    /******************  �ṩ������ ***************************/
    public static UIEventHandler GetUIeventhandlerByTransform(Transform tf)
    {
        //ֱ����uieventhandler��� �������null ����û�й���
        UIEventHandler uievent = tf.GetComponent<UIEventHandler>();
        if (uievent == null)
        {
            //����Ҳ������¼�һ�� ���س�ȥ
            uievent = tf.gameObject.AddComponent<UIEventHandler>();
        }
        return uievent;
    }
}
