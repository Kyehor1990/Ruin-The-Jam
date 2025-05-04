using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private PlayerCurrency playerCurrency;

    void Start()
    {
        playerCurrency = GetComponent<PlayerCurrency>();
        currentHealth = maxHealth;
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Oyuncu hasar aldı: " + amount);

        if (currentHealth <= 0)
        {
            Debug.Log("Oyuncu öldü!");
        }
    }

    public void Heal()
    {
        if(playerCurrency.totalCoins >= 5){
            currentHealth = maxHealth;
            playerCurrency.SpendCoins(5);
        }else{
            Debug.Log("Yeterli para yok!");
        }
    }
}

