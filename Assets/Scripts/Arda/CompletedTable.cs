using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletedTable : MonoBehaviour
{
    [SerializeField] int totalCompletedWorkTables = 0;

    public void CompletedWorkTable()
    {
        totalCompletedWorkTables++;
        Debug.Log("Completed Work Table: " + totalCompletedWorkTables);
    }

}
