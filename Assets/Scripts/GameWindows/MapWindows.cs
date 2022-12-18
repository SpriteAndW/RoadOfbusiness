using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapWindows : UIFunctionWindow
{
    //private Business business;
    public string[] scenesName;
    //public GameObject[] singleton;
    public bool isFirstTime = true;
    public StoreWindow storeW;
    override protected void Start()
    {
        base.Start();
        scenesName = new string[] {"Scene2", "Scene4", "Scene5", "Scene6", "Scene7", "Scene8" ,"MainScene"};
        
        //mapW = UIManger.Instance.Getwindows<MapWindows>();
        //��Ϊ��仰���ֵ���Awake�Ÿ�ֵ ��������Awake ���Գ�ʼ��ʧ��
        //mainW.SetVisible(true);
        for (int i = 0; i < scenesName.Length; i++)
        {
            if (i == 2)
                this.GetUIeventhandler(scenesName[i]).PointerClick += LoadSceneStore;
            else
                this.GetUIeventhandler(scenesName[i]).PointerClick += LoadSceneByName;
        }
    }

    public void LoadSceneStore(PointerEventData eventData)
    {
        EventHandler.CallAfterSceneLoadeEvent(eventData.pointerClick.name);
        storeW = UIManger.Instance.Getwindows<StoreWindow>();
        storeW.SetVisible(true);

        storeW.Refresh();
    }

    public void LoadSceneByName(PointerEventData eventData)
    {
        if (isFirstTime)
        {
            foreach (var item in UIManger.Instance.UIwindowsdic)
            {
                DontDestroyOnLoad(item.Value.gameObject);
            }
            DontDestroyOnLoad(GameObject.Find("EventSystem"));
            isFirstTime = false;
        }
        //��UI���ڶ�DontDestroy


        ////�ѵ�����DontDestroy
        //DontDestroyOnLoad(UIManger.Instance.gameObject);
        //DontDestroyOnLoad(GameController.Instance.gameObject);



        //else
        //{
        //    //��UI���ڶ�Destroy
        //    foreach (var item in UIManger.Instance.UIwindowsdic)
        //    {
        //        Destroy(item.Value.gameObject);
        //    }

        //    //�ѵ�����DontDestroy
        //    //Destroy(UIManger.Instance.gameObject);
        //    //Destroy(GameController.Instance.gameObject);
        //    Destroy(GameObject.Find("EventSystem"));
        //}


        SetVisible(false);
        if(SceneManager.GetActiveScene().name == eventData.pointerClick.name)
        {
            return;
        }
        // SceneManager.LoadScene(eventData.pointerClick.name);
        
        //���ݵ���ĳ��������л�����
        EventHandler.CallAfterSceneLoadeEvent(eventData.pointerClick.name);
    }
    
    
}
