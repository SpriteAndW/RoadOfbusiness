using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory / New Inventory")]
public class Inventory : ScriptableObject
{
    [SerializeField]
    public List<Item> itemList = new List<Item>();
    
}
