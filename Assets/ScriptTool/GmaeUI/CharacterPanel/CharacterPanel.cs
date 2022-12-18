using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Helper;

namespace GameDate
{
    public class CharacterPanel : MonoBehaviour
    {
        private UserData userData;//用户文件类
        private AllProps props;//所有物品类型数据
        // Start is called before the first frame update
        void Start()
        {
            LoaduserData();
            LoadPropData();
            
            BroadcastMessage("userDataLoadComplete", userData);
            BroadcastMessage("propInfoLoadComplete", props);
        }
        private void LoadPropData()
        {
            //1、读取用户数据
            //A、检查原始用户数据是否存在
            if (File.Exists(Application.dataPath + "/Resources/Data/GameDate/allProps.json"))
            {
                if (!File.Exists(Application.persistentDataPath + "/allProps.json"))
                {
                    //B、文件不存在就copy一份
                    File.Copy(Application.dataPath + "/Resources/Data/GameDate/allProps.json", Application.persistentDataPath + "/allProps.json");
                }
                //C、读取该文件到某字符串
                string str = FileHelper.ReadFileToJson("/", "allProps.json", FileHelper.FILESRC.PersistentDataPath);
                //D、将字符串转换成对象
                props = JsonUtility.FromJson<AllProps>(str);
            }
            else
            {
                Debug.LogError("原文件损坏");
                return;
            }
        }
        private void LoaduserData()
        {
            //1、读取用户数据
            //A、检查原始用户数据是否存在
            if (File.Exists(Application.dataPath + "/Resources/Data/GameDate/userDate01.json"))
            {
                if (!File.Exists(Application.persistentDataPath + "/userDate01.json"))
                {
                    //B、文件不存在就copy一份
                    File.Copy(Application.dataPath + "/Resources/Data/GameDate/userDate01.json", Application.persistentDataPath + "/userDate01.json");
                }
                //C、读取该文件到某字符串
                string str = FileHelper.ReadFileToJson("/", "userDate01.json", FileHelper.FILESRC.PersistentDataPath);
                //D、将字符串转换成对象
                userData = JsonUtility.FromJson<UserData>(str);
                
            }
            else
            {
                Debug.LogError("原文件损坏");
                return;
            }
        }
        
    }
}

