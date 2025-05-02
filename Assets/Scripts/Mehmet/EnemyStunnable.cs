using UnityEngine;

namespace Mehmet
{
    public class EnemyStunnable : MonoBehaviour
    {
        public void Stun(float duration)
        {
            Debug.Log("Vuruldum! " + duration + " saniyelik stun.");
            // İleride burada animasyon, hareket durdurma vs. ekleyebilirsin.
        }
    }
}