using System.Collections;
using System.Collections.Generic;
using Mehmet;
using UnityEngine;

public class BombProjectile : MonoBehaviour
{

    public float speed = 10f;
    private PlayerAttack playerAttack;
    [SerializeField] float explosionRadius = 5f;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerAttack = player.GetComponent<PlayerAttack>();
        }

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = transform.forward * speed;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Player"))
        {
            Explode();
        }
    }


    void Explode()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                enemy.GetComponent<EnemyStunnable>().Stun(playerAttack.stunTime + 2);
            }

            if (enemy.CompareTag("EnemyWorker"))
            {
                enemy.GetComponent<EnemyWorker>().Stun2(playerAttack.stunTime + 2);
            }
            Destroy(gameObject);
        }

    }
}
