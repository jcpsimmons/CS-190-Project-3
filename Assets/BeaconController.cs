using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconController : MonoBehaviour
{
    public List<PathCell> pathCellList;

    void Awake()
    {
        for (int i = 0; i < pathCellList.Count; i++)
        {
            pathCellList[i].rtpcPercentage = (i/(float)pathCellList.Count)*100;
        }
    }
}