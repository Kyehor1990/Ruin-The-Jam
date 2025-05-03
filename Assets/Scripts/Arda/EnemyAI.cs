using UnityEngine;
using UnityEngine.AI;
using Mehmet;
using System.Collections;

public class EnemyChase : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float chaseDistance;
    [SerializeField] LayerMask obstacleMask;

    [SerializeField] float attackDistance;
    [SerializeField] float attackCooldown;
    [SerializeField] float attackDelay = 1f;

    private NavMeshAgent agent;
    private EnemyStunnable stunnable;
    private Vector3 StartPosition;
    private float lastAttackTime;
    private bool isAttacking = false; 

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        stunnable = GetComponent<EnemyStunnable>();
        StartPosition = transform.position;
        lastAttackTime = -attackCooldown;
    }

    void Update()
    {
        if (stunnable != null && stunnable.IsStunned())
        {
            agent.ResetPath();
            return;
        }

        float distance = Vector3.Distance(player.position, transform.position);

        if (distance < chaseDistance && CanSeePlayer())
        {
            if (distance <= attackDistance && !isAttacking && Time.time >= lastAttackTime + attackCooldown)
            {
                StartCoroutine(WaitBeforeAttack());
            }
            else if (!isAttacking)
            {
                agent.SetDestination(player.position);
            }
        }
        else
        {
            agent.SetDestination(StartPosition);
        }
    }

    bool CanSeePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        return !Physics.Raycast(transform.position, direction, distanceToPlayer, obstacleMask);
    }

 IEnumerator WaitBeforeAttack()
    {
        isAttacking = true;
        agent.isStopped = true;

        yield return new WaitForSeconds(attackDelay);

        if (stunnable != null && stunnable.IsStunned())
        {
            agent.isStopped = false;
            isAttacking = false;
            yield break;
        }

        AttackPlayer();

        StartCoroutine(ResumeMovementAfterAttack());
    }

    void AttackPlayer()
    {
        // Saldırı animasyonu
        Debug.Log("Player attacked!");

        if (Vector3.Distance(player.position, transform.position) <= attackDistance)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(20);
            }
        }

        lastAttackTime = Time.time;
    }

    IEnumerator ResumeMovementAfterAttack()
    {
        yield return new WaitForSeconds(attackCooldown);
        agent.isStopped = false;
        isAttacking = false;
    }
}
