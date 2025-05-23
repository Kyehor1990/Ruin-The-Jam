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

        public int stunTime = 2;

        private float attackTimer = 0f;

        private PlayerCurrency playerCurrency;

        void Start()
        {
            playerCurrency = GetComponent<PlayerCurrency>();
        }

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
                    enemy.Stun(stunTime);
                }

                if (hit.collider.TryGetComponent(out EnemyWorker enemy2))
                {
                   // Debug.LogError("Vurdum! " + enemy2.gameObject.name);
                    enemy2.Stun2(stunTime);
                }
            }
        }

        public void BuyStunTime()
        {
            if(playerCurrency.totalCoins >= 10){
                playerCurrency.SpendCoins(10);
                stunTime += 1;

            }else{
                Debug.Log("Yeterli para yok!");
            }
        }
    }
}