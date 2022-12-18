using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace GameUI
{
    public class AudioButton : MonoBehaviour
    {
        private Button btn;
        private Image Iconimg;
        private Sprite spr_On;
        private Sprite spr_Off;
        private bool isOn = true;//是否处于开启状态

        private void Awake()
        {
            spr_On= Resources.Load<Sprite>("Textures/Buttons/Icons/Shape 1");
            spr_Off= Resources.Load<Sprite>("Textures/Buttons/Icons/Shape 19");

            if (spr_On == null || spr_Off == null)
            {
                Debug.LogError("错误，没有找到资源");
                return;
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            btn = transform.Find("Btn_Audio").GetComponent<Button>();
            Iconimg = transform.Find("Btn_Audio/Icon").GetComponent<Image>();
            if (btn == null || Iconimg == null)
            {
                Debug.LogError("错误，没有找到组件");
                return;
            }
            btn.onClick.AddListener(ClickHandler);
            
        }
        private void ClickHandler()
        {
            isOn = !isOn;
            if (isOn)
            {
                Iconimg.sprite = spr_On;
            }
            else
            {
                Iconimg.sprite = spr_Off;
            }
        }
        private void OnDestroy()
        {
            
        }
    }
}

