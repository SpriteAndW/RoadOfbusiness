using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainStoryRecordManager : MonoBehaviour
{
    public GameObject mainstoryRecord;
    public GameObject mainstoryContent;

    public void AddRecord(int day,string choosename)
    {
        GameObject mr = Instantiate(mainstoryRecord,mainstoryContent.gameObject.transform);
        mainstoryRecord.GetComponent<Text>().text = "µÚ"+day.ToString()+ "Ìì"  + choosename;
    }


}
