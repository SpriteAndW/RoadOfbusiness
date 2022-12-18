using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveRecordData_SO",menuName = "Save/SaveRecordData_SO")]
public class SaveRecordData_SO : ScriptableObject
{
    public List<SaveRecordDetail> savrRecordList = new List<SaveRecordDetail>();
}
