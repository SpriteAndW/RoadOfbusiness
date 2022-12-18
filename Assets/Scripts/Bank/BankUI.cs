using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BankUI : UIWindows
{
    [Header("组件获取")] public TradeUI borrowTradeUI;
    public BankBorrowDetailUI borrowTradeDetailUI;
    public TradeUI saveTradeUI;
    public BankSaveRecordUI bankSaveRecordUI;
    
    [Header("引导面板")]
    public GameObject BorrowGuide;

    [Header("对话框文本")] public Text DialogueText;

    [Header("按钮选项")] public Button borrowMoneyBtn;
    public Button borrowTimeBtn;
    public Button saveMoneyBtn;
    public Button saveTimeBtn;


    [Header("存款记录组件获取")] public Transform recordParent;
    public GameObject recordPrefab;


    private void Start()
    {
        //值为1不执行
        if (PlayerPrefs.GetInt(Const.BankNovice, 0) == 0)
        {
            BorrowGuide.SetActive(true);
        }
    }


    private void OnEnable()
    {
        EventHandler.UpdateBankSaveMoneyUIEvent += OnUpdateBankSaveMoneyUIEvent;
        EventHandler.UpdateBankBorrowEvent += OnUpdateBankBorrowEvent;
        EventHandler.UpdateBorrowTradeDetailEvent += OnUpdateBorrowTradeDetailEvent;
        EventHandler.UpdateBankUIEvent += OnUpdateBankUIEvent;

        OpenAndCloseBankPanleUI();
    }

    private void OnDisable()
    {
        EventHandler.UpdateBankSaveMoneyUIEvent -= OnUpdateBankSaveMoneyUIEvent;
        EventHandler.UpdateBankBorrowEvent -= OnUpdateBankBorrowEvent;
        EventHandler.UpdateBorrowTradeDetailEvent -= OnUpdateBorrowTradeDetailEvent;
        EventHandler.UpdateBankUIEvent -= OnUpdateBankUIEvent;
    }


    /// <summary>
    /// 存钱后更新UI和添加存钱记录
    /// </summary>
    /// <param name="saveTradeDetail">存钱详细</param>
    private void OnUpdateBankSaveMoneyUIEvent(SaveTradeDetail saveTradeDetail)
    {
        BankManager.Instance.saveMoney += saveTradeDetail.saveMoney;

        saveTradeUI.gameObject.SetActive(false);
        UpdateBankBtnUI();

        BankManager.Instance.saveRecordDetailList.savrRecordList.Add(
            BankManager.Instance.GetSaveRecordDetail(saveTradeDetail));
    }


    /// <summary>
    /// 贷款后更新UI
    /// </summary>
    /// <param name="borrowTradeDetail"></param>
    private void OnUpdateBankBorrowEvent(BorrowTradeDetail borrowTradeDetail)
    {
        //更新贷款详情
        borrowTradeDetailUI.GetBorrowTradeDeatil(borrowTradeDetail);

        //更新UI
        UpdateBankBtnUI();
    }

    /// <summary>
    /// 更新贷款中还需还款数值,并更新UI
    /// </summary>
    /// <param name="borrowTradeDetail">贷款详情</param>
    private void OnUpdateBorrowTradeDetailEvent(BorrowTradeDetail borrowTradeDetail)
    {
        borrowTradeUI.borrowTradeDetail = borrowTradeDetail;
        //更新BanUI按钮文字显示
        UpdateBankBtnUI();
    }


    private void OnUpdateBankUIEvent()
    {
        OpenAndCloseBankPanleUI();
    }


    /// <summary>
    /// 根据人物信用等级显示不同对话
    /// </summary>
    private void UpdateDialogue()
    {
        DialogueText.text = string.Empty;
        switch (BankManager.Instance.creditLevel)
        {
            case CreditLevel.低:
                DialogueText.DOText("你的信用值太低了，无法在我店贷款", 1f);
                break;
            case CreditLevel.一般:
                DialogueText.DOText("你的信用可以办理这些套餐，不过可得记得按时还钱", 1f);
                break;
            case CreditLevel.良好:
                DialogueText.DOText("让我为您介绍一下本店的业务", 1f);
                break;
            case CreditLevel.优秀:
                DialogueText.DOText("您的到来真是让我们蓬荜生辉", 1f);
                break;
        }
    }


    /// <summary>
    /// 更新button的Text文本
    /// </summary>
    public void UpdateBankBtnUI()
    {
        borrowTradeUI.borrowTradeDetail = BankManager.Instance.borrowTradeDetail;
        //如果借款没有还清,无法继续贷款
        if (borrowTradeUI.borrowTradeDetail.needBakeMoney > 0)
        {
            borrowMoneyBtn.interactable = false;
            borrowTimeBtn.interactable = true;
        }
        else
        {
            borrowMoneyBtn.interactable = true;
            borrowTimeBtn.interactable = false;
        }

        if (borrowTradeUI.borrowTradeDetail.needBakeMoney <= 0)
        {
            borrowMoneyBtn.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "我要贷款";
            borrowTimeBtn.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "当前无贷款";

            //信用低无法贷款
            if (BankManager.Instance.creditLevel == CreditLevel.低)
            {
                borrowMoneyBtn.interactable = false;
                borrowMoneyBtn.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "信用太低无法贷款";
            }
        }
        else
        {
            borrowMoneyBtn.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                "还需还款:" + borrowTradeUI.borrowTradeDetail.needBakeMoney.ToString();

            borrowTimeBtn.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                "还款时间:" + BankManager.Instance.GetTimeOnDay(borrowTradeUI.borrowTradeDetail.bakeTime);
        }

        saveMoneyBtn.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
            "存储余额:" + BankManager.Instance.saveMoney.ToString();
    }

    /// <summary>
    /// 打开和关闭BankUI
    /// </summary>
    /// <param name="isOpen">是否打开</param>
    public void OpenAndCloseBankPanleUI()
    {
        //OpenPanelBtn.gameObject.SetActive();
        // SetVisible(false);

        BankManager.Instance.UpdateCreditLevel();

        UpdateDialogue();
        UpdateBankBtnUI();
    }

    public void OpenBorrowMoneyPanle()
    {
        borrowTradeUI.gameObject.SetActive(true);
        borrowTradeUI.slider.value = 0;
        borrowTradeUI.UpdateBorrowTradeUI();
        
        if (DialogueManager.instance.isBankGuideing)
            NoviceGuidePanel._instance.NextStep(BankGuideConst.BeginBorrow);
    }

    public void OpenBorrowwDetailPanle(bool isOpen)
    {
        borrowTradeDetailUI.gameObject.SetActive(isOpen);
        
        //每次打开刷新UI
        borrowTradeDetailUI.GetBorrowTradeDeatil(BankManager.Instance.borrowTradeDetail);

        
        if (DialogueManager.instance.isBankGuideing)
        {
            if (isOpen)
            {
                NoviceGuidePanel._instance.NextStep(BankGuideConst.ShowBorrowDetail);
            }
            else
            {
                NoviceGuidePanel._instance.NextStep(BankGuideConst.CloseBorrowDetail);
                FinashGuide();
            }
        }
    }

    /// <summary>
    /// 提前还款
    /// </summary>
    public void BackMoney()
    {
        //如果玩家财富少于提前还款的钱,不执行

        if (Business.Instance.wealth < BankManager.Instance.borrowTradeDetail.needBakeMoney)
        {
            return;
        }

        Business.Instance.wealth -= BankManager.Instance.borrowTradeDetail.needBakeMoney;

        Debug.Log("财富变化(提前还款):" + -BankManager.Instance.borrowTradeDetail.needBakeMoney);
        Debug.Log("当前财富:" + Business.Instance.wealth);


        borrowTradeUI.borrowTradeDetail = new BorrowTradeDetail();
        BankManager.Instance.borrowTradeDetail = new BorrowTradeDetail();

        //刷新UI
        GameController.Instance.Refresh();

        OpenBorrowwDetailPanle(false);
        UpdateBankBtnUI();
    }


    /// <summary>
    /// 打开存钱SaveUI
    /// </summary>
    public void OpenSaveMoneyPanle()
    {
        saveTradeUI.gameObject.SetActive(true);
        saveTradeUI.slider.value = 0;
        saveTradeUI.UpdateSaveTradeUI();

        if (DialogueManager.instance.isBankGuideing)
        {
            NoviceGuidePanel._instance.NextStep(BankGuideConst.BeginSave);
        }
    }

    /// <summary>
    /// 打开存款记录SaveRecordUI
    /// </summary>
    /// <param name="isOpen">是否打开</param>
    public void OpenSaveRecordPanle(bool isOpen)
    {
        bankSaveRecordUI.gameObject.SetActive(isOpen);

        if (isOpen)
        {
            //耗费性能...(对象池创建)
            for (int i = 0; i < recordParent.childCount; i++)
            {
                Destroy(recordParent.transform.GetChild(i).gameObject);
            }

            foreach (var saveRecord in BankManager.Instance.saveRecordDetailList.savrRecordList)
            {
                //在存款记录UI添加一个记录
                var obj = Instantiate(recordPrefab, recordParent);

                obj.GetComponent<BankSaveRecordBtn>().saveRecordDetail = saveRecord;
                obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                    BankManager.Instance.GetTimeOnDay(obj.GetComponent<BankSaveRecordBtn>().saveRecordDetail.saveTime);
            }
            
            if (DialogueManager.instance.isBankGuideing)
                NoviceGuidePanel._instance.NextStep(BankGuideConst.ShowSaveDetail);
        }
        else
        {
            if (DialogueManager.instance.isBankGuideing)
                NoviceGuidePanel._instance.NextStep(BankGuideConst.CloseSaveDetail);
        }

        UpdateBankBtnUI();
        bankSaveRecordUI.EmptyRecordUI();
    }


    public void FinashGuide()
    {
        PlayerPrefs.SetInt(Const.BankNovice, 1);
        Business.Instance.wealth -= 15000;
        //刷新UI
        GameController.Instance.Refresh();
    }

    public void BakeMainScene()
    {
        EventHandler.CallAfterSceneLoadeEvent("MainScene");
        // SceneManager.LoadScene("MainScene");
    }
}