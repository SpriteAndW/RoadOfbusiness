using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewGameTipController : MonoBehaviour
{
    public void BtnOneEvent()
    {
        if (Business.Instance.wealth>=100000)
        {
            Business.Instance.wealth -= 100000;
            //TODO:添加一个商铺
            Debug.Log("店铺增加");
            
            GameController.Instance.Refresh();
            Destroy(this.gameObject);
        }
        else
        {
            transform.GetChild(0).GetChild(2).GetComponent<Button>().interactable = false;
            transform.GetChild(0).GetChild(2).GetComponentInChildren<Text>().text = "铜币不够";
            transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
            transform.GetChild(0).GetChild(4).gameObject.SetActive(true);

        }
    }

    public void BtnTwoEvent()
    {
        SceneManager.LoadScene("Scene2",LoadSceneMode.Single);
        // gameObject.SetActive(false);
        
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
    }

    public void OpenAndClose(bool isOpen)
    {
        transform.GetChild(0).GetChild(2).GetComponent<Button>().interactable = true;
        transform.GetChild(0).GetChild(2).GetComponentInChildren<Text>().text = "点击购买";

        transform.GetChild(0).gameObject.SetActive(isOpen);
        transform.GetChild(1).gameObject.SetActive(!isOpen);
    }
}