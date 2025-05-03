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
}

