using UnityEngine;
using TMPro;

public class PlayerCurrency : MonoBehaviour
{
    public int totalCoins = 0;
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

        UpdateCoinUI();
    }

    void UpdateCoinUI()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + totalCoins;
        }
    }

    public void SpendCoins(int amount)
    {
        if (totalCoins >= amount)
        {
            totalCoins -= amount;
            UpdateCoinUI();
        }
        else
        {
            Debug.Log("Not enough coins!");
        }
    }
}
