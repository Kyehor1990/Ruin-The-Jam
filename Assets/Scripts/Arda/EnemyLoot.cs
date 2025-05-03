using Mehmet;
using UnityEngine;

public class EnemyLoot : MonoBehaviour
{
    public GameObject coinPrefab;
    public float lootRadius = 5f;
    public int lootAmount = 10;

    private EnemyStunnable stunnable;
    private bool hasDroppedCoins = false;

    void Start()
    {
        stunnable = GetComponent<EnemyStunnable>();
    }

    void Update()
    {
        if (stunnable != null && stunnable.IsStunned() && !hasDroppedCoins)
        {
            DropCoins();
            hasDroppedCoins = true;
        }

        if (stunnable != null && !stunnable.IsStunned() && hasDroppedCoins)
        {
            hasDroppedCoins = false;
        }
    }

    void DropCoins()
    {
        Debug.Log("Para düşürülüyor...");

        for (int i = 0; i < lootAmount; i++)
        {
            Vector3 randomDirection = Random.insideUnitSphere * lootRadius;
            randomDirection.y = 0f;
            Vector3 spawnPosition = transform.position + randomDirection;

            Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        }
    }
}

