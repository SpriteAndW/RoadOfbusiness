using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UIFrameWork
{
    //管理所有同时出现的面板对象，采用堆栈模式
    public class PanelManager : SingletonBase<PanelManager>
    {
        private Stack<BasePanel> stackPanel = new Stack<BasePanel>();
        //添加一个面板
        public void Push(BasePanel nextPanel)//加入
        {
            if (nextPanel == null)
                return;
            if (stackPanel.Count > 0)//添加新面板时，顶部面板要调用OnPause
            {
                BasePanel topPanel = stackPanel.Peek();
                topPanel.OnPause();
            }
            stackPanel.Push(nextPanel);
            GameObject panel = UIManager.Instance.GetSingleUI(nextPanel.UIType);
            nextPanel.OnEnter();
        }

        public void Pop()//弹出
        {
            if (stackPanel.Count > 0)
                stackPanel.Pop().OnExit();//当前面板要调用OnExit
            if (stackPanel.Count > 0)
                stackPanel.Peek().OnResume();//下一层面板要调用OnResume
        }

        public void Clear()//清理
        {
            while (stackPanel.Count > 0)
                stackPanel.Pop().OnExit();//每一个面板要调用OnExit
        }
    }
}

