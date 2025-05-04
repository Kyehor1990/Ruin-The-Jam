using UnityEngine;

namespace Mehmet
{
    public class ProjectileShooter : MonoBehaviour
    {
        public Transform firePoint;             // Merminin çıkış noktası
        public GameObject currentProjectile;    // Anlık aktif mermi prefabı
        public float projectileForce = 20f;     // Fırlatma hızı

        public AudioSource audioSource;
        public AudioClip soundClip;

        void Update()
        {
            if (Input.GetMouseButtonDown(1)) // Sağ tık
            {
                Fire();
            }
        }

        void Fire()
        {
            if (currentProjectile == null || firePoint == null) return;

            GameObject projectile = Instantiate(currentProjectile, firePoint.position, firePoint.rotation);
        
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(firePoint.forward * projectileForce, ForceMode.Impulse);
            }
            audioSource.PlayOneShot(soundClip);
        }

        // Dışarıdan mermi değiştirmek için (örneğin silah sistemi kullanıyorsan)
        public void SetProjectile(GameObject newProjectile)
        {
            currentProjectile = newProjectile;
            Debug.Log(newProjectile);
        }
    }
}