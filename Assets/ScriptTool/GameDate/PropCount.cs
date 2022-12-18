using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameDate
{
    [Serializable]
    public class PropCount
    {
        public string userID; // 用户ID
        public string propID; // 物品ID
        public int count; // 数量

        public PropInfo.PropType getPropType(AllProps allProps)
        {
            if (allProps == null)
                return PropInfo.PropType.ALL;
            for (int i = 0; i < allProps.props.Count; i++)
            {
                if (propID.Equals(allProps.props[i].ID))
                {
                    return (PropInfo.PropType)allProps.props[i].type;
                }
            }
            return PropInfo.PropType.ALL;
        }
        public PropInfo getPropInfoById(AllProps allProps)
        {
            if (propID == null || propID.Length < 1 || allProps == null)
                return null;
            for (int i = 0; i < allProps.props.Count; i++)
            {
                if (propID.Equals(allProps.props[i].ID))
                {
                    return allProps.props[i];
                }
            }
            return null;
        }
        public Sprite getSpritById(AllProps allProps)
        {
            if (propID == null || propID.Length < 1 || allProps == null)
                return null;
            for (int i = 0; i < allProps.props.Count; i++)
            {
                if (propID.Equals(allProps.props[i].ID))
                {
                    Sprite spr = Resources.Load<Sprite>(allProps.props[i].path);
                    return spr;
                }
            }
            return null;
        }
    }
}
