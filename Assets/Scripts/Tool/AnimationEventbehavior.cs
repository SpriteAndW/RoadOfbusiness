using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tool
{
    /// <summary>
    /// �����¼�������Ϊ
    /// ��������¼�ί��
    /// ���Ҫ��������������Ϸ�������� 
    /// ��Ȼ�Ļ������¼�ֻ��ִ�й���ģ���ϵķ���
    /// </summary>
    public class AnimationEventbehavior : MonoBehaviour
    {
        public delegate void AnimationEvent();

        public event AnimationEvent OnAttackHandler;
        public event AnimationEvent OnAnimationEnd;

        public void AttackHandler()
        {
            OnAttackHandler.Invoke();
        }

        public void AnimationEnd()
        {
            OnAnimationEnd.Invoke();
        }
    }

}
