using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDate;
using UnityEngine.UI;
using UIFrameWork;

namespace GameUI
{
    public class PackgeArea : MonoBehaviour
    {
        private PropInfo.PropType currType = PropInfo.PropType.ALL;//当前类型
        private int currPage = 1;//当前页
        private int countPage = 1;//总计页
        private UserData userData = null;//用户数据
        private AllProps allPropsInfo = null;//所有物品类型数据
        //组件
        private Button nextBtn;
        private Button preBtn;
        private Text pageText;

        void Awake()
        {
            preBtn = UITool.GetOrAddComponentInChildren<Button>("Btn_PrePage", gameObject);
            nextBtn = UITool.GetOrAddComponentInChildren<Button>("Btn_NextPage", gameObject);
            pageText = UITool.GetOrAddComponentInChildren<Text>("Pages_Text", gameObject);

            pageText.text = "1/1";

            preBtn.onClick.AddListener(turnPrePage);
            nextBtn.onClick.AddListener(turnNextPage);
        }
        private void turnPrePage()
        {
            if (currPage>1)
            {
                currPage--;
                sendPageProps(currPage);
            }
            pageText.text = currPage + "/" + countPage;
        }
        private void turnNextPage()
        {
            if (currPage < countPage)
            {
                currPage++;
                sendPageProps(currPage);
            }
            pageText.text = currPage + "/" + countPage;
        }
        void Update()
        {

        }
        private void sendPageProps(int page)
        {
            List<PropCount> listFilterProps = filterPropsByType(currType);
            countPage = listFilterProps.Count / 15 + 1;

            if (page < 1 || countPage < page)
                return;
            List<PropCount> listProps = new List<PropCount>();

            int countProp = 0;

            for (int i = (page - 1) * 15; i < listFilterProps.Count && countProp < 15; i++, countProp++)
            {
                listProps.Add(listFilterProps[i]);
            }
            BroadcastMessage("PackgePageProps", listProps);
        }
        private List<PropCount> filterPropsByType(PropInfo.PropType proptype)
        {
            if (userData == null)
                return null;
            List<PropCount> listprops = new List<PropCount>();
            switch (proptype)
            {
                case PropInfo.PropType.ALL:
                    return userData.allProp;
                case PropInfo.PropType.ITEM:
                    for (int i = 0; i < userData.allProp.Count; i++)
                    {
                        //必须需要一个通过ID知道类型的函数
                        if (userData.allProp[i].getPropType(allPropsInfo)== PropInfo.PropType.ITEM)
                        {
                            listprops.Add(userData.allProp[i]);
                        }
                    }
                    break;
                case PropInfo.PropType.EQUIPMENT:
                    for (int i = 0; i < userData.allProp.Count; i++)
                    {
                        if (userData.allProp[i].getPropType(allPropsInfo) == PropInfo.PropType.EQUIPMENT)
                        {
                            listprops.Add(userData.allProp[i]);
                        }
                    }
                    break;
            }
            return listprops;
        }
        private void userDataLoadComplete(UserData userData)
        {
            currPage = 1;
            countPage = userData.allProp.Count / 15 + 1;

            this.userData = userData;//保存一下用户数据
            currType = PropInfo.PropType.ALL;

            sendPageProps(currPage);
            //发送一页数据到slot
            //List<PropCount> listProps = new List<PropCount>();

            //int count = userData.allProp.Count > 15 ? 15 : userData.allProp.Count;

            //for (int i = 0; i < count; i++)
            //{
            //    listProps.Add(userData.allProp[i]);
            //}
            pageText.text = currPage + "/" + countPage;

            //BroadcastMessage("PackgePageProps", listProps);
        }
        private void propInfoLoadComplete(AllProps PropsInfo)
        {
            allPropsInfo = PropsInfo;
        }
        #region 分类 
        //消息响应函数
        private void changePropType(PropInfo.PropType propType)
        {
            currType = propType;
            currPage = 1;
            sendPageProps(currPage);
            pageText.text = currPage + "/" + countPage;
        }

        #endregion
    }

}
