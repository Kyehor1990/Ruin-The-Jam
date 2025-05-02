using UnityEngine;

namespace Mehmet
{
    public class PlayerAttack : MonoBehaviour
    {
        public float attackRange = 2f;
        public float attackCooldown = 1f;
        public LayerMask enemyLayer;
        public BatAnimator batAnimator;
        public Transform cameraTransform;

        private float attackTimer = 0f;

        void Update()
        {
            attackTimer += Time.deltaTime;

            if (Input.GetMouseButtonDown(0) && attackTimer >= attackCooldown)
            {
                attackTimer = 0f;
                Attack();
            }
        }

        void Attack()
        {
            if (batAnimator != null)
                batAnimator.Swing();

            Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, attackRange, enemyLayer))
            {
                if (hit.collider.TryGetComponent(out EnemyStunnable enemy))
                    enemy.Stun(2f);
            }
        }
    }
}