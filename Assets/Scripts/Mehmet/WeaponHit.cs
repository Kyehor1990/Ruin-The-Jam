using UnityEngine;

namespace Mehmet
{
    public class WeaponHit : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                EnemyHit enemy = other.GetComponent<EnemyHit>();
                if (enemy != null)
                {
                    enemy.GetHit();
                }
            }
        }
    }
}