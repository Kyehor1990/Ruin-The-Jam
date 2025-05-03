using Mehmet;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;

    private PlayerAttack playerAttack;

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
        if (collision.collider.CompareTag("Enemy"))
        {
            EnemyStunnable enemy = collision.gameObject.GetComponent<EnemyStunnable>();
            if (enemy != null)
            {
                enemy.Stun(playerAttack.stunTime + 2);
                Destroy(gameObject);
            }
        }

        if (collision.collider.CompareTag("EnemyWorker"))
        {
            EnemyWorker enemy = collision.gameObject.GetComponent<EnemyWorker>();
            if (enemy != null)
            {
                enemy.Stun2(playerAttack.stunTime + 2);
                Destroy(gameObject);
            }
        }

        if (!collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}


