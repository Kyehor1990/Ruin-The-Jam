using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStars : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float rotationSpeed = 100f;

    private void Update()
    {
        if (target != null)
        {
            transform.RotateAround(target.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}
