using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventRecordManager : MonoBehaviour
{
    public GameObject eventRecord;
    public GameObject eventContent;

    public void AddRecord(string eventname, string choosename)
    {
        GameObject mr = Instantiate(eventRecord,eventContent.gameObject.transform);
        eventRecord.GetComponent<Text>().text =eventname+"  " + choosename;
    }
}
