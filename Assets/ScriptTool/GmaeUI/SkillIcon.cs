using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
namespace GameUI
{
    public class SkillIcon : MonoBehaviour
    {
        [Header("快捷键")]
        public char HotKeyStr = '1';
        [Header("技能冷却时间")]
        public float coldTime = 10.0f;//技能冷却时间
        private float SkillcoldTimer = 10.0f;//技能冷却计时器

        private Text HotKeyText;//快捷键文本
        private Image SkillImg;//冷却阴影图
        private EventTrigger ClickTrigger;//点击组件

        private bool isColding = false;//是否正在冷却
        private void Awake()
        {
            initComp();
        }
        void Start()
        {

        }
        void Update()
        {
            if (!isColding)
            {
                int keyCode = 0;
                if (HotKeyStr >= 'A' && HotKeyStr <= 'Z')
                    keyCode = HotKeyStr + 32;
                else
                    keyCode = HotKeyStr;
                if (Input.GetKeyDown((KeyCode)keyCode))
                {
                    StartSkill();
                }
            }
        }
        private void FixedUpdate()
        {
            //print(Time.fixedDeltaTime);
            if (isColding)
            {
                if (SkillcoldTimer<coldTime)
                {
                    SkillcoldTimer += Time.fixedDeltaTime;
                    SkillImg.fillAmount =1- (SkillcoldTimer / coldTime);
                }
                else
                {
                    isColding = false;
                    SkillImg.fillAmount = 0;
                }
            }

        }
        private void initComp()
        {
            HotKeyText = transform.Find("HotKeyText").GetComponent<Text>();
            SkillImg = transform.Find("SkillCold").GetComponent<Image>();
            ClickTrigger = transform.Find("SkillImg").GetComponent<EventTrigger>();
            if (HotKeyText == null || SkillImg == null || ClickTrigger == null)
            {
                Debug.LogError("错误，未找到相应组件");
                return;
            }

            HotKeyText.text = HotKeyStr.ToString();
            SkillImg.fillAmount = 0;

            //动态绑定图片
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerClick;
            entry.callback.AddListener(ClickHandler);
            ClickTrigger.triggers.Add(entry);
        }//初始化
        public void ClickHandler(BaseEventData data)
        {
            //开始计时
            StartSkill();
        }

        private void StartSkill()
        {
            if (!isColding)
            {
                isColding = true;
                SkillcoldTimer = 0;
                SkillImg.fillAmount = 1;
            }
        }
    }

}
