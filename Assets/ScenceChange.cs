using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenceChange : MonoBehaviour
{
    [SerializeField] private string sceneToLoad; // Değiştirilecek sahne adı

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Sadece "Player" tag'lı objeyle tetiklenirse
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
