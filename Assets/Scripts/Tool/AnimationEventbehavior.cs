using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tool
{
    /// <summary>
    /// 动画事件工具行为
    /// 定义各种事件委托
    /// 这个要挂在做动画的游戏的物体上 
    /// 不然的话动画事件只能执行挂在模型上的方法
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
