using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//游戏的根管理器
public class GameRoot : MonoBehaviour
{
    public static GameRoot Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        SceneSystem.Instance.SetScene(new StartScene());
    }
}
