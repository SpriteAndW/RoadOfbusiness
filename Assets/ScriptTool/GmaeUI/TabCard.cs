using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameDate;

namespace GameUI
{
    public class TabCard : MonoBehaviour
    {
        
        private Toggle toggle;
        private Text txtOff;
        public PropInfo.PropType propType;
        // Start is called before the first frame update
        void Awake()
        {
            toggle = GetComponent<Toggle>();
            txtOff = transform.Find("Label").GetComponent<Text>();
            if (toggle == null || txtOff == null)
            {
                Debug.LogError("错误，未找到组件");
                return;
            }
            CheckisOn();
            //事件的私有绑定
            toggle.onValueChanged.AddListener(onValueChangedHandler);
        }
        private void onValueChangedHandler(bool isOn)
        {
            CheckisOn();
            if (isOn)
            {
                SendMessageUpwards("changePropType", propType);
            }
        }
        private void CheckisOn()
        {
            if (toggle.isOn)
                txtOff.color = new Color(0.54f, 0.73f, 0.82f);
            else
                txtOff.color = new Color(0.047f, 0.071f, 0.082f);
            
        }
    }

}
