using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mehmet
{
    public class FloatingArrow : MonoBehaviour
    {
        public float floatAmplitude = 0.25f; // Yükseklik
        public float floatFrequency = 1f;    // Ne kadar hızlı
        public float rotateSpeed = 90f;      // Derece/saniye
    
        private Vector3 startPos;
    
        void Start()
        {
            startPos = transform.position;
        }
    
        void Update()
        {
            // Yukarı-aşağı hareket
            float yOffset = Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
            transform.position = startPos + new Vector3(0f, yOffset, 0f);
    
            // Dönme
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
        }
    }
}

