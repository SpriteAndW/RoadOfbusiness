using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tool 
{
    /// <summary>
    /// ���������� ����Ҫ��Ϊ��̬��
    /// Ȼ�������c#��չ������չ��������
    /// </summary>
    public static class ArrayHelper
    {
        //7��������
        //�������ҵ��� ���Ҷ�� ��ȡ���ֵ ��ȡ��Сֵ ���� ���� �Լ�ɸѡ

        //��һ������ ���ҵ��� ֱ���÷���ί�� ���������ͷ���

        public static T Find<T>(this T[] array, Func<T, bool> condition)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (condition(array[i]))
                {
                    return array[i];
                }
            }
            //���������Ĭ��ֵ ���൱��int��0 �������͵�null
            return default(T);
        }

        //�ڶ������� ���Ҷ��Ԫ��
        public static T[] FindMore<T>(this T[] array, Func<T, bool> condition)
        {
            List<T> list = new List<T>();
            for (int i = 0; i < array.Length; i++)
            {
                if (condition(array[i]))
                {
                    list.Add(array[i]);
                }
            }

            return list.ToArray();
        }

        //���������� ��ȡ���ֵ
        public static T GetMax<T, Q>(this T[] array, Func<T, Q> conditon) where Q : IComparable
        {
            //Ĭ�����ֵΪ�����һ��
            //������ÿһ����Ҫ�Ƚ� ���һ�� �Ƚϵ������ɷ���ί�д���
            //Ҫ�ȽϵĻ� ���صĶ���Ҫ���ԱȽ���ô����ֵQ�̳�Icomparable
            T max = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (conditon(array[i]).CompareTo(conditon(max)) > 0)
                {
                    max = array[i];
                }
            }
            return max;
        }

        //���ĸ����� ��ȡ��Сֵ
        public static T GetMin<T, Q>(this T[] array, Func<T, Q> conditon) where Q : IComparable
        {
            //Ĭ�����ֵΪ�����һ��
            //������ÿһ����Ҫ�Ƚ� ���һ�� �Ƚϵ������ɷ���ί�д���
            //Ҫ�ȽϵĻ� ���صĶ���Ҫ���ԱȽ���ô����ֵQ�̳�Icomparable
            T min = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (conditon(array[i]).CompareTo(conditon(min)) < 0)
                {
                    min = array[i];
                }
            }
            return min;
        }

        /// <summary>
        /// ��������� ����ķ��� ������������������ ���ò��� �޸Ķ��е����� ����Ҫ����ֵ������
        /// ��ȻҲ����д����ֵ����
        /// </summary>
        /// <typeparam name="T">��Ҫ���õ����������</typeparam>
        /// <typeparam name="Q">�Ƚϵķ���ί������ ����Ҫ�Ƚϵ��ǵ��˵�HP ��ôQ = T.HP</typeparam>
        /// <param name="array"></param>
        /// <param name="condition"></param>
        public static void SortByIncrease<T, Q>
            (this T[] array, Func<T, Q> condition) where Q : IComparable
        {
            //ÿһ������ ��֤array[i]������С��
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (condition(array[i]).CompareTo(condition(array[j])) > 0)
                    {
                        //���i�ı�j�� j�϶���i�����
                        //������ھͻ�λ 
                        T temp = array[i];
                        array[i] = array[j];
                        array[j] = array[i];
                    }
                }
            }
        }

        /// <summary>
        /// ����ķ���
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="Q"></typeparam>
        /// <param name="array"></param>
        /// <param name="condition"></param>
        public static void SortBySubtract<T, Q>
            (this T[] array, Func<T, Q> condition) where Q : IComparable
        {
            //ÿһ������ ��֤array[i]��������
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (condition(array[i]).CompareTo(condition(array[j])) < 0)
                    {
                        //���i�ı�jС j�϶���i�����
                        //������ھͻ�λ 
                        T temp = array[i];
                        array[i] = array[j];
                        array[j] = array[i];
                    }
                }
            }
        }

        //���������ί�в���Ҫ����ֵʱ �ǵ���action���ί��Ŷ
        //����ɸѡ�ķ��� ������������������ĲŻ�ӵ�����ֵ��
        //�������ͨ�����Ƿ���ĳ����� ������findobjsoftag�����һЩ����
        //Ȼ��鿴��Щ�����Ƿ���ĳ����������س�ȥ

        /// <summary>
        /// ɸѡ�����������ͨ�����Ƿ���ĳ����� ������findobjsoftag�����һЩ����
        /// Ȼ��鿴��Щ�����Ƿ���ĳ����������س�ȥ
        /// </summary>
        /// <typeparam name="T">�������������</typeparam>
        /// <typeparam name="Q">��Ҫɸѡ���������</typeparam>
        /// <param name="array"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public static Q[] Select<T, Q>(this T[] array, Func<T, Q> condition)
        {
            List<Q> list = new List<Q>();
            for (int i = 0; i < array.Length; i++)
            {
                //���������ҵ��� �������� ���ϾͰ����Ԫ����ӽ�ȥ
                if (condition(array[i]) != null)
                {
                    list.Add(list[i]);
                }
            }

            return list.ToArray();
        }
    }
}

