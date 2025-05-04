using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] Image image;

    [SerializeField] Sprite newSprite100;
    [SerializeField] Sprite newSprite80;
    [SerializeField] Sprite newSprite60;
    [SerializeField] Sprite newSprite40;
    [SerializeField] Sprite newSprite20;
    [SerializeField] PlayerHealth playerHealth;

    void Start()
    {
        image.sprite = newSprite100;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerHealth.TakeDamage(20);
        }
        {
            playerHealth = FindObjectOfType<PlayerHealth>();
        }

        if (playerHealth.currentHealth == 100)
        {
            image.sprite = newSprite100;
        }
        else if (playerHealth.currentHealth >= 80)
        {
            image.sprite = newSprite80;
        }
        else if (playerHealth.currentHealth >= 60)
        {
            image.sprite = newSprite60;
        }
        else if (playerHealth.currentHealth >= 40)
        {
            image.sprite = newSprite40;
        }
        else if (playerHealth.currentHealth >= 20)
        {
            image.sprite = newSprite20;
        }
    }
}
