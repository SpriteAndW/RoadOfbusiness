using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameDate
{
    [Serializable]
    public class PropInfo
    {
        public enum PropType
        {
            ALL,
            ITEM,
            EQUIPMENT
        }
        public string ID; // 物品编号
        public string Name; // 物品名称
        public int type; // 类型(1、回复，2、消耗，3、装备)
        public int utility; // 功效(1、回血，2、回蓝，3、加技能点，4、金钱，5、提升防御属性，6、提升攻击属性)
        public int value; // 数值
        public bool isOverly; // 是否可以叠加
        public int maxOverly; // 最大叠加数量
        public string info; // 物品说明
        public string path; // 图片路径

        //获取道具功效的字符串
        public string getEffectStr()
        {
            if (utility < 0 || utility > 6)
                return "";
            string[] effectNames = { "未知", "回血", "回蓝", "加技能点", "金钱", "提升防御属性", "提升攻击属性" };
            string effectStr = effectNames[utility] + ":" + value;
            return effectStr;
        }
    }
}
