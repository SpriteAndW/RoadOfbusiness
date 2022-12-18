using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MapUI : MonoBehaviour
{
    public void ShopButton()
    {
        foreach (var item in UIManger.Instance.UIwindowsdic)
        {
            DontDestroyOnLoad(item.Value.gameObject);
        }
        DontDestroyOnLoad(GameObject.Find("EventSystem"));
        SceneManager.LoadScene(4);
    }

    public void ExchangeButton()
    {
        foreach (var item in UIManger.Instance.UIwindowsdic)
        {
            DontDestroyOnLoad(item.Value.gameObject);
        }
        DontDestroyOnLoad(GameObject.Find("EventSystem"));
        SceneManager.LoadScene(3);
    }

    public void ConsortiumButton()
    {
        foreach (var item in UIManger.Instance.UIwindowsdic)
        {
            DontDestroyOnLoad(item.Value.gameObject);
        }
        DontDestroyOnLoad(GameObject.Find("EventSystem"));
        SceneManager.LoadScene(7);
    }

    public void WarehouseButton()
    {
        foreach (var item in UIManger.Instance.UIwindowsdic)
        {
            DontDestroyOnLoad(item.Value.gameObject);
        }
        DontDestroyOnLoad(GameObject.Find("EventSystem"));
        SceneManager.LoadScene(4);
    }

    public void ReButton()
    {
        foreach (var item in UIManger.Instance.UIwindowsdic)
        {
            DontDestroyOnLoad(item.Value.gameObject);
        }
        DontDestroyOnLoad(GameObject.Find("EventSystem"));
        SceneManager.LoadScene(8);
    }

    public void RoadButton()
    {
        foreach (var item in UIManger.Instance.UIwindowsdic)
        {
            DontDestroyOnLoad(item.Value.gameObject);
        }
        DontDestroyOnLoad(GameObject.Find("EventSystem"));
        SceneManager.LoadScene(6);
    }
}
