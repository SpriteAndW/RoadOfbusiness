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
    /// �����
    /// ����ֱ����instantiate����
    /// ��Ҫ����˼����������������destroyɾ�� ��������һ��������������
    /// Ȼ�����嶼�����һ���б��� �б��ִ����ֵ��� �ֵ�ļ�������������Ԥ�Ƽ�����
    /// </summary>
    public class ObjectPool : MonoSingleton<ObjectPool>
    {
        public Dictionary<string, List<GameObject>> Pool;
        protected override void Init()
        {
            base.Init();
            //��ʼ��һ���ֵ�
            Pool = new Dictionary<string, List<GameObject>>();
        }

        public GameObject CreateObject(string key, GameObject prefab,
            Vector3 pos, Quaternion rotation)
        {
            GameObject go;
            //����ֵ���������������б�
            if (Pool.ContainsKey(key))
            {
                //������������ �ж����key�ļ����Ƿ�������������ò����õ�
                if((go = Pool[key].Find(a=>a.activeInHierarchy == false)) != null)
                {
                    //����ҵ�һ��û���õ� �ͷ��س�ȥ ���Ұ�������Ϊ���õ�
                    go.SetActive(true);
                }
                else
                {
                    //���û�ҵ�û���õ� �����ӵ��������� ������һ�� ���Ҽ��뵽�����������
                    go = Instantiate<GameObject>(prefab);
                    Pool[key].Add(go);
                }
            }

            //����ֵ����滹û�������
            else
            {
                //�ֵ�����һ���µļ��� ���ֽ����Ԥ�Ƽ�������
                Pool.Add(key, new List<GameObject>());
                //������һ��Ԥ�Ƽ�
                go = Instantiate<GameObject>(prefab);
                //�������ɵ�Ԥ�Ƽ����뵽�ֵ��½��ļ�������
                Pool[key].Add(go);
            }
            go.transform.position = pos;
            go.transform.rotation = rotation;
            //��Ϊgo������϶���һ���̳���IRestable�� �����getcomponent�����ҵ���������������
            //Ȼ����������reset���� �����ж�����Ҫreset �����ҵ����� Ȼ�����ִ��һ��
            foreach (var item in go.GetComponents<IResetable>())
            {
                //������IResetable�ӿڵ����������һ��reset
                item.Reset();
            }
            return go;
            
        }

        /// <summary>
        /// ���ն��� �����ӳ�
        /// </summary>
        /// <param name="go"></param>
        public void CollectObject(GameObject go, float delaytime=0)
        {
            //�ӳ�һ��ʱ��
            StartCoroutine(Delay(go, delaytime));
            //������д�Ĵ��붼��ֱ��ִ�е�
            
        }

        private IEnumerator Delay(GameObject go, float delaytime)
        {
            yield return new WaitForSeconds(delaytime);
            //���������õķ��������ӳٺ��ִ�е�
            go.SetActive(false);
        }


        /// <summary>
        /// �������ڶ���ص�key������Ǹ�����
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
        /// ������ж���ش���������
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
