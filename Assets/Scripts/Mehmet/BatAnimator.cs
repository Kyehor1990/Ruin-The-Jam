using UnityEngine;
using DG.Tweening;

namespace Mehmet
{
    public class BatAnimator : MonoBehaviour
    {
        public float twistAmount = 20f;    // Ne kadar burulacak
        public float duration = 0.1f;      // Ne kadar sürecek

        public void Twist()
        {
            transform.DOLocalRotate(new Vector3(0, 0, -twistAmount), duration)
                .SetEase(Ease.OutQuad)
                .OnComplete(() =>
                {
                    transform.DOLocalRotate(Vector3.zero, duration)
                        .SetEase(Ease.InQuad);
                });
        }

        public void Swing()
        {
            // buraya dot twenn ile bir animasyon yazılacak 
            
        }
    }
}