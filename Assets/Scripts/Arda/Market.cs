using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Market : MonoBehaviour
{
    [SerializeField] GameObject marketPanel;
    private bool isInTrigger = false;
    private bool isMarketOpen = false;

    void Update()
    {
        if (isInTrigger && Input.GetKeyDown(KeyCode.E) && !isMarketOpen)
        {
            Debug.Log("Market Opened!");
            marketPanel.SetActive(true);
            isMarketOpen = true;
            Time.timeScale = 0f;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }else if (isMarketOpen && Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 1f;
            marketPanel.SetActive(false);
            isMarketOpen = false;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInTrigger = false;
        }
    }
}
