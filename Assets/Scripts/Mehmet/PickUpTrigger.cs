    using System.Collections;
using System.Collections.Generic;
using Mehmet;
using UnityEngine;
using UnityEngine.Serialization;

public class PickUpTrigger : MonoBehaviour
{
    public PowerManager powerManager;
    public ProjectileShooter projectileShooter;

    [Header("Diyalog Ayarları")]
    public GameObject pokemon;

    public GameObject beer;
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
        powerManager.GrantAmmo();
        Destroy(gameObject);
    }

    void DoFunctionTwo()
    {
        powerManager.GrantBomb();
        Destroy(gameObject);
    }

    void DoFunctionThree()
    {
        Debug.Log("Fonksiyon 3 çağrıldı: Altın ver.");
        // playerGold += 100;
    }

    void DoFunctionFour()
    {
        //pokemon pt
        projectileShooter.SetProjectile(pokemon);
        
    }

    void DoFunctionFive()
    {
       //beer pt
       projectileShooter.SetProjectile(beer);
       
    }

}

