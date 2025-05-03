using UnityEngine;

public class EnemyLookAt : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float rotationSpeed;

    void Start()
{
    GameObject myObject = GameObject.FindGameObjectWithTag("MainCamera");

    player = myObject.transform;
}

    void Update()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        
        directionToPlayer.y = 0;

        if (directionToPlayer.magnitude > 0.1f) 
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
