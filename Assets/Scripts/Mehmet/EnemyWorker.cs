using UnityEngine;

namespace Mehmet
{
    public class EnemyWorker : MonoBehaviour
    {
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
        }

        private void OnDestroy()
        {
            if (assignedTable != null)
                assignedTable.UnregisterEnemy(this);
        }
    }
}