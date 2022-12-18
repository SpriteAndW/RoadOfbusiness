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
    /// ͨ�������ļ������� ��ȡ�������ݵķ���
    /// �����ļ���������ConfigMap.txt
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    /// 
    public static string GetConfigfile(string fileName)
    {

        //����StreamingAssets�ļ����ڲ�ͬƽ̨���ĸ�Ŀ¼��
        string url;

//�������Լ�PCƽ̨
#if UNITY_EDITOR || UNITY_STANDALONE
        url = "file://" + Application.dataPath + "/StreamingAssets/" + fileName;
//��׿ƽ̨
#elif UNITY_ANDROID
        url = "jar:file://" + Application.dataPath + "!/assets/" + fileName;
//IOSƽ̨
#elif UNITY_IPHONE
        url = "file://" + Application.dataPath + "/Raw/" + fileName;
#endif

        //ͨ��www������ȡstreamingAssets���������
        //url���Ǹ��ļ���������ļ���·��
        UnityWebRequest request = UnityWebRequest.Get(url);
        //���п��Է������� ��ȡ���� 
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
        //�����Ž�������Ľ������Զ�ִ��string�Ľ������� 
        using(StringReader reader = new StringReader(fileContent))
        {
            //reader.Dispose stringreader�Ľ�������
            string line;
            while((line = reader.ReadLine()) != null)
            {
                //���ַ������Ⱥŷֿ�
                string[] keyvalue = line.Split('=');
                //�ֿ�������Ԫ�� ��һ�����ļ��� �ڶ������ļ�·��
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
