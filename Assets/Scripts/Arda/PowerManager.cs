using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour
{
    private bool kissCanShoot = false;
    private bool bombCanShoot = false;
    public GameObject projectilePrefab;
    public GameObject bombPrefab;
    public Transform shootPoint;

    void Update()
    {
        if (kissCanShoot && Input.GetMouseButtonDown(1))
        {
            ShootProjectile();
            kissCanShoot = false;
        }else if (bombCanShoot && Input.GetMouseButtonDown(1))
        {
            Instantiate(bombPrefab, shootPoint.position, shootPoint.rotation);
            bombCanShoot = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            GrantBomb();
        }
    }

    public void GrantAmmo()
    {
        if (!kissCanShoot)
        {
            kissCanShoot = true;
            Debug.Log("Mermi atma hakkı verildi!");
        }
    }

    public void GrantBomb()
    {
        if (bombPrefab != null && shootPoint != null)
        {
            bombCanShoot = true;
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
