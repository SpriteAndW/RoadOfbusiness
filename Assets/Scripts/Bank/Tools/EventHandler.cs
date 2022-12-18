using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class EventHandler
{
    /// <summary>
    /// 更新钱庄UI
    /// </summary>
    public static event Action UpdateBankUIEvent;

    public static void CallUpdateBankUIEvent()
    {
        UpdateBankUIEvent?.Invoke();
    }

    
    /// <summary>
    /// 更新钱庄存款UI与交易信息
    /// </summary>
    public static event Action<SaveTradeDetail> UpdateBankSaveMoneyUIEvent;

    public static void CallUpdateBankSaveMoneyUIEvent(SaveTradeDetail saveTradeDetail)
    {
        UpdateBankSaveMoneyUIEvent?.Invoke(saveTradeDetail);
    }

    /// <summary>
    /// 更新存款记录详细信息
    /// </summary>
    public static event Action<SaveRecordDetail> UpdateBankSaveRecordUIEvent;

    public static void CallUpdateBankSaveRecordUIEvent(SaveRecordDetail saveRecordDetail)
    {
        UpdateBankSaveRecordUIEvent?.Invoke(saveRecordDetail);
    }

    
    /// <summary>
    /// 更新借款后事件
    /// </summary>
    public static event Action<BorrowTradeDetail> UpdateBankBorrowEvent;

    public static void CallUpdateBankBorrowEvent(BorrowTradeDetail borrowTradeDetail)
    {
        UpdateBankBorrowEvent?.Invoke(borrowTradeDetail);
    }

    
    /// <summary>
    /// 存款发放利息事件
    /// </summary>
    public static event Action<List<SaveTradeDetail>> GetMoneyOnSaveBankEvent;

    public static void CallGetMoneyOnSaveBankEvent(List<SaveTradeDetail> saveTradeDetailList)
    {
        GetMoneyOnSaveBankEvent?.Invoke(saveTradeDetailList);
    }

    /// <summary>
    /// 还款一次更新一次贷款详情
    /// </summary>
    public static event Action<BorrowTradeDetail> UpdateBorrowTradeDetailEvent;

    public static void CallUpdateBorrowTradeDetailEvent(BorrowTradeDetail borrowTradeDetail)
    {
        UpdateBorrowTradeDetailEvent?.Invoke(borrowTradeDetail);
    }

    /// <summary>
    /// 剧情UI
    /// </summary>
    public static event Action<DialogueDetial, DialoguePiece, bool> UpdateDialogueUIEvent;

    public static void CallUpdateDialogueUIEvent(DialogueDetial dialogueDetial, DialoguePiece dialoguePiece, bool isfirst)
    {
        UpdateDialogueUIEvent?.Invoke(dialogueDetial, dialoguePiece, isfirst);
    }


    /// <summary>
    /// 显示对话UI
    /// </summary>
    public static event Action<DialogueDetial> ShowDialogueEvent;
    public static void CallShowDialogueEvent(DialogueDetial dialogueDetial)
    {
        ShowDialogueEvent?.Invoke(dialogueDetial);
    }
    
    /// <summary>
    /// 显示选项UI
    /// </summary>
    public static event Action<DialogueDetial> ShowChooseEvent;

    public static void CallShowChooseEvent(DialogueDetial dialogueDetial)
    {
        ShowChooseEvent?.Invoke(dialogueDetial);
    }

    /// <summary>
    /// 场景加载事件,目前只有音乐播放 + fade动画
    /// </summary>
    public static event Action<string> AfterSceneLoadeEvent;

    public static void CallAfterSceneLoadeEvent(string sceneName)
    {
        AfterSceneLoadeEvent?.Invoke(sceneName);
    }

    /// <summary>
    /// 播放音效事件
    /// </summary>
    public static event Action<SoundType> PlayEffectEvent;

    public static void CallPlayEffectEvent(SoundType soundType)
    {
        PlayEffectEvent?.Invoke(soundType);
    }

    /// <summary>
    /// 引导功能
    /// </summary>
    public static event Action<String> ShowGuideOnSceneName;

    public static void CallShowGuideOnSceneName(string sceneName)
    {
        ShowGuideOnSceneName?.Invoke(sceneName);
    }

    public static event Action ShowGameOver;

    public static void CallShowGameOver()
    {
        ShowGameOver?.Invoke();
    }



}
