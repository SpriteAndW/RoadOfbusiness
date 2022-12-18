using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameDate;

namespace GameUI
{
    public class SkillPointBar : MonoBehaviour
    {

        //组件
        private Text attributeNameTxt;
        private Text attributePointTxt;
        private Button PlusBtn;
        private Button SubBtn;

        //参数
        private int currentPoint = 10;//当前点数
        private int remainPoint = 5;//剩余点数
        public string attName;//技能名称
        private int oriValue;//原始值

        public string AttName
        {
            set
            {
                attName = value;
                if (attributeNameTxt != null)
                    attributeNameTxt.text = attName;
            }
        }

        public int CurrentPoint
        {
            get => currentPoint;
            private set
            {
                currentPoint = value;
                //oriValue = currentPoint;
                if (attributePointTxt!=null)
                    attributePointTxt.text = "" + currentPoint;
            }
        }

        public int RemainPoint
        {
            get => remainPoint;
            set
            {
                remainPoint = value;
                SendMessageUpwards("userDataSkillPointText", RemainPoint);
                if (remainPoint > 0)
                    PlusBtn.image.enabled = true;
                if (remainPoint == 0)
                    PlusBtn.image.enabled = false;
                if (currentPoint > oriValue)
                    SubBtn.image.enabled = true;
                if (currentPoint == oriValue)
                    SubBtn.image.enabled = false;
                //if ()
                //{
                //    if (!PlusBtn.image.enabled)
                //        PlusBtn.image.enabled = true;
                //    if (CurrentPoint == oriValue)//如果当前点数等于原始值
                //        SubBtn.image.enabled = false;
                //}
            }
        }
        public void InitCurrentPoint(int value)
        {
            currentPoint = value;
            oriValue = currentPoint;
            if (attributePointTxt != null)
                attributePointTxt.text = "" + currentPoint;
        }

        void Awake()
        {
            InitComp();
        }

        private void InitComp()
        {
            attributeNameTxt = transform.Find("Text_SkillPointName").GetComponent<Text>();
            attributePointTxt = transform.Find("Slot/Text").GetComponent<Text>();
            PlusBtn = transform.Find("Buttons/PlusButton").GetComponent<Button>();
            SubBtn = transform.Find("Buttons/SubButton").GetComponent<Button>();
            if (attributeNameTxt == null || attributePointTxt == null || PlusBtn == null || SubBtn == null)
            {
                Debug.LogError("错误，未找到组件");
                return;
            }
            AttName = attName;
            CurrentPoint = currentPoint;
            PlusBtn.onClick.AddListener(PlusClickHandler);
            SubBtn.onClick.AddListener(SubClickHandler);
            SubBtn.image.enabled = false;
            
        }

        private void PlusClickHandler()
        {
            if (RemainPoint > 0)
            {
                CurrentPoint++;
                RemainPoint--;
                if (!SubBtn.image.enabled)
                    SubBtn.image.enabled = true;
                if (RemainPoint <= 0)
                    PlusBtn.image.enabled = false;
                SendMessageUpwards("SkillPointChanged", -1);
            }
        }
        private void SubClickHandler()
        {
            if (CurrentPoint > oriValue)
            {
                CurrentPoint--;
                RemainPoint++;
                if (!PlusBtn.image.enabled)
                    PlusBtn.image.enabled = true;
                if (CurrentPoint == oriValue)//如果当前点数等于原始值
                    SubBtn.image.enabled = false;
                SendMessageUpwards("SkillPointChanged", 1);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
        //private void userDataLoadComplete(UserData userData)
        //{
        //    remainPoint = userData.skillPoint;
        //    switch (transform.name)
        //    {
        //        case "SkillPointBar_1":
        //            CurrentPoint = userData.strength;
        //            oriValue = userData.strength;//保留原始值
        //            break;
        //        case "SkillPointBar_2":
        //            CurrentPoint = userData.dex;
        //            oriValue = userData.dex;//保留原始值
        //            break;
        //        case "SkillPointBar_3":
        //            CurrentPoint = userData.focus;
        //            oriValue = userData.focus;//保留原始值
        //            break;
        //    }
        //}
    }
}

