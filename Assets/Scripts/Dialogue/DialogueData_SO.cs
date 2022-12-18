using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;


[CreateAssetMenu(fileName = "DialogueData_SO",menuName = "Dialogue/DialogueData_SO")]
public class DialogueData_SO : ScriptableObject
{
    public List<DialogueDetial> dialogueDetailList;

    

    public DialogueDetial GetDialogueDetail(float day)
    {
        return dialogueDetailList.Find(d => d.dayID == day);
    }
}

[System.Serializable]
public class DialogueDetial
{
    public float dayID; //根据天数获取对应的信息
    //剧情名
    [Tooltip("剧情名")]
    public string plotName;
    //是否是主线 否则为支线
    [Tooltip("是主线吗 不勾选为支线")]
    public bool isMain = true;
    [TextArea]
    public string plotString; //剧情文字
    public List<DialoguePiece> DialoguePieces; 
    public List<ChooseBtn> ChooseBtns;
}

[System.Serializable]
public class DialoguePiece
{
    public string faceName;
    public Sprite faceImage;
    public bool isLeft;

    [TextArea] public string dialogueText;
    [HideInInspector]public bool isDone;
}

[System.Serializable]
public class ChooseBtn
{
    public string chooseName;
    public Sprite chooseImage;
    public ChooseBtnType BtnType;
    public int WealthChange;
    public int CreditChange;
    public int GoodsChange;
    public Item goods;
    public float dialogueID;
    public string guideSceneName;

}

public enum ChooseBtnType
{
    simple,guide,other,
}