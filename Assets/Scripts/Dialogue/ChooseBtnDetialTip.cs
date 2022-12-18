using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ChooseBtnDetialTip : MonoBehaviour
{
    public Text TitleText;
    public Text MidleText;
    public Image goodsImage;
    public Image spacialImage;

    public void ShowChooseDetailTip(ChooseBtn chooseBtn)
    {
        switch (chooseBtn.BtnType)
        {
            case ChooseBtnType.simple:
                if(chooseBtn.chooseImage!=null)
                {
                    spacialImage.DOFade(1, 0.5f);
                }

                if (chooseBtn.goods != null)
                {
                    goodsImage.gameObject.SetActive(true);
                    goodsImage.sprite = chooseBtn.goods.itemImg;
                }
                else
                {
                    goodsImage.gameObject.SetActive(false);
                }

                TitleText.gameObject.SetActive(true);
                MidleText.gameObject.SetActive(true);


                TitleText.text = "财富变化：" + chooseBtn.WealthChange.ToString();
                MidleText.text = "信用变化：" + chooseBtn.CreditChange.ToString();
                break;
            case ChooseBtnType.guide:
                TitleText.gameObject.SetActive(true);
                TitleText.text = "进行引导";
                break;
        }
    }
}