using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;




public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance; //单例

    public DialogueData_SO dialogueData;

    private Queue<DialoguePiece> dialogueQueue;
    private DialogueDetial currentDialogueDetial;
    private bool canPick;
    private bool isFirst = true;

    public List<DialogueDetial> MainDoneDialogue = new List<DialogueDetial>();
    public List<DialogueDetial> BranchDoneDialogue = new List<DialogueDetial>();

    [Header("引导状态")] 
    public bool isBankGuideing;
    public bool isShopGuideing;
    public bool isReceptionGuideing;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                GameObject.Destroy(gameObject);
            }
        }
    }

    /// <summary>
    /// 根据天数ID显示对话
    /// </summary>
    /// <param name="dayID"></param>
    public void ShowDialogueOnDayID(float dayID)
    {
        if (dialogueData.dialogueDetailList.Contains(dialogueData.GetDialogueDetail(dayID)))
        {
            if (dialogueData.GetDialogueDetail(dayID).isMain)
            {
                if (dayID != 0 && !MainDoneDialogue.Contains(dialogueData.GetDialogueDetail(dayID)))
                {
                    EventHandler.CallShowDialogueEvent(dialogueData.GetDialogueDetail(dayID));
                    MainDoneDialogue.Add(dialogueData.GetDialogueDetail(dayID));
                }
            }
            else
            {
                if (dayID != 0 && !BranchDoneDialogue.Contains(dialogueData.GetDialogueDetail(dayID)))
                {
                    EventHandler.CallShowDialogueEvent(dialogueData.GetDialogueDetail(dayID));
                    BranchDoneDialogue.Add(dialogueData.GetDialogueDetail(dayID));
                }
            }

        }
    }


    private void OnEnable()
    {
        EventHandler.ShowDialogueEvent += OnShowDialogueEvent;
    }

    private void OnDisable()
    {
        EventHandler.ShowDialogueEvent -= OnShowDialogueEvent;
    }

    private void OnShowDialogueEvent(DialogueDetial dialogueDetial)
    {
        currentDialogueDetial = dialogueDetial;
        FillDialogueStack();

        StartCoroutine(DialogueRotouTine());
    }

    private void Update()
    {
        if (canPick && Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(DialogueRotouTine());
        }
    }


    private void FillDialogueStack()
    {
        dialogueQueue = new Queue<DialoguePiece>();

        for (int i = 0; i < currentDialogueDetial.DialoguePieces.Count; i++)
        {
            currentDialogueDetial.DialoguePieces[i].isDone = false;
            dialogueQueue.Enqueue(currentDialogueDetial.DialoguePieces[i]);
        }
    }

    private IEnumerator DialogueRotouTine()
    {
        canPick = false;
        if (dialogueQueue.Count != 0)
        {
            var result = dialogueQueue.Dequeue();
            if (result != null)
            {
                EventHandler.CallUpdateDialogueUIEvent(currentDialogueDetial, result, isFirst);
                yield return new WaitUntil(() => result.isDone);
                canPick = true;

                isFirst = false;
            }
        }
        else
        {
            EventHandler.CallUpdateDialogueUIEvent(null, null, false);
            EventHandler.CallShowChooseEvent(currentDialogueDetial);
            isFirst = true;
        }
    }
}