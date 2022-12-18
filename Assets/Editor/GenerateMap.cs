using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class GenerateMap : Editor
{
    //这个方法将在编译器上面的tool那里执行
    [MenuItem("Tools/Resources/Generate ResConfig File")]
    public static void Generate()
    {
        //生成配置资源文件
        //1.查找Resources目录下所有预制件的路径 FindAssets("t:查找的后缀", 路径)
        string[] resFiles = AssetDatabase.FindAssets
            ("t:prefab", new string[] { "Assets/Resources" });
        for (int i = 0; i < resFiles.Length; i++)
        {
            //fing找到的是GUID 转化为路径string
            resFiles[i] = AssetDatabase.GUIDToAssetPath(resFiles[i]);
            string filename = Path.GetFileNameWithoutExtension(resFiles[i]);
            string pathname = resFiles[i].Replace("Assets/Resources/", string.Empty)
                .Replace(".prefab", string.Empty);

            resFiles[i] = filename + "=" + pathname;
        }

        //写入文件 一行一行的
        File.WriteAllLines("Assets/StreamingAssets/ConfigMap.txt", resFiles);
        //刷新
        AssetDatabase.Refresh();
    }
}
