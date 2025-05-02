using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Mehmet
{
    public class EnemyStunnable : MonoBehaviour
    {
        private bool isStunned = false;
        private NavMeshAgent agent;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            if (agent == null)
            {
                Debug.LogWarning("NavMeshAgent bu nesnede yok!");
            }
        }

        public void Stun(float duration)
        {
            if (!isStunned)
            {
                Debug.Log("Vuruldum! " + duration + " saniyelik stun.");
                StartCoroutine(StunCoroutine(duration));
            }
        }

        private IEnumerator StunCoroutine(float duration)
        {
            isStunned = true;

            if (agent != null)
                agent.isStopped = true;

            // Buraya animasyon oynatma, renk değiştirme vs. ekleyebilirsin

            yield return new WaitForSeconds(duration);

            if (agent != null)
                agent.isStopped = false;

            isStunned = false;
        }

        public bool IsStunned()
        {
            return isStunned;
        }
    }
}
