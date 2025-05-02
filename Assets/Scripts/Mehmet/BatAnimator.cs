using UnityEngine;

namespace Mehmet
{
    public class BatAnimator : MonoBehaviour
    {
        public Animator animator;

        public void Swing()
        {
            if (animator != null)
            {
                animator.SetTrigger("Swing");
            }
        }
    }
}