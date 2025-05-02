using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float chaseSpeed = 4f;
    [SerializeField] float returnSpeed = 2f;

    private NavMeshAgent agent;
    private Vector3 startPosition;
    private bool isPlayerInSight = false;
    private bool isChasing = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        startPosition = transform.position;
    }

    void Update()
    {
        if (isPlayerInSight)
        {
            agent.speed = chaseSpeed;
            agent.SetDestination(player.position);
            isChasing = true;
        }
        else if (isChasing)
        {
            agent.speed = returnSpeed;
            agent.SetDestination(startPosition);

            if (Vector3.Distance(transform.position, startPosition) < 0.5f)
            {
                isChasing = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered: " + other.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detected!");
            isPlayerInSight = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInSight = false;
        }
    }
}
