using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    public class Swicth : MonoBehaviour
    {
        private Toggle toggle;
        private Image imgOff;

        void Awake()
        {
            toggle = GetComponent<Toggle>();
            imgOff = transform.Find("Background/ImageOff").GetComponent<Image>();
            if (toggle==null||imgOff==null)
            {
                Debug.LogError("错误，未找到组件");
                return;
            }
            CheckisOn();
            //事件的私有绑定
            toggle.onValueChanged.AddListener(onValueChangedHandler);
        }
        private void onValueChangedHandler(bool isOn )
        {
            CheckisOn();
        }

        private void CheckisOn()
        {
            if (toggle.isOn)
                imgOff.enabled = false;
            else
                imgOff.enabled = true;
        }
    }

}
