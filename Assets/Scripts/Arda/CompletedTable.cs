using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CompletedTable : MonoBehaviour
{
    [SerializeField] int totalCompletedWorkTables = 0;
    [SerializeField] TextMeshProUGUI completedText;


    public void CompletedWorkTable()
    {
        totalCompletedWorkTables++;
        Debug.Log("Completed Work Table: " + totalCompletedWorkTables);
    }

    public void UICompletedWorkTable()
    {
        if (completedText != null)
        {
            completedText.text = "Completed Work Tables: " + totalCompletedWorkTables;
        }
    }

}
