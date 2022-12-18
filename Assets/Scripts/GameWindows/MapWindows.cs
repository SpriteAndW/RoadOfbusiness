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
        //因为这句话在字典在Awake才赋值 这里早于Awake 所以初始化失败
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
        //把UI窗口都DontDestroy


        ////把单例都DontDestroy
        //DontDestroyOnLoad(UIManger.Instance.gameObject);
        //DontDestroyOnLoad(GameController.Instance.gameObject);



        //else
        //{
        //    //把UI窗口都Destroy
        //    foreach (var item in UIManger.Instance.UIwindowsdic)
        //    {
        //        Destroy(item.Value.gameObject);
        //    }

        //    //把单例都DontDestroy
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
        
        //根据点击的场景名字切换场景
        EventHandler.CallAfterSceneLoadeEvent(eventData.pointerClick.name);
    }
    
    
}
