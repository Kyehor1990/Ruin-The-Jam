using System.Collections;
using UnityEngine;

namespace Mehmet
{
    public class EnemyWorker : MonoBehaviour
    {
        [SerializeField] ParticleSystem starEffect;
        [SerializeField] Transform headTransform;
        [SerializeField] float stunDuration;

        public WorkTable assignedTable;
        public bool IsStunned { get; private set; } = false;

        private float stunTimer = 0f;

        void Start()
        {
            if (assignedTable != null)
                assignedTable.RegisterEnemy(this);
        }

        void Update()
        {
            if (IsStunned)
            {
                assignedTable.UnregisterEnemy(this);

                stunTimer -= Time.deltaTime;
                if (stunTimer <= 0f)
                {
                    IsStunned = false;
                    assignedTable.RegisterEnemy(this);
                }
            }
        }
            
        public void Stun2(float duration)
        {
            Debug.Log("Vuruldum, çalışamıyorum.");
            IsStunned = true;
            stunTimer = duration;
            stunDuration = duration;

            starEffect.transform.position = headTransform.position;
            starEffect.Play();
            StartCoroutine(StopStarEffect());
        }

        private void OnDestroy()
        {
            if (assignedTable != null)
                assignedTable.UnregisterEnemy(this);
        }

        IEnumerator StopStarEffect()
        {
            yield return new WaitForSeconds(stunDuration);
            starEffect.Stop();
        }
    }
}