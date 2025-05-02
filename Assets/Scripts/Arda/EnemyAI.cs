using UnityEngine;
using UnityEngine.AI;
using Mehmet;

public class EnemyChase : MonoBehaviour
{
    public Transform player;
    public float chaseDistance = 10f;
    public LayerMask obstacleMask;

    private NavMeshAgent agent;
    private EnemyStunnable stunnable;
    private Vector3 StartPosition;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        stunnable = GetComponent<EnemyStunnable>();
        StartPosition = transform.position;
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
            agent.SetDestination(player.position);
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
}
