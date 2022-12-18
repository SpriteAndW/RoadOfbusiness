using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// UI事件监听类 
/// 继承了差不多所有UI事件监听
/// </summary>
public class UIEventHandler : MonoBehaviour, IPointerClickHandler, 
    IPointerDownHandler, IPointerUpHandler, IDragHandler, IDropHandler, 
    IBeginDragHandler, IEndDragHandler
{
    /********  定义委托区  *********/
    //先定义一个委托 这个委托会实现handler具体的方法
    public delegate void UIeventListener(PointerEventData eventData);


    //定义完后就声明 每个事件都要声明一个委托对象
    //加上event是为了让委托赋值的时候第一次赋值也能用+= 如果不加第一次得用=
    
    /// <summary>
    /// 开始拖拽时
    /// </summary>
    public event UIeventListener BeginDrag;
    /// <summary>
    /// 拖拽
    /// </summary>
    public event UIeventListener Drag;
    /// <summary>
    /// 不拖拽松开时
    /// </summary>
    public event UIeventListener Drop;
    /// <summary>
    /// 结束拖拽时
    /// </summary>
    public event UIeventListener EndDrag;
    /// <summary>
    /// 点击时
    /// </summary>
    public event UIeventListener PointerClick;
    /// <summary>
    /// 点击按下时
    /// </summary>
    public event UIeventListener PointerDown;
    /// <summary>
    /// 点击松开时
    /// </summary>
    public event UIeventListener PointerUp;
    /******************* 实现接口区 **********************/
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

    /******************  提供方法区 ***************************/
    public static UIEventHandler GetUIeventhandlerByTransform(Transform tf)
    {
        //直接找uieventhandler组件 如果等于null 即是没有挂上
        UIEventHandler uievent = tf.GetComponent<UIEventHandler>();
        if (uievent == null)
        {
            //如果找不到就新加一个 返回出去
            uievent = tf.gameObject.AddComponent<UIEventHandler>();
        }
        return uievent;
    }
}
