using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tool
{
    /// <summary>
    /// Transform工具类 可以一直递归寻找子类中名字的物体
    /// </summary>
    public static class TransformHelper
    {
        /// <summary>
        /// 通过递归寻找子物体tf组件的方法
        /// </summary>
        /// <param name="tf">需要找子物体的父物体的Transform组件</param>
        /// <param name="name">子物体的名字</param>
        /// <returns></returns>
        public static Transform GetchildByname(this Transform tf, string name)
        {
            Transform childtf = tf.Find(name);
            if (childtf != null) return childtf;
            for (int i = 0; i < tf.childCount; i++)
            {
                childtf = GetchildByname(tf.GetChild(i), name);
                if (childtf != null)
                {
                    return childtf;
                }
            }
            return null;
        }
    }
}
