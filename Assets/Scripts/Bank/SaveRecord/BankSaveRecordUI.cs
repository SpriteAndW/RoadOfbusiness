using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BankSaveRecordUI : MonoBehaviour
{
    public SaveRecordDetail currentRecord;

    [Header("对应文本组件获取")] public TextMeshProUGUI saveTimeText;
    public TextMeshProUGUI saveMoneyText;
    public TextMeshProUGUI saveTypeText;
    public TextMeshProUGUI takeTimeText;
    public TextMeshProUGUI takeMoneyText;
    public TextMeshProUGUI getMoneyText;
    public TextMeshProUGUI FinalGetMoneyText;

    [Header("取款按钮")] public Button takeMoneyBtn;


    private void OnEnable()
    {
        EventHandler.UpdateBankSaveRecordUIEvent += OnUpdateBankSaveRecordUIEvent;
    }

    private void OnDisable()
    {
        EventHandler.UpdateBankSaveRecordUIEvent -= OnUpdateBankSaveRecordUIEvent;
    }


    /// <summary>
    /// 更新存款记录显示详情,更新取款按钮显示
    /// </summary>
    /// <param name="saveRecordDetail">存款详情</param>
    private void OnUpdateBankSaveRecordUIEvent(SaveRecordDetail saveRecordDetail)
    {
        saveTimeText.text = BankManager.Instance.GetTimeOnDay(saveRecordDetail.saveTime);
        saveMoneyText.text = saveRecordDetail.saveMoney.ToString();
        saveTypeText.text = saveRecordDetail.saveType.ToString();
        takeTimeText.text = BankManager.Instance.GetTimeOnDay(saveRecordDetail.takeTime);
        takeMoneyText.text = saveRecordDetail.takeMoney.ToString();
        getMoneyText.text = saveRecordDetail.getMoney.ToString() + "=" +
                            (saveRecordDetail.saveMoney * saveRecordDetail.getMoney).ToString();
        FinalGetMoneyText.text = saveRecordDetail.finalGetMoney.ToString();


        currentRecord = saveRecordDetail;

        //切换按钮能否按下
        if (currentRecord.takeTime < Business.Instance.playDays)
        {
            takeMoneyBtn.interactable = true;
        }
        else
        {
            takeMoneyBtn.interactable = false;
        }
    }


    public void TakeSaveMoneyOnBank()
    {
        Business.Instance.wealth += currentRecord.saveMoney;
        BankManager.Instance.saveMoney -= currentRecord.saveMoney;
        if (BankManager.Instance.saveRecordDetailList.savrRecordList.Contains(currentRecord))
        {
            BankManager.Instance.saveRecordDetailList.savrRecordList.Remove(currentRecord);
            
            gameObject.transform.GetComponentInParent<BankUI>().OpenSaveRecordPanle(true);
            EmptyRecordUI();
            GameController.Instance.Refresh();
        }
    }

    public void EmptyRecordUI()
    {
        saveTimeText.text = String.Empty;
        saveMoneyText.text = String.Empty;
        saveTypeText.text = String.Empty;
        takeTimeText.text = String.Empty;
        takeMoneyText.text = String.Empty;
        getMoneyText.text = String.Empty;
        FinalGetMoneyText.text = String.Empty;
    }
}