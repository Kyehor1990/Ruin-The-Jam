using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Alındı!
            // Mesela:
            Debug.Log("Pickup alındı!");
            PickUp();
            DestroyTopParent();

            // Efekt/Animasyon/Ses
            // Destroy(gameObject); veya setActive(false)
        }
    }
    
    // Oyuncu pickup aldığında çalışacak fonksiyon
    void PickUp()
    {
        Debug.Log("Pickup işlemi gerçekleşti!");
        Debug.Log("Pickup işlemi başladı!");

        foreach (Transform child in transform)
        {
            switch (child.name)
            {
                case "1":
                    DoFunctionOne();
                    break;
                case "2":
                    DoFunctionTwo();
                    break;
                case "3":
                    DoFunctionThree();
                    break;
                case "4":
                    DoFunctionFour();
                    break;
                case "5":
                    DoFunctionFive();
                    break;
                default:
                    Debug.Log("Bilinmeyen obje ismi: " + child.name);
                    break;
            }
        }
        // Buraya ses efekti, animasyon, puan vs. eklenebilir
    }

    // Objenin en üst parent'ını yok eder
    void DestroyTopParent()
    {
        Transform topParent = transform;
        while (topParent.parent != null)
        {
            topParent = topParent.parent;
        }

        Destroy(topParent.gameObject);
    }
    void DoFunctionOne()
    {
        Debug.Log("Fonksiyon 1 çağrıldı: Örneğin can ver.");
        // playerHealth += 10;
    }

    void DoFunctionTwo()
    {
        Debug.Log("Fonksiyon 2 çağrıldı: Mermi ver.");
        // playerAmmo += 5;
    }

    void DoFunctionThree()
    {
        Debug.Log("Fonksiyon 3 çağrıldı: Altın ver.");
        // playerGold += 100;
    }

    void DoFunctionFour()
    {
        Debug.Log("Fonksiyon 4 çağrıldı: Zıplama gücü artır.");
        // playerJumpPower *= 1.2f;
    }

    void DoFunctionFive()
    {
        Debug.Log("Fonksiyon 5 çağrıldı: Zamanı yavaşlat.");
        // Time.timeScale = 0.5f;
    }

}

