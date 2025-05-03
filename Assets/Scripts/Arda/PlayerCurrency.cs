using UnityEngine;
using TMPro;

public class PlayerCurrency : MonoBehaviour
{
    [SerializeField] int totalCoins = 0;
    [SerializeField] TextMeshProUGUI coinText;

    void Start()
    {
        if (coinText != null)
        {
            UpdateCoinUI();
        }
    }

    public void AddCoins(int amount)
    {
        totalCoins += amount;
        Debug.Log("Coins Added: " + amount + ". Total coins: " + totalCoins);

        UpdateCoinUI();
    }

    void UpdateCoinUI()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + totalCoins;
        }
    }
}
