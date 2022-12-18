using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class WelcomeAnimator : MonoBehaviour
{
    public float fadeTime = 1f;
    public CanvasGroup canvasGroup;
    public Image backGround;
    public Image titlePicture;
    public RectTransform rectTransform;
    public RectTransform titleRectT;

    public void Start()
    {
        PanelFadeIn();
    }

    public void PanelFadeIn()
    {
        backGround.color = new Color(255,255,255,0f);
        backGround.DOFade(1, fadeTime);

        canvasGroup.alpha = 0f;
        canvasGroup.DOFade(1, fadeTime);

        rectTransform.transform.localPosition = new Vector3(-300f,-270f,0f);
        rectTransform.DOAnchorPos(new Vector2(0f, -270f), fadeTime, false).SetEase(Ease.OutElastic) ;
        
        titleRectT.transform.localPosition = new Vector3(300f, 200f, 0f);
        titleRectT.DOAnchorPos(new Vector2(0f,200f),fadeTime,false).SetEase(Ease.OutSine);
    }

    public void PanelFadeOut()
    {

        titleRectT.transform.localPosition = new Vector3(0f, 200f, 0f);
        titleRectT.DOAnchorPos(new Vector2(300f, 200f), fadeTime, false).SetEase(Ease.OutSine);

        rectTransform.transform.localPosition = new Vector3(0f, -270f, 0f);
        rectTransform.DOAnchorPos(new Vector2(-300f, -270f), fadeTime, false).SetEase(Ease.InOutQuint);

        canvasGroup.alpha = 1f;
        canvasGroup.DOFade(0, fadeTime);

        backGround.color = new Color(255, 255, 255, 1f);
        backGround.DOFade(0,fadeTime);
    }

}
