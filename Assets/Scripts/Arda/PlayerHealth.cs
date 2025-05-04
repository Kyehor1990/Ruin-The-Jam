using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
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
        currentHealth = maxHealth;
    }
}

