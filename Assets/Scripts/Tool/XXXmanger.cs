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
            //���yield returnдnull ÿ��update����һ��
            print("���ǵ�" + i + "��-----��" + Time.frameCount + "֡");
            i--;
            yield return null;
        }
    }

}