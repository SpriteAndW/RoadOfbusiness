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
    /// ���ɾ��� ͨ��һ���ļ�
    /// </summary>
    /// <param name="plotName"></param>
    public void GeneratePlot(string plotName)
    {
        plotW = UIManger.Instance.Getwindows<PlotWindow>();
        string plot = ResourcesManger.GetConfigfile(plotName);
        PlotAnalysis(plot);
        //���⴦������ı��������б�plotList����
        //����һ�����鴰��PlotWindow
        plotW.GeneratePlot(plotList);
    }


    /// <summary>
    /// �������� ���ı�����ʽ�ֿ� �浽�ֵ�����
    /// </summary>
    /// <param name="plot">�����ı�  ��ʽ�ǽ�ɫ��:��ɫ˵�Ļ�</param>
    public void PlotAnalysis(string plot)
    {
        using (StringReader reader = new StringReader(plot))
        {
            //reader.Dispose stringreader�Ľ�������
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                //��ÿһ�ж����뵽�б�����
                plotList.Add(line);
            }
        }
    }
}
