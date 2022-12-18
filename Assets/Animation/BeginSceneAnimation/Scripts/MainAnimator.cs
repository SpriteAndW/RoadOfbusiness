using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainAnimator : MonoBehaviour
{
    public float fadeTime = 1f;
    public CanvasGroup InformationG;

    public void Start()
    {
        FadeIn();
    }

    public void FadeIn()
    {
        InformationG.alpha = 0f;
        //InformationG.DOFade();
    }
}
