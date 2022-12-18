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
        //��Ҫ��UIWindows��awake����Ϊ����Ŀ���д�� ��Ȼֱ��awake���ԭ���ĸ��ǵ�
        base.Awake();
        chooseButtons = new List<GameObject>(2);
    }


    //private void Start()
    //{
    //    //business = FindObjectOfType<Business>();
 
        
    //}

    //����ѡ�� ����UI �����¼�����Ӱ��
    public void GenerateChooseUI(string[] choose)
    {
        
        //�ж��ǲ�����ߵ�ѡ��
        //float offect = isLeft ? -450 : 450;
        //isLeft = !isLeft;
        //�ȰѴ�����Ϊ�ɼ�
        SetVisible(true);
        //������ӿ����õ���Ա����
        //�������ߵ� �Ͱѵ�һ��Ԫ������Ϊ������� ��������Ϊ�ڶ���
        //chose.Add(choose);
        //����ѡ��ť��Ԥ�Ƽ�
        
        //���ɰ�ťԤ�Ƽ�����ִ��ѡ��ķ������ص���ť��
        for (int i = 0; i < choose.Length; i++)
        {
            GameObject chooseButton = ResourcesManger.Load<GameObject>(choose[i]);
            GameObject choseButton = Instantiate<GameObject>(chooseButton, transform);
            choseButton.AddComponent(Type.GetType(choose[i]));
            choseButton.GetComponent<UIEventHandler>().PointerClick += ChooseExe;
            chooseButtons.Add(choseButton);
        }
        
        //�������߾� �ͼ�choose0 �ұ߾ͼ�choose1

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

        //ִ��ѡ�����ķ���
        //chose[1].Execute(Business.Instance);
        //ͬʱҪɾ����ť ���� �Ѵ�������
        //ɾ��ֱ����Destory ������һ��setvisable����

        //TODO Destory�Ǹ���ť��û�����ôд
        //����� �����ô��һ��list Ȼ���������ȫ��ɾ��
}
