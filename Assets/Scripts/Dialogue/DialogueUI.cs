using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DialogueUI : MonoSingleton<DialogueUI>
{
    public GameObject PlotBG;
    public Text plotText;

    public GameObject DialogueBG;
    public Text talkText;
    public Image leftImage;
    public Text leftName;
    public Image rightImage;
    public Text rightName;


    public GameObject ChooseBG;
    public GameObject choosePrefab;

    // public Button newGameBtn;
    public Button quitGameBtn;
    public Sprite GameoveBg;


    // private DialogueDetial currentDialogueDetial;

    // private void Awake()
    // {
    //     DontDestroyOnLoad(gameObject);
    // }
    

    private void OnEnable()
    {
        EventHandler.UpdateDialogueUIEvent += OnUpdateDialogueUIEvent;
        EventHandler.ShowChooseEvent += OnShowChooseEvent;
        EventHandler.ShowGameOver += OnShowGameOver;
    }

    private void OnDisable()
    {
        EventHandler.UpdateDialogueUIEvent -= OnUpdateDialogueUIEvent;
        EventHandler.ShowChooseEvent -= OnShowChooseEvent;
        EventHandler.ShowGameOver -= OnShowGameOver;
    }

    private void OnShowGameOver()
    {
        StartCoroutine(WaitForSecond(8f, 3f));
    }

    private IEnumerator WaitForSecond(float textSpeed,float waitTime)
    {
        
        PlotBG.SetActive(true);
        DialogueBG.SetActive(false);
        PlotBG.GetComponent<Image>().sprite = GameoveBg;
        plotText.text = String.Empty;
        yield return plotText
            .DOText("感谢游玩游戏Demo\n" +
                    "策划：\n" +
                    "<color=#D4C773>技巧</color>\n" +
                    "程序:\n" +
                    "<color=#D4C773>岩弈 \t \t叛逆的钢\t \t德芙</color>\n" +
                    "美术:\n" +
                    "<color=#D4C773>哇福\t \t 古川\t \t醋醋\t \t苏仙儿</color>\n"+
                    "特别鸣谢:\n"+
                    "<color=#D4C773>音乐:\tEK \t \t 文案:\t小泷</color>", textSpeed)
            .WaitForCompletion();

        yield return new WaitForSeconds(waitTime);
        // newGameBtn.gameObject.SetActive(true);
        quitGameBtn.gameObject.SetActive(true);
    }

    // public void ResetDialogue()
    // {
    //     PlotBG.SetActive(false);
    //     DialogueBG.SetActive(false);
    //     // newGameBtn.gameObject.SetActive(false);
    //     quitGameBtn.gameObject.SetActive(false);
    // }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("突出游戏");
    }
    
    


    private void OnUpdateDialogueUIEvent(DialogueDetial dialogueDetial, DialoguePiece dialoguePiece, bool isFirst)
    {
        StartCoroutine(ShowPlotText(dialogueDetial, dialoguePiece, isFirst));
    }

    private void OnShowChooseEvent(DialogueDetial dialogueDetial)
    {
        if (dialogueDetial.ChooseBtns.Count != 0)
        {
            ChooseBG.SetActive(true);
            for (int i = 0; i < dialogueDetial.ChooseBtns.Count; i++)
            {
                var chooseBtn = Instantiate(choosePrefab, ChooseBG.transform);
                chooseBtn.transform.GetChild(0).GetComponent<Text>().text = dialogueDetial.ChooseBtns[i].chooseName;

                chooseBtn.transform.GetChild(2).GetComponent<Image>().sprite = dialogueDetial.ChooseBtns[i].chooseImage;

                chooseBtn.GetComponent<ChooseChange>().changBtn = dialogueDetial.ChooseBtns[i];
            }
        }
        else
        {
            ChooseBG.SetActive(false);
        }
    }


    private IEnumerator ShowPlotText(DialogueDetial dialogueDetial, DialoguePiece dialoguePiece, bool isFirst)
    {
        if (dialogueDetial != null)
        {
            if (dialogueDetial.plotString != String.Empty && isFirst)
            {
                DialogueBG.SetActive(false);
                PlotBG.SetActive(true);

                plotText.text = String.Empty;


                yield return plotText.DOText(dialogueDetial.plotString, 3f).WaitForCompletion();

                yield return new WaitForSeconds(2f);
                PlotBG.SetActive(false);
            }
        }

        StartCoroutine(ShowDialogue(dialoguePiece));
    }


    private IEnumerator ShowDialogue(DialoguePiece piece)
    {
        if (piece != null)
        {
            piece.isDone = false;

            DialogueBG.SetActive(true);

            talkText.text = String.Empty;
            leftName.text = String.Empty;
            rightName.text = String.Empty;


            if (piece.faceImage != null)
            {
                if (piece.isLeft)
                {
                    leftImage.gameObject.SetActive(true);


                    leftImage.sprite = piece.faceImage;
                    leftName.text = piece.faceName;

                    leftImage.gameObject.transform.DOMoveX(350, 0.5f);
                    leftImage.gameObject.GetComponent<CanvasGroup>().DOFade(1, 0.5f);

                    rightImage.gameObject.transform.DOMoveX(1920 - 300, 0.5f);
                    rightImage.gameObject.GetComponent<CanvasGroup>().DOFade(0, 0.5f);
                }
                else
                {
                    rightImage.gameObject.SetActive(true);

                    rightImage.sprite = piece.faceImage;
                    rightName.text = piece.faceName;


                    rightImage.gameObject.transform.DOMoveX(1920 - 350, 0.5f);
                    rightImage.gameObject.GetComponent<CanvasGroup>().DOFade(1, 0.5f);

                    leftImage.gameObject.transform.DOMoveX(300, 0.5f);
                    leftImage.gameObject.GetComponent<CanvasGroup>().DOFade(0, 0.5f);
                }
            }
            else
            {
                leftImage.gameObject.SetActive(false);
                rightImage.gameObject.SetActive(false);
            }


            yield return talkText.DOText(piece.dialogueText, 1f).WaitForCompletion();

            piece.isDone = true;
        }
        else
        {
            DialogueBG.SetActive(false);
        }
    }
}