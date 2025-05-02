using UnityEngine;

namespace Mehmet
{
    public class EnemyHit : MonoBehaviour
    {
        public void GetHit()
        {
            Debug.Log($"{gameObject.name} vuruldu!");
            // Örneğin animasyon, stun, particle efekt vs burada çağrılır
        }
    }
}