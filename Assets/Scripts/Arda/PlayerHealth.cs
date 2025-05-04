using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private PlayerCurrency playerCurrency;
    [SerializeField] GameObject deathPanel;

    void Start()
    {
        deathPanel.SetActive(false);
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

    void Update()
    {
        if(currentHealth <= 0){
            Time.timeScale = 0f;
            deathPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}

