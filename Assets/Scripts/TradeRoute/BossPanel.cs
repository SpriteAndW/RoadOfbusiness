using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossPanel : MonoBehaviour
{
    public BusinessItem boss;
    public Text description;
    public Button recBut;
    public Button canBut;
    public Image itemImg;
    public int rand;
    public void Refresh()
    {
        rand = Random.Range(1000, 2000);

        itemImg.sprite = boss.tradeItem.itemImg;
        description.text = string.Format("{0}��Ҫ��Ϊ���{1}������,�����ṩ{2}��{1},����{3}�Ƹ�ֵ\n{0}:{4}", boss.bossName,boss.tradeItem.itemName, rand, rand*boss.tradeItem.price*0.8f,boss.description);
        transform.position = Input.mousePosition;
    }

    public void Accept()
    {
        if (boss.isRec)
        {
            MessageWindow.Instance.ShowMessage("���غ��Ѿ����׹���");
            return;
        }
        if(Business.Instance.wealth >= rand * boss.tradeItem.price)
        {
            Business.Instance.wealth -= rand * boss.tradeItem.price;
            MessageWindow.Instance.ShowMessage("���׳ɹ���", boss.tradeItem.itemImg);
            //������ھ����е��ϰ壨��Ů�������֣�

            //���ܶ�+1
            boss.intimacy += 1;
            
            boss.isRec = true;
            gameObject.SetActive(false);
        }
        else
        {
            MessageWindow.Instance.ShowMessage("��ĲƸ�ֵ����;");
        }
    }

    public void Cancel()
    {
        gameObject.SetActive(false);
    }
}
