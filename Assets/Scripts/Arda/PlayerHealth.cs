using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth = 100;

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Oyuncu hasar aldı: " + amount);

        if (currentHealth <= 0)
        {
            Debug.Log("Oyuncu öldü!");
        }
    }
}

