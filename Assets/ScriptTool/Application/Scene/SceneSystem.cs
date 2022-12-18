using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//场景管理系统
public class SceneSystem:SingletonBase<SceneSystem>
{
    private SceneBase sceneBase;
    public void SetScene(SceneBase scene)
    {
        if (scene == null)
            return;
        if (sceneBase != null)
            sceneBase.OnExit();//切换场景时，原场景调用退出函数
        sceneBase = scene;
        sceneBase.OnEnter();//新场景调用进入方法
    }
}
