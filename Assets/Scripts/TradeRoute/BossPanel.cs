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
        description.text = string.Format("{0}想要成为你的{1}供货商,给你提供{2}个{1},花费{3}财富值\n{0}:{4}", boss.bossName,boss.tradeItem.itemName, rand, rand*boss.tradeItem.price*0.8f,boss.description);
        transform.position = Input.mousePosition;
    }

    public void Accept()
    {
        if (boss.isRec)
        {
            MessageWindow.Instance.ShowMessage("本回合已经交易过了");
            return;
        }
        if(Business.Instance.wealth >= rand * boss.tradeItem.price)
        {
            Business.Instance.wealth -= rand * boss.tradeItem.price;
            MessageWindow.Instance.ShowMessage("交易成功！", boss.tradeItem.itemImg);
            //如果是在剧情中的老板（有女儿的那种）

            //亲密度+1
            boss.intimacy += 1;
            
            boss.isRec = true;
            gameObject.SetActive(false);
        }
        else
        {
            MessageWindow.Instance.ShowMessage("你的财富值不够;");
        }
    }

    public void Cancel()
    {
        gameObject.SetActive(false);
    }
}
