using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "MapInventory", menuName = "MapInventory/MapInventory")]
public class MapInventory : ScriptableObject
{
    public List<List<MapGridInfo>> allRoads = new List<List<MapGridInfo>>();    

    public int index = 0;
    public List<MapGridInfo> tempRoad = new List<MapGridInfo>();

    public List<MapGridInfo> road0 = new List<MapGridInfo>();
    public List<MapGridInfo> road1 = new List<MapGridInfo>();
    public List<MapGridInfo> road2 = new List<MapGridInfo>();
    public List<MapGridInfo> road3 = new List<MapGridInfo>();
    public List<MapGridInfo> road4 = new List<MapGridInfo>();
    public List<MapGridInfo> road5 = new List<MapGridInfo>();
    public List<MapGridInfo> road6 = new List<MapGridInfo>();
    public List<MapGridInfo> road7 = new List<MapGridInfo>();
    public List<MapGridInfo> road8 = new List<MapGridInfo>();
    public List<MapGridInfo> road9 = new List<MapGridInfo>();
    public List<MapGridInfo> road10 = new List<MapGridInfo>();
    public List<MapGridInfo> road11 = new List<MapGridInfo>();
    public List<MapGridInfo> road12 = new List<MapGridInfo>();
    public List<MapGridInfo> road13 = new List<MapGridInfo>();
    public List<MapGridInfo> road14 = new List<MapGridInfo>();

    private void OnEnable()
    {
        Debug.Log("do");
        allRoads.Add(road0);
        allRoads.Add(road1);
        allRoads.Add(road2);
        allRoads.Add(road3);
        allRoads.Add(road4);
        allRoads.Add(road5);
        allRoads.Add(road6);
        allRoads.Add(road7);
        allRoads.Add(road8);
        allRoads.Add(road9);
        allRoads.Add(road10);
        allRoads.Add(road11);
        allRoads.Add(road12);
        allRoads.Add(road13);
        allRoads.Add(road14);
    }
    private void Awake()
    {

        //allRoads.Add(road0);
        //allRoads.Add(road1);
        //allRoads.Add(road2);
        //allRoads.Add(road3);
        //allRoads.Add(road4);
        //allRoads.Add(road5);
        //allRoads.Add(road6);
        //allRoads.Add(road7);
        //allRoads.Add(road8);
        //allRoads.Add(road9);
        //allRoads.Add(road10);
        //allRoads.Add(road11);
        //allRoads.Add(road12);
        //allRoads.Add(road13);
        //allRoads.Add(road14);
    }

}
