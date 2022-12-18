using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Tool
{
    public class GameSaveManger : MonoSingleton<GameSaveManger>
    {
        //public Inventory myBag;
        public Item[] itemList;
        public Shops[] shopList;
        public MapGridInfo[] gridInfo;
        public MapInventory mapInven;
        public TradeDelegate[] Tdelegate;
        public BusinessItem[] allboss;
        public Marrier[] allMarriers;
        [SerializeField]
        public class GameSaveData
        {
            /***************声明要存储的对象区***************/
            public Business business;
            public BankManager bank;
            public DialogueManager diaM;
            

            public void CreateConnection()
            {
                /************创建对象和实际对象连接区***********/
                business = Business.Instance;
                bank = BankManager.Instance;
                diaM = DialogueManager.instance;
            }
        }

        public GameSaveData data;

        protected override void Init()
        {
            base.Init();
            //初始化gamesavedata对象
            data = new GameSaveData();
        }
        private void SaveGameData(Object obj, int index)
        {
            //创建一下savedata里面的成员变量和要存储的变量的连接

            
            string path = Application.persistentDataPath + "/game_Savedata" + index.ToString();

            //print(Application.persistentDataPath);

            //如果不存在这个文件夹 则创建
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            //创建二进制格式化器
            BinaryFormatter formatter = new BinaryFormatter(); //二进制转化

            //生成文件 命名格式为系统路径 + game_Savedata + 类名.txt
            FileStream file = File.Create(path + "/" + obj.name + ".txt");

            //将对象转换为json
            var json = JsonUtility.ToJson(obj, true);

            print(json);

            //将json转化为2进制存入文件   
            formatter.Serialize(file, json);

            //保存文件
            file.Close();
        }

        private void LoadSaveData(string fileName, Object obj, int index)
        {

            BinaryFormatter bf = new BinaryFormatter();
            //获取文件中的存档文件
            string path = Application.persistentDataPath + "/game_Savedata" + index.ToString();

            FileStream file = File.Open(path + "/" + fileName + ".txt", FileMode.Open);
            if(file == default(FileStream))
            {
                MessageWindow.Instance.ShowMessage("这个存档位还未保存存档");
                return;
            }
            //print((string)bf.Deserialize(file));
            //暂时先这样写 这个根据文件名存到相应对象怎么写呢

            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), obj);
            file.Close();
            
        }

        public void SaveAllData(int index)
        {
            data.CreateConnection();
            SaveGameData(data.business, index);
            SaveGameData(data.bank, index);
            //SaveGameData(myBag, index);
            SaveGameData(mapInven, index);
            SaveGameData(data.diaM, index);
            for (int i = 0; i < itemList.Length; i++)
            {
                SaveGameData(itemList[i], index);
            }
            for (int i = 0; i < shopList.Length; i++)
            {
                SaveGameData(shopList[i], index);
            }
            for (int i = 0; i < gridInfo.Length; i++)
            {
                SaveGameData(gridInfo[i], index);
            }
            for (int i = 0; i < Tdelegate.Length; i++)
            {
                SaveGameData(Tdelegate[i], index);
            }
            for (int i = 0; i < allboss.Length; i++)
            {
                SaveGameData(allboss[i], index);
            }
            for (int i = 0; i < allMarriers.Length; i++)
            {
                SaveGameData(allMarriers[i], index);
            }
        }


        public void LoadAllSaveData(int index)
        {
            data.CreateConnection();
            //把所有对象的gettype都传过来
            for (int i = 0; i < itemList.Length; i++)
            {
                LoadSaveData(itemList[i].name, itemList[i], index);
            }
            for (int i = 0; i < shopList.Length; i++)
            {
                LoadSaveData(shopList[i].name, shopList[i], index);
            }
            for (int i = 0; i < gridInfo.Length; i++)
            {
                LoadSaveData(gridInfo[i].name, gridInfo[i], index);
            }
            for (int i = 0; i < Tdelegate.Length; i++)
            {
                LoadSaveData(Tdelegate[i].name, Tdelegate[i], index);
            }
            for (int i = 0; i < allboss.Length; i++)
            {
                LoadSaveData(allboss[i].name, allboss[i], index);
            }
            for (int i = 0; i < allMarriers.Length; i++)
            {
                LoadSaveData(allMarriers[i].name, allMarriers[i], index);
            }
            LoadSaveData(data.business.name, data.business, index);
            LoadSaveData(data.bank.name, data.bank, index);
            //LoadSaveData(myBag.name, myBag, index);
            LoadSaveData(mapInven.name, mapInven, index);
            LoadSaveData(data.diaM.name, data.diaM, index);

            EventHandler.CallAfterSceneLoadeEvent("MainScene");
        }

        /// <summary>
        /// 重置游戏 在按新游戏的时候启用 会把存的数据清空
        /// </summary>
        public void ResetGame()
        {
            //把数据库也就是scriptableObj的数据清空了
            //目前就清空mybag
            //得新建一个存档 设置好初值的 保存好 然后在读取
        }
    }
}

    

