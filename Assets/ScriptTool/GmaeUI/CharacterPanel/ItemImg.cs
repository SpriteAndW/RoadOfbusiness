using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameUI
{
    public class ItemImg : EventTrigger
    {
        private Text CountTxt;//数量文本
        private Image spriteImg;//物品图片
        public int count = 10;
        // Start is called before the first frame update
        void Awake()
        {
            CountTxt = transform.Find("Num_Text").GetComponent<Text>();
            spriteImg = transform.GetComponent<Image>();
            CountTxt.text = "" + count;
        }
        //物品修改接口
        public void setDate(int count,Sprite spr)
        {
            if (count<=0||spr==null)
            {
                CountTxt.enabled = false;
                spriteImg.enabled = false;
                return;
            }
            CountTxt.enabled = true;
            spriteImg.enabled = true;
            CountTxt.text = "" + count;
            spriteImg.sprite = spr;
        }
        public override void OnPointerEnter(PointerEventData data)
        {
            SendMessageUpwards("ItemPointerEnter", "Upwards");
        }
        public override void OnPointerExit(PointerEventData data)
        {
            SendMessageUpwards("ItemPointerExit", "Exit");
        }
        public override void OnPointerClick(PointerEventData data)
        {
            SendMessageUpwards("ItemPointerClick", "Click");
        }
        //消息响应函数，使用道具
        private void useItem(string str)
        {
            if (count>1)
            {
                count--;
                CountTxt.text = "" + count;
            }
            else
                ThrowItem("throw");
        }
        //消息响应函数，丢弃道具
        private void ThrowItem(string str)
        {
            Destroy(gameObject);
        }
    }
}

