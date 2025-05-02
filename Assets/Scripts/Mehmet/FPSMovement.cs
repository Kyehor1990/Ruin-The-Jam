using UnityEngine;

namespace Mehmet
{
    [RequireComponent(typeof(CharacterController))]
    public class FPSMovement : MonoBehaviour
    {
        [Header("Hareket Ayarları")]
        public float walkSpeed = 8f;
        public float runSpeed = 15f;
        public float gravity = -9.81f;
        public Transform cameraTransform;

        [Header("Stamina Sistemi")]
        public float maxStamina = 100f;
        public float staminaDrainRate = 20f;
        public float staminaRecoveryRate = 15f;

        private CharacterController controller;
        private float stamina;
        private Vector3 velocity;

        void Start()
        {
            controller = GetComponent<CharacterController>();
            stamina = maxStamina;
        }

        void Update()
        {
            Move();
            ApplyGravity();
            HandleStamina();
        }

        void Move()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 inputDirection = new Vector3(horizontal, 0, vertical).normalized;

            if (inputDirection.magnitude >= 0.1f)
            {
                // Kameraya göre yön hesapla
                Vector3 moveDir = cameraTransform.forward * inputDirection.z + cameraTransform.right * inputDirection.x;
                moveDir.y = 0f; // Y ekseni sabit (yukarı-aşağı eğim yok)

                bool isRunning = Input.GetKey(KeyCode.LeftShift) && stamina > 0f;
                float speed = isRunning ? runSpeed : walkSpeed;
                
                Debug.Log(stamina);

                controller.Move(moveDir.normalized * speed * Time.deltaTime);

                if (isRunning)
                    stamina -= staminaDrainRate * Time.deltaTime;
                else
                    stamina += staminaRecoveryRate * Time.deltaTime;
            }
            else
            {
                stamina += staminaRecoveryRate * Time.deltaTime;
            }

            stamina = Mathf.Clamp(stamina, 0f, maxStamina);
        }

        void ApplyGravity()
        {
            if (controller.isGrounded && velocity.y < 0)
                velocity.y = -2f; // yere yapıştır

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

        void HandleStamina()
        {
            // İsteğe bağlı: UI ya da animasyonlara buradan stamina değeri verilebilir
        }

        public float GetStaminaPercent()
        {
            return stamina / maxStamina;
        }
    }
}
