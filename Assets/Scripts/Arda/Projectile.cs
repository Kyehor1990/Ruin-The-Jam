using Mehmet;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;

    void Start()
    {
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
                enemy.Stun(4f);
                Destroy(gameObject);
            }
        }

        if (collision.collider.CompareTag("EnemyWorker"))
        {
            EnemyWorker enemy = collision.gameObject.GetComponent<EnemyWorker>();
            if (enemy != null)
            {
                enemy.Stun2(4f);
                Destroy(gameObject);
            }
        }

        if (!collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
