using UnityEngine;

namespace Mehmet
{
    public class PlayerAttack : MonoBehaviour
    {
        public float attackRange = 5f; // Vurma mesafesi
        public float attackCooldown = 1f; // Vuruşlar arası süre
        public LayerMask enemyLayer; // Sadece Enemy katmanı
        public BatAnimator batAnimator; // Animasyon kontrolü
        public Transform cameraTransform; // FPS kamera

        private float attackTimer = 0f;

        void Update()
        {
            attackTimer += Time.deltaTime;

            if (Input.GetMouseButtonDown(0) && attackTimer >= attackCooldown)
            {
                attackTimer = 0f;
                Attack();
            }

            // ✅ Ray'i sahnede çizmek (görsel test için)
            Debug.DrawRay(cameraTransform.position, cameraTransform.forward * attackRange, Color.red);
        }

        void Attack()
        {
            // 1. Sopayı salla
            if (batAnimator != null)
                batAnimator.Swing();

            // 2. Ray gönder
            Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, attackRange, enemyLayer))
            {
                // 3. Enemy'e stun uygula
                if (hit.collider.TryGetComponent(out EnemyStunnable enemy))
                {
                    enemy.Stun(2f);
                }

                if (hit.collider.TryGetComponent(out EnemyWorker enemy2))
                {
                    enemy2.Stun2(2f);
                }
            }
        }
    }
}