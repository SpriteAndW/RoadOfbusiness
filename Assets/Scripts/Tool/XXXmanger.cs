using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XXXmanger : MonoSingleton<XXXmanger>
{
    public void fun1()
    {
        print("fun1");
    }

    protected override void Init()
    {
        StartCoroutine(Sb());
    }

    private IEnumerator Sb()
    {
        int i = 100;
        while(i >= 0)
        {
            //如果yield return写null 每次update调用一次
            print("这是第" + i + "次-----第" + Time.frameCount + "帧");
            i--;
            yield return null;
        }
    }

}