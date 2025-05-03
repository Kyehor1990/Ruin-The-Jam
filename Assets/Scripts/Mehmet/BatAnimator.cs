using DG.Tweening;
using UnityEngine;


namespace Mehmet
{
    public class BatAnimator : MonoBehaviour
    {
        public float swingAngle = 60f;     // Ne kadar öne savrulsun
        public float swingDuration = 0.2f; // Savrulma süresi
        public float returnDuration = 0.1f;// Geri dönüş süresi

        public void Swing()
        {
            // Öne doğru eğilme (Z ekseninde saat yönü)
            transform.DOLocalRotate(new Vector3(swingAngle, 0, 0), swingDuration, RotateMode.LocalAxisAdd)
                .SetEase(Ease.OutQuad)
                .OnComplete(() =>
                {
                    // Eski konumuna dön
                    transform.DOLocalRotate(new Vector3(-swingAngle, 0, 0), returnDuration, RotateMode.LocalAxisAdd)
                        .SetEase(Ease.InQuad);
                });
        }
    }
    
}