using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tool
{
    /// <summary>
    /// Transform������ ����һֱ�ݹ�Ѱ�����������ֵ�����
    /// </summary>
    public static class TransformHelper
    {
        /// <summary>
        /// ͨ���ݹ�Ѱ��������tf����ķ���
        /// </summary>
        /// <param name="tf">��Ҫ��������ĸ������Transform���</param>
        /// <param name="name">�����������</param>
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
