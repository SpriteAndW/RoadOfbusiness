using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class GenerateMap : Editor
{
    //����������ڱ����������tool����ִ��
    [MenuItem("Tools/Resources/Generate ResConfig File")]
    public static void Generate()
    {
        //����������Դ�ļ�
        //1.����ResourcesĿ¼������Ԥ�Ƽ���·�� FindAssets("t:���ҵĺ�׺", ·��)
        string[] resFiles = AssetDatabase.FindAssets
            ("t:prefab", new string[] { "Assets/Resources" });
        for (int i = 0; i < resFiles.Length; i++)
        {
            //fing�ҵ�����GUID ת��Ϊ·��string
            resFiles[i] = AssetDatabase.GUIDToAssetPath(resFiles[i]);
            string filename = Path.GetFileNameWithoutExtension(resFiles[i]);
            string pathname = resFiles[i].Replace("Assets/Resources/", string.Empty)
                .Replace(".prefab", string.Empty);

            resFiles[i] = filename + "=" + pathname;
        }

        //д���ļ� һ��һ�е�
        File.WriteAllLines("Assets/StreamingAssets/ConfigMap.txt", resFiles);
        //ˢ��
        AssetDatabase.Refresh();
    }
}
