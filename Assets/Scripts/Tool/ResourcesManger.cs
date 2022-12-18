using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

public class ResourcesManger
{
    public static Dictionary<string, string> ConfigMap;

    static ResourcesManger()
    {
        string fileContent = GetConfigfile("ConfigMap.txt");
        BuildMap(fileContent);
    }

    /// <summary>
    /// 通过配置文件的名字 读取里面内容的方法
    /// 配置文件的名字是ConfigMap.txt
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    /// 
    public static string GetConfigfile(string fileName)
    {

        //关于StreamingAssets文件夹在不同平台的哪个目录下
        string url;

//编译器以及PC平台
#if UNITY_EDITOR || UNITY_STANDALONE
        url = "file://" + Application.dataPath + "/StreamingAssets/" + fileName;
//安卓平台
#elif UNITY_ANDROID
        url = "jar:file://" + Application.dataPath + "!/assets/" + fileName;
//IOS平台
#elif UNITY_IPHONE
        url = "file://" + Application.dataPath + "/Raw/" + fileName;
#endif

        //通过www类来读取streamingAssets里面的内容
        //url是那个文件夹里面的文件的路径
        UnityWebRequest request = UnityWebRequest.Get(url);
        //这行可以发送请求 读取数据 
        request.SendWebRequest();
        while (true)
        {
            if (request.downloadHandler.isDone)
            {
                return request.downloadHandler.text;
            }
        }
    } 

    private static void BuildMap(string fileContent)
    {
        ConfigMap = new Dictionary<string, string>();
        //大括号结束里面的结束后自动执行string的结束方法 
        using(StringReader reader = new StringReader(fileContent))
        {
            //reader.Dispose stringreader的结束方法
            string line;
            while((line = reader.ReadLine()) != null)
            {
                //把字符串按等号分开
                string[] keyvalue = line.Split('=');
                //分开后有俩元素 第一个是文件名 第二个是文件路径
                ConfigMap.Add(keyvalue[0], keyvalue[1]);
            }
        }
    }

    public static T Load<T>(string prefabName) where T:Object
    {

        string prefabPath = ConfigMap[prefabName]; 
        
        return Resources.Load<T>(prefabPath);
    }
}
