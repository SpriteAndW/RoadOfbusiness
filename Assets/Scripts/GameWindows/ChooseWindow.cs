using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tool;
using UnityEngine.EventSystems;
using System;

public class ChooseWindow : UIWindows
{
    //List<IChoose> chose = new List<IChoose>();
    //private bool isLeft = true;
    private List<GameObject> chooseButtons;

    protected override void Awake()
    {
        //需要把UIWindows的awake设置为虚拟的可重写的 不然直接awake会把原来的覆盖掉
        base.Awake();
        chooseButtons = new List<GameObject>(2);
    }


    //private void Start()
    //{
    //    //business = FindObjectOfType<Business>();
 
        
    //}

    //生成选择 包括UI 还有事件对象影响
    public void GenerateChooseUI(string[] choose)
    {
        
        //判断是不是左边的选项
        //float offect = isLeft ? -450 : 450;
        //isLeft = !isLeft;
        //先把窗口设为可见
        SetVisible(true);
        //把这个接口设置到成员变量
        //如果是左边的 就把第一个元素设置为这个对象 否则设置为第二个
        //chose.Add(choose);
        //加载选择按钮的预制件
        
        //生成按钮预制件并把执行选择的方法挂载到按钮上
        for (int i = 0; i < choose.Length; i++)
        {
            GameObject chooseButton = ResourcesManger.Load<GameObject>(choose[i]);
            GameObject choseButton = Instantiate<GameObject>(chooseButton, transform);
            choseButton.AddComponent(Type.GetType(choose[i]));
            choseButton.GetComponent<UIEventHandler>().PointerClick += ChooseExe;
            chooseButtons.Add(choseButton);
        }
        
        //如果是左边就 就加choose0 右边就加choose1

        //choseButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(offect, 0);

    }

    private void ChooseExe(PointerEventData eventData)
    {
        eventData.pointerClick.GetComponent<IChoose>().Execute();

        SetVisible(false);
        foreach (var item in chooseButtons)
        {
            Destroy(item);
        }   
    }
    //private void Choose1Exe(PointerEventData eventData)

        //执行选择对象的方法
        //chose[1].Execute(Business.Instance);
        //同时要删除按钮 并且 把窗口隐藏
        //删除直接用Destory 隐藏有一个setvisable方法

        //TODO Destory那个按钮还没想好怎么写
        //想好了 把引用存进一个list 然后点击后遍历全部删除
}
