using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageText : MonoBehaviour
{

    public Text mesText;
    public Image img;
    public Image itemImg;

    public void ShowMessage(string text)
    {
        gameObject.SetActive(true);
        mesText.text = text;
        itemImg.color = new Vector4(0, 0, 0, 0);
        img.color = Color.white;
        mesText.color = Color.black;
        StartCoroutine(Fade(false));
    }
    public void ShowMessage(string text, Sprite itemImg)
    {
        gameObject.SetActive(true);
        this.itemImg.sprite = itemImg;
        mesText.text = text;
        this.itemImg.color = Color.white;
        img.color = Color.white;
        mesText.color = Color.black;
        StartCoroutine(Fade(true));
    }

    public IEnumerator Fade(bool isImg)
    {
        while(img.color.a > 0)
        {
            float a = img.color.a;
            if (isImg)
            {
                itemImg.color = new Vector4(1, 1, 1, a - 0.005f);
            }
            img.color = new Vector4(1, 1, 1, a - 0.005f);

            mesText.color = new Vector4(0, 0, 0, a - 0.005f);
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
