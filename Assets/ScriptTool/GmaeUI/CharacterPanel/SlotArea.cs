using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDate;
namespace GameUI
{
    public class SlotArea : MonoBehaviour
    {
        private List<PropCount> listProps;//所有的物品信息
        private AllProps allPropsInfo;//所有物品类型数据
        void Start()
        {

        }
        void Update()
        {

        }
        //接受到道具参数和信息
        private void PackgePageProps(List<PropCount> Props)
        {
            listProps = Props;
            setAllPropsDate();
        }
        //接受到玩家信息
        private void propInfoLoadComplete(AllProps PropsInfo)
        {
            allPropsInfo = PropsInfo;
            setAllPropsDate();
        }
        //比对列表，更改图片
        //private Sprite getSpritById(string id)
        //{
        //    if (id == null || id.Length < 1)
        //        return null;
        //    for (int i = 0; i < allPropsInfo.props.Count; i++)
        //    {
        //        if (id.Equals(allPropsInfo.props[i].ID))
        //        {
        //            Sprite spr = Resources.Load<Sprite>(allPropsInfo.props[i].path);
        //            return spr;
        //        }
        //    }
        //    return null;
        //}
        //private PropInfo getPropInfoById(string id)
        //{
        //    if (id == null || id.Length < 1)
        //        return null;
        //    for (int i = 0; i < allPropsInfo.props.Count; i++)
        //    {
        //        if (id.Equals(allPropsInfo.props[i].ID))
        //        {
        //            return allPropsInfo.props[i];
        //        }
        //    }
        //    return null;
        //}
        //处理信息
        private void setAllPropsDate()
        {
            if (allPropsInfo==null||listProps==null)
            {
                return;
            }
            //1、设置物品数量和图标
            ItemImg[] itemImgs = transform.GetComponentsInChildren<ItemImg>();
            for (int i = 0; i < itemImgs.Length; i++)
            {
                if (i > listProps.Count - 1)
                {
                    itemImgs[i].setDate(-1, null);
                    continue;
                }
                //Sprite spr = getSpritById(listProps[i].propID);
                Sprite spr = listProps[i].getSpritById(allPropsInfo);
                itemImgs[i].setDate(listProps[i].count, spr);
            }
            //2、设置物品提示信息
            ItemSlot[] itemSlots = transform.GetComponentsInChildren<ItemSlot>();
            for (int i = 0; i < itemSlots.Length; i++)
            {
                if (i > listProps.Count - 1)
                {
                    itemSlots[i].setDate(null);
                    continue;
                }
                //Sprite spr = getSpritById(listProps[i].propID);
                //itemImgs[i].setDate(listProps[i].count, spr);
                //PropInfo propInfo = getPropInfoById(listProps[i].propID);
                PropInfo propInfo = listProps[i].getPropInfoById(allPropsInfo);
                itemSlots[i].setDate(propInfo);
            }
        }
    }

}
