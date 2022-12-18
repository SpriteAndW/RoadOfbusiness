using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GameDate
{
    [Serializable]
    public class UserData
    {
        public string ID; // 用户ID
        public string UserName; // 用户名
        public string Password; // 密码
        public int level; // 等级
        public int strength; // 力量
        public int dex; // 敏捷
        public int focus; // 精力
        public int skillPoint; // 技能点
        [SerializeField]
        public List<PropCount> allProp;

        public void Load()
        {

        }
    }
}