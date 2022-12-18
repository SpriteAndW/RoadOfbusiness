using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameDate;
namespace GameUI
{
    public class ItemSlot : MonoBehaviour
    {
        private GameObject itemInfoObj;//物品信息面板
        private GameObject itemOperObj;//物品操作面板
        
        private Button btn_Use;//使用按钮
        private Button btn_Throw;//丢弃按钮

        private bool isOpenOperObj = false;//是否已经打开了操作界面
        // Start is called before the first frame update
        void Start()
        {
            infoComp();
        }

        private void infoComp()
        {
            itemInfoObj = transform.Find("ItemInfo").gameObject;
            itemOperObj = transform.Find("ItemInfo/ItemOper").gameObject;
            btn_Use = transform.Find("ItemInfo/ItemOper/Btn_Use/Button").GetComponent<Button>();
            btn_Throw = transform.Find("ItemInfo/ItemOper/Btn_Throw/Button").GetComponent<Button>();
            if (itemInfoObj == null || itemOperObj == null)
            {
                Debug.LogError("找不到子对象，请检查");
                return;
            }

            if (btn_Use == null || btn_Throw == null)
            {
                Debug.LogError("找不到组件，请检查");
                return;
            }
            btn_Use.onClick.AddListener(UseItemClick);
            btn_Throw.onClick.AddListener(ThrowItemClick);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(1) && isOpenOperObj)
            {
                closeOperObj();
            }
        }

        private void closeOperObj()
        {
            itemOperObj.SetActive(false);
            itemInfoObj.SetActive(false);
            isOpenOperObj = false;
        }

        //private void OnMouseDown()
        //{
        //    if (isOpenOperObj)
        //    {
        //        itemOperObj.SetActive(false);
        //        itemInfoObj.SetActive(false);
        //        isOpenOperObj = false;
        //    }
        //}
        //消息响应函数 当鼠标移动到物品
        private void ItemPointerEnter(string str)
        {
            if (!itemInfoObj.activeSelf)
                itemInfoObj.SetActive(true);
        }
        //消息响应函数 当鼠标从物品上移开
        private void ItemPointerExit(string str)
        {
            if (itemInfoObj.activeSelf && !itemOperObj.activeSelf)
                itemInfoObj.SetActive(false);
        }
        //消息响应函数 当鼠标点击物品
        private void ItemPointerClick(string str)
        {
            if (!itemOperObj.activeSelf)
            {
                itemOperObj.SetActive(true);
                isOpenOperObj = true;
            }
        }
        private void UseItemClick()
        {
            BroadcastMessage("useItem", "use");
            closeOperObj();
        }
        private void ThrowItemClick()
        {
            BroadcastMessage("ThrowItem", "Throw");
            closeOperObj();
        }
        public void setDate(PropInfo propInfo)
        {
            if (propInfo == null)
                return;
            Image itemimg = transform.Find("ItemInfo/ItemSmallImg").GetComponent<Image>();
            Text itemNameText= transform.Find("ItemInfo/ItemName_Text").GetComponent<Text>();
            Text itemInfoText= transform.Find("ItemInfo/ItemInfo_Text").GetComponent<Text>();
            Text itemEffectText= transform.Find("ItemInfo/ItemEffect_Text").GetComponent<Text>();
            if (itemimg==null|| itemNameText == null || itemInfoText == null || itemEffectText == null)
            {
                Debug.LogError("错误，未找到组件");
                return;
            }
            itemimg.sprite = Resources.Load<Sprite>(propInfo.path);
            itemNameText.text = propInfo.Name;
            itemInfoText.text = propInfo.info;
            itemEffectText.text = propInfo.getEffectStr();
        }
    }

}
