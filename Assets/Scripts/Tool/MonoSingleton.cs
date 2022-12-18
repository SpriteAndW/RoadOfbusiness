using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 这是一个工具类
/// 继承自mono的单例类
/// 管理类继承这个类就行
/// </summary>
public class MonoSingleton<T> : MonoBehaviour where T: MonoSingleton<T>
{
    private static T instance;
    public static T Instance 
    {
        get
        {
            //把字段instance返回出去 但是字段instance可能还没赋值
            //因为这个属性是静态的 所以不能直接return this返回一个对象
            if (instance == null)
            {
                //一开始还没赋值instance是null
                instance = FindObjectOfType<T>();
                //如果找完之后还是空（管理器脚本没有挂在物体身上）

                if(instance == null)
                {
                    //给游戏对象命名
                    new GameObject("Singleton of " + typeof(T)).AddComponent<T>();

                }
                else
                {
                    //如果对象找完仍然为空 会创建对象 在Awake里面会调用Init
                    instance.Init();
                }
                
            }
            return instance;
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            //如果这个脚本是自己手动挂在物体上的 那么可以这样把对象返还出去
            instance = this as T;
            Init();
        }
    }

    protected virtual void Init()
    {
        //这是一个初始化方法
        //继承这个类的子类的对象都会调用一次这个方法

        //把单例都设置为跳场景不删除
        DontDestroyOnLoad(this.gameObject);
        
    }
    
}
