using UnityEngine;
using System.IO;

namespace Helper
{
    public class FileHelper
    {
        public enum FILESRC
        {
            DataPath,
            PersistentDataPath
        }
        //路径
        /*
         * 将一个json文件读成字符串
         * 
         * directory -- 文件相对路径
         * 
         * fileName -- 文件名
         * 
         * src -- 文件所在位置(枚举)
         */
        public static string ReadFileToJson(string directory, string fileName, FILESRC src)
        {
            string JsonStr = "";
            string path = "";
            switch (src)
            {
                case FILESRC.DataPath:
                    path = Application.dataPath;
                    break;
                case FILESRC.PersistentDataPath:
                    path = Application.persistentDataPath;
                    break;
            }
            path = path + directory;//拼装路径

            if (!Directory.Exists(path))
            {
                Debug.LogError("读取路径不存在");
                return JsonStr;
            }
            path += fileName;
            if (!File.Exists(path))
            {
                Debug.LogError("读取文件不存在");
                return JsonStr;
            }
            JsonStr = File.ReadAllText(path);
            return JsonStr;
        }
        //格式 -- Json
        //转换成对象
        public T JsonStrToObj<T>(string JsonStr)
        {
            T t = JsonUtility.FromJson<T>(JsonStr);

            return t;
        }
        public bool SaveObjToJsonFile<T>(string directory, string fileName, T t)
        {
            bool ret = true;
            string path = Application.persistentDataPath + directory;
            try
            {
                if (Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (!File.Exists(path + fileName))
                    File.CreateText(path + fileName);

                StreamWriter sw = new StreamWriter(path + fileName, false);
                string conStr = JsonUtility.ToJson(t, true);
                sw.Write(conStr);
                sw.Close();
            }
            catch (System.Exception ex)
            {
                ret = false;
                Debug.LogError(ex.Message);
                return ret;
            }
            return ret;
        }
    }
}

