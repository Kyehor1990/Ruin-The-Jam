using UnityEngine;

namespace Mehmet
{
    public class EnemyStunnable : MonoBehaviour
    {
        private bool isStunned = false;
        private float stunTimer = 0f;

        public void Stun(float duration)
        {
            isStunned = true;
            stunTimer = duration;
            Debug.Log($"{gameObject.name} has been stunned!");
        }

        void Update()
        {
            if (isStunned)
            {
                stunTimer -= Time.deltaTime;
                if (stunTimer <= 0f)
                    isStunned = false;
            }
        }
    }
}