using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CompletedTable : MonoBehaviour
{
    [SerializeField] int totalCompletedWorkTables;
    [SerializeField] TextMeshProUGUI completedText;
    [SerializeField] TextMeshProUGUI uncompletedText;

    private int tableCount = 13;

void Start()
    {
        totalCompletedWorkTables = 0;
    }

    public void CompletedWorkTable()
    {
        totalCompletedWorkTables++;
        Debug.Log("Tamamlanan Oyun sayısı: " + totalCompletedWorkTables);
    }

    public void UICompletedWorkTable()
    {
        if (completedText != null)
        {
            completedText.text = "Tamamlanan Oyun Sayısı: " + totalCompletedWorkTables;
        }

        if (uncompletedText != null)
        {
            int uncompletedWorkTables = tableCount - totalCompletedWorkTables;
            uncompletedText.text = "Bitirilemeyen Oyun Sayısı: " + uncompletedWorkTables;
        }
    }

}
