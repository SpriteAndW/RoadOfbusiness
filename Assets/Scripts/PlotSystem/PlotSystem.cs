using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlotSystem : MonoSingleton<PlotSystem>
{
    private List<string> plotList;
    private PlotWindow plotW;

    protected override void Init()
    {
        base.Init();
        plotList = new List<string>();
    }
    /// <summary>
    /// 生成剧情 通过一个文件
    /// </summary>
    /// <param name="plotName"></param>
    public void GeneratePlot(string plotName)
    {
        plotW = UIManger.Instance.Getwindows<PlotWindow>();
        string plot = ResourcesManger.GetConfigfile(plotName);
        PlotAnalysis(plot);
        //到这处理过的文本存在了列表plotList里面
        //在做一个剧情窗口PlotWindow
        plotW.GeneratePlot(plotList);
    }


    /// <summary>
    /// 解析剧情 把文本按格式分开 存到字典里面
    /// </summary>
    /// <param name="plot">剧情文本  格式是角色名:角色说的话</param>
    public void PlotAnalysis(string plot)
    {
        using (StringReader reader = new StringReader(plot))
        {
            //reader.Dispose stringreader的结束方法
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                //把每一行都加入到列表里面
                plotList.Add(line);
            }
        }
    }
}
