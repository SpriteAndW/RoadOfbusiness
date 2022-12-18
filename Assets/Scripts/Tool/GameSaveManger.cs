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
            /***************����Ҫ�洢�Ķ�����***************/
            public Business business;
            public BankManager bank;
            public DialogueManager diaM;
            

            public void CreateConnection()
            {
                /************���������ʵ�ʶ���������***********/
                business = Business.Instance;
                bank = BankManager.Instance;
                diaM = DialogueManager.instance;
            }
        }

        public GameSaveData data;

        protected override void Init()
        {
            base.Init();
            //��ʼ��gamesavedata����
            data = new GameSaveData();
        }
        private void SaveGameData(Object obj, int index)
        {
            //����һ��savedata����ĳ�Ա������Ҫ�洢�ı���������

            
            string path = Application.persistentDataPath + "/game_Savedata" + index.ToString();

            //print(Application.persistentDataPath);

            //�������������ļ��� �򴴽�
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            //���������Ƹ�ʽ����
            BinaryFormatter formatter = new BinaryFormatter(); //������ת��

            //�����ļ� ������ʽΪϵͳ·�� + game_Savedata + ����.txt
            FileStream file = File.Create(path + "/" + obj.name + ".txt");

            //������ת��Ϊjson
            var json = JsonUtility.ToJson(obj, true);

            print(json);

            //��jsonת��Ϊ2���ƴ����ļ�   
            formatter.Serialize(file, json);

            //�����ļ�
            file.Close();
        }

        private void LoadSaveData(string fileName, Object obj, int index)
        {

            BinaryFormatter bf = new BinaryFormatter();
            //��ȡ�ļ��еĴ浵�ļ�
            string path = Application.persistentDataPath + "/game_Savedata" + index.ToString();

            FileStream file = File.Open(path + "/" + fileName + ".txt", FileMode.Open);
            if(file == default(FileStream))
            {
                MessageWindow.Instance.ShowMessage("����浵λ��δ����浵");
                return;
            }
            //print((string)bf.Deserialize(file));
            //��ʱ������д ��������ļ����浽��Ӧ������ôд��

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
            //�����ж����gettype��������
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
        /// ������Ϸ �ڰ�����Ϸ��ʱ������ ��Ѵ���������
        /// </summary>
        public void ResetGame()
        {
            //�����ݿ�Ҳ����scriptableObj�����������
            //Ŀǰ�����mybag
            //���½�һ���浵 ���úó�ֵ�� ����� Ȼ���ڶ�ȡ
        }
    }
}

    

