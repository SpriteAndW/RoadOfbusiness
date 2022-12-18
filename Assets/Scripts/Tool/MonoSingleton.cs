using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����һ��������
/// �̳���mono�ĵ�����
/// ������̳���������
/// </summary>
public class MonoSingleton<T> : MonoBehaviour where T: MonoSingleton<T>
{
    private static T instance;
    public static T Instance 
    {
        get
        {
            //���ֶ�instance���س�ȥ �����ֶ�instance���ܻ�û��ֵ
            //��Ϊ��������Ǿ�̬�� ���Բ���ֱ��return this����һ������
            if (instance == null)
            {
                //һ��ʼ��û��ֵinstance��null
                instance = FindObjectOfType<T>();
                //�������֮���ǿգ��������ű�û�й����������ϣ�

                if(instance == null)
                {
                    //����Ϸ��������
                    new GameObject("Singleton of " + typeof(T)).AddComponent<T>();

                }
                else
                {
                    //�������������ȻΪ�� �ᴴ������ ��Awake��������Init
                    instance.Init();
                }
                
            }
            return instance;
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            //�������ű����Լ��ֶ����������ϵ� ��ô���������Ѷ��󷵻���ȥ
            instance = this as T;
            Init();
        }
    }

    protected virtual void Init()
    {
        //����һ����ʼ������
        //�̳�����������Ķ��󶼻����һ���������

        //�ѵ���������Ϊ��������ɾ��
        DontDestroyOnLoad(this.gameObject);
        
    }
    
}
