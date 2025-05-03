using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour
{
    private bool canShoot = false;
    public GameObject projectilePrefab;
    public Transform shootPoint;

    void Update()
    {
        if (canShoot && Input.GetMouseButtonDown(1))
        {
            ShootProjectile();
            canShoot = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            GrantAmmo();
        }
    }

    public void GrantAmmo()
    {
        if (!canShoot)
        {
            canShoot = true;
            Debug.Log("Mermi atma hakkı verildi!");
        }
    }

    void ShootProjectile()
    {
        if (projectilePrefab != null && shootPoint != null)
        {
            Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
            Debug.Log("Mermi atıldı!");
        }
    }
}
