using UnityEngine;

namespace Mehmet
{
    public class BatAnimator : MonoBehaviour
    {
        private Animator animator;

        void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void Swing()
        {
            animator.SetTrigger("Swing");
        }
    }
}