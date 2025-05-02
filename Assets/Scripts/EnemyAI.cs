using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float chaseDistance = 10f;
    [SerializeField] LayerMask obstacleMask;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

       if (distance < chaseDistance)
        {
            if (CanSeePlayer())
            {
                agent.SetDestination(player.position);
            }
            else
            {
                agent.ResetPath();
            }
        }
        else
        {
            agent.ResetPath();
        }

    }

    bool CanSeePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (!Physics.Raycast(transform.position, direction, distanceToPlayer, obstacleMask))
        {
            return true;
        }

        return false;
    }
}
