using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntimacyColumn : MonoBehaviour
{
    public Marrier marrier;
    public Text marrierName;
    public Text intimacyVal;
    public Slider intimacyCol;

    public void Refresh()
    {
        marrierName.text = marrier.mName;
        intimacyCol.value = 0;
        intimacyCol.DOValue(marrier.intimacy, 1);
    }
    private void Update()
    {
        intimacyVal.text = intimacyCol.value.ToString();
    }
}
