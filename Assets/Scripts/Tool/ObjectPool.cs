using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IResetable 
{
    public void Reset();
}


namespace Tool
{
    /// <summary>
    /// 对象池
    /// 代替直接用instantiate生成
    /// 主要核心思想就是生成物体后不用destroy删掉 而是用另一个方法将他隐藏
    /// 然后物体都会存在一个列表中 列表又存在字典中 字典的键则是这个对象的预制件名字
    /// </summary>
    public class ObjectPool : MonoSingleton<ObjectPool>
    {
        public Dictionary<string, List<GameObject>> Pool;
        protected override void Init()
        {
            base.Init();
            //初始化一下字典
            Pool = new Dictionary<string, List<GameObject>>();
        }

        public GameObject CreateObject(string key, GameObject prefab,
            Vector3 pos, Quaternion rotation)
        {
            GameObject go;
            //如果字典里面有这个键的列表
            if (Pool.ContainsKey(key))
            {
                //好像是这样的 判断这个key的集合是否有在面板在设置不启用的
                if((go = Pool[key].Find(a=>a.activeInHierarchy == false)) != null)
                {
                    //如果找到一个没启用的 就返回出去 并且把他设置为启用的
                    go.SetActive(true);
                }
                else
                {
                    //如果没找到没启用的 即是子弹不够用了 就生成一个 并且加入到这个集合里面
                    go = Instantiate<GameObject>(prefab);
                    Pool[key].Add(go);
                }
            }

            //如果字典里面还没有这个键
            else
            {
                //字典生成一个新的集合 名字叫这个预制件的名字
                Pool.Add(key, new List<GameObject>());
                //新生成一个预制件
                go = Instantiate<GameObject>(prefab);
                //把新生成的预制件加入到字典新建的集合里面
                Pool[key].Add(go);
            }
            go.transform.position = pos;
            go.transform.rotation = rotation;
            //因为go的组件肯定有一个继承自IRestable的 用这个getcomponent可以找到这个类的子类的组件
            //然后调用里面的reset方法 可能有多个组件要reset 所以找到所有 然后遍历执行一遍
            foreach (var item in go.GetComponents<IResetable>())
            {
                //所以有IResetable接口的组件都调用一下reset
                item.Reset();
            }
            return go;
            
        }

        /// <summary>
        /// 回收对象 可以延迟
        /// </summary>
        /// <param name="go"></param>
        public void CollectObject(GameObject go, float delaytime=0)
        {
            //延迟一段时间
            StartCoroutine(Delay(go, delaytime));
            //在这里写的代码都是直接执行的
            
        }

        private IEnumerator Delay(GameObject go, float delaytime)
        {
            yield return new WaitForSeconds(delaytime);
            //在这里设置的方法才是延迟后才执行的
            go.SetActive(false);
        }


        /// <summary>
        /// 根绝存在对象池的key来清除那个数组
        /// </summary>
        /// <param name="key"></param>
        public void Clear(string key)
        {
            foreach (var item in Pool[key])
            {
                Destroy(item);
            }
            Pool.Remove(key);
        }


        /// <summary>
        /// 清除所有对象池创建的物体
        /// </summary>
        public void ClearAll()
        {
            foreach (var key in new List<string>(Pool.Keys))
            {
                Clear(key);
            }
        }
    }

}
