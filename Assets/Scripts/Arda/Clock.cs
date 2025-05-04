using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clock : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] float startTime = 8f;
    [SerializeField] float endTime = 20f;
    [SerializeField] GameObject endingPanel;
    private float currentTime;
    [SerializeField] float timeToComplete = 240f;
    private float timeElapsed = 0f;
    [SerializeField] CompletedTable completedTable;

    void Start()
    {
        endingPanel.SetActive(false);
        currentTime = startTime;

        Time.timeScale = 1f;
    }

    void Update()
    {
        if (currentTime < endTime)
        {
            timeElapsed += Time.deltaTime;

            float timeRatio = timeElapsed / timeToComplete;

            currentTime = startTime + (timeRatio * (endTime - startTime));

            int hours = Mathf.FloorToInt(currentTime); // Saat
            int minutes = Mathf.FloorToInt((currentTime - hours) * 60f); // Dakika

            timeText.text = string.Format("{0:D2}:{1:D2}", hours, minutes);
        }
        else
        {
            timeText.text = "20:00";
            Time.timeScale = 0f;
            endingPanel.SetActive(true);
            completedTable.UICompletedWorkTable();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
