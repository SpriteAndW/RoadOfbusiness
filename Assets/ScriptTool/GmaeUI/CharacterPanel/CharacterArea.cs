using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameDate;

namespace GameUI
{
    public class CharacterArea : MonoBehaviour
    {
        private Text SkillPointText;
        private Text userNameText;
        //private Text strengthPointText;
        //private Text DexPointText;
        //private Text FocusPointText;
        private SkillPointBar spb_Strength;
        private SkillPointBar spb_Dex;
        private SkillPointBar spb_Focus;

        private UserData userDataMsg;//用户数据消息
        void Awake()
        {
            InitComp();
        }

        private void InitComp()
        {
            SkillPointText = transform.Find("SkillBoard/Text_Points").GetComponent<Text>();
            userNameText = transform.Find("UserNameArea/Text_Name").GetComponent<Text>();
            spb_Strength = transform.Find("SkillPointsArea/SkillPointBar_1").GetComponent<SkillPointBar>();
            spb_Dex = transform.Find("SkillPointsArea/SkillPointBar_2").GetComponent<SkillPointBar>();
            spb_Focus = transform.Find("SkillPointsArea/SkillPointBar_3").GetComponent<SkillPointBar>();
            if (SkillPointText == null || userNameText == null || spb_Strength == null || spb_Dex == null || spb_Focus == null)
            {
                Debug.LogError("错误");
                return;
            }
        }

        private void userDataLoadComplete(UserData userData)
        {
            spb_Strength.InitCurrentPoint(userData.strength);
            spb_Dex.InitCurrentPoint(userData.dex);
            spb_Focus.InitCurrentPoint(userData.focus);

            spb_Strength.RemainPoint = userData.skillPoint;
            spb_Dex.RemainPoint = userData.skillPoint;
            spb_Focus.RemainPoint = userData.skillPoint;

            userDataMsg = userData;
        }
        private void userDataSkillPointText(int RemainPoint)
        {
            //SkillPointText.text = "" + RemainPoint;
        }
        //消息响应函数
        private void SkillPointChanged(int value)
        {
            userDataMsg.skillPoint += value;
            SkillPointText.text = "" + userDataMsg.skillPoint;

            spb_Strength.RemainPoint = userDataMsg.skillPoint;
            spb_Dex.RemainPoint = userDataMsg.skillPoint;
            spb_Focus.RemainPoint = userDataMsg.skillPoint;
        }
        void Update()
        {

        }
    }
}

