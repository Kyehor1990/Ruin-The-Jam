using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Mehmet
{
    public class EnemyStunnable : MonoBehaviour
    {
        [SerializeField] ParticleSystem starEffect;
        [SerializeField] Transform headTransform;

        private bool isStunned = false;
        private NavMeshAgent agent;

        [SerializeField] float stunDuration;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            if (agent == null)
            {
                Debug.LogWarning("NavMeshAgent bu nesnede yok!");
            }

            starEffect.Stop();
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
            stunDuration = duration;

            if (agent != null)
                agent.isStopped = true;

            starEffect.transform.position = headTransform.position;
            starEffect.Play();
            StartCoroutine(StopStarEffect());

            yield return new WaitForSeconds(duration);

            if (agent != null)
                agent.isStopped = false;

            isStunned = false;
        }

        public bool IsStunned()
        {
            return isStunned;
        }

    IEnumerator StopStarEffect()
    {
        yield return new WaitForSeconds(stunDuration);
        starEffect.Stop();
    }
    }
}
