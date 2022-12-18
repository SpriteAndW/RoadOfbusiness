using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ChooseFactory
{
    public static IChoose CreateChoose(string className)
    {
        className += "Choose";
        return CreateObject<IChoose>(className);
    }


    //创建商铺对象
    public static Shops CreateShops(string className)
    {
        className += "Shop";
        return CreateObject<Shops>(className);
    }

    /// <summary>
    /// 创建对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="className"></param>
    /// <returns></returns>
    private static T CreateObject<T>(string className) where T:class
    {
        Type type = Type.GetType(className);
        return Activator.CreateInstance(type) as T; 
    }
}
