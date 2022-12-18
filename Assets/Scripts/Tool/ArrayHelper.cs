using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tool 
{
    /// <summary>
    /// 数组助手类 必须要设为静态的
    /// 然后可以用c#扩展方法扩展到数组类
    /// </summary>
    public static class ArrayHelper
    {
        //7个方法：
        //包括查找单个 查找多个 获取最大值 获取最小值 升序 降序 以及筛选

        //第一个方法 查找单个 直接用泛型委托 满足条件就返回

        public static T Find<T>(this T[] array, Func<T, bool> condition)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (condition(array[i]))
                {
                    return array[i];
                }
            }
            //泛型数组的默认值 就相当于int的0 引用类型的null
            return default(T);
        }

        //第二个方法 查找多个元素
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

        //第三个方法 获取最大值
        public static T GetMax<T, Q>(this T[] array, Func<T, Q> conditon) where Q : IComparable
        {
            //默认最大值为数组第一个
            //数组中每一个都要比较 与后一个 比较的内容由泛型委托传入
            //要比较的话 返回的东西要可以比较那么返回值Q继承Icomparable
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

        //第四个方法 获取最小值
        public static T GetMin<T, Q>(this T[] array, Func<T, Q> conditon) where Q : IComparable
        {
            //默认最大值为数组第一个
            //数组中每一个都要比较 与后一个 比较的内容由泛型委托传入
            //要比较的话 返回的东西要可以比较那么返回值Q继承Icomparable
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
        /// 第五个方法 升序的方法 由于数组是引用类型 引用不变 修改堆中的数据 不需要返回值接受了
        /// 当然也可以写返回值接受
        /// </summary>
        /// <typeparam name="T">需要调用的数组的类型</typeparam>
        /// <typeparam name="Q">比较的泛型委托类型 比如要比较的是敌人的HP 那么Q = T.HP</typeparam>
        /// <param name="array"></param>
        /// <param name="condition"></param>
        public static void SortByIncrease<T, Q>
            (this T[] array, Func<T, Q> condition) where Q : IComparable
        {
            //每一次排序 保证array[i]都是最小的
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (condition(array[i]).CompareTo(condition(array[j])) > 0)
                    {
                        //如果i的比j大 j肯定排i后面的
                        //如果大于就换位 
                        T temp = array[i];
                        array[i] = array[j];
                        array[j] = array[i];
                    }
                }
            }
        }

        /// <summary>
        /// 降序的方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="Q"></typeparam>
        /// <param name="array"></param>
        /// <param name="condition"></param>
        public static void SortBySubtract<T, Q>
            (this T[] array, Func<T, Q> condition) where Q : IComparable
        {
            //每一次排序 保证array[i]都是最大的
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (condition(array[i]).CompareTo(condition(array[j])) < 0)
                    {
                        //如果i的比j小 j肯定排i后面的
                        //如果大于就换位 
                        T temp = array[i];
                        array[i] = array[j];
                        array[j] = array[i];
                    }
                }
            }
        }

        //如果当泛型委托不需要返回值时 记得用action这个委托哦
        //这是筛选的方法 如果数组中满足条件的才会加到返回值中
        //这个条件通常是是否含有某个组件 比如用findobjsoftag获得了一些物体
        //然后查看这些物体是否有某个组件而返回出去

        /// <summary>
        /// 筛选方法这个条件通常是是否含有某个组件 比如用findobjsoftag获得了一些物体
        /// 然后查看这些物体是否有某个组件而返回出去
        /// </summary>
        /// <typeparam name="T">传入的数组类型</typeparam>
        /// <typeparam name="Q">需要筛选的组件类型</typeparam>
        /// <param name="array"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public static Q[] Select<T, Q>(this T[] array, Func<T, Q> condition)
        {
            List<Q> list = new List<Q>();
            for (int i = 0; i < array.Length; i++)
            {
                //如果找组件找到了 有这个组件 集合就把这个元素添加进去
                if (condition(array[i]) != null)
                {
                    list.Add(list[i]);
                }
            }

            return list.ToArray();
        }
    }
}

