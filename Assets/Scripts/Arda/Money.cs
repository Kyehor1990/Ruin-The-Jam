using UnityEngine;

public class Money : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCurrency playerCurrency = other.GetComponent<PlayerCurrency>();
            if (playerCurrency != null)
            {
                playerCurrency.AddCoins(1);
            }

            Destroy(gameObject);
        }
    }
}
