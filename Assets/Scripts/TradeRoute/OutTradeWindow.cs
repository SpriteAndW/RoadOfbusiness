using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutTradeWindow : UIFunctionWindow
{
    //任务栏 里面有一个列表
    public TradeDelegateBar deleBar;
    //任务的预制件
    public GameObject delePrefab;
    public Transform grid;
    // public Scrollbar scroB;
    protected override void Start()
    {
        base.Start();
        GeneraRandomDele();
    }

    public void Refresh()
    {
        //先把所有都删除了
        for (int i = 0; i < grid.childCount; i++)
        {
            Destroy(grid.GetChild(i).gameObject);
        }
        for (int i = 0; i < deleBar.delegateBar.Count; i++)
        {
            //如果这个任务已经被接受了就不生成UI
            if (!deleBar.delegateBar[i].isAccept)
            {
                GameObject deleGo = Instantiate(delePrefab, grid);
                Delegate dele = deleGo.GetComponent<Delegate>();
                dele.dele = deleBar.delegateBar[i];
                if (dele.dele.isSpecial)
                {
                    dele.GetComponent<Image>().color = Color.yellow;
                    dele.transform.GetChild(0).gameObject.SetActive(true);
                }
                dele.DisplayUIval();
            }

        }
        // scroB.value = 1;

    }

    public void GeneraRandomDele()
    {
        if (GameController.Instance.isFirstDelegate)
        {
            for (int i = 0; i < deleBar.delegateBar.Count; i++)
            {
                if (deleBar.delegateBar[i].isAccept)
                {
                    continue;
                }
                deleBar.delegateBar[i].GenerateRandomDelegate();

            }
            GameController.Instance.isFirstDelegate = false;
        }

    }
}
