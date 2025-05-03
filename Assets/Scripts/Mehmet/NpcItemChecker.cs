using UnityEngine;

namespace Mehmet
{
    public class NpcItemChecker : MonoBehaviour
    {
        public string requiredTag;
        public NpcDialog _npcDialog;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("çarpıştı");
            if (other.CompareTag(requiredTag))
            {
                Destroy(other.gameObject); // Nesneyi yok et
                DoCorrectAction();         // Doğru işlem
                
            }
            else
            {
                Destroy(other.gameObject); // Yine yok et
                DoWrongAction();           // Yanlış işlem
            }
        }

        void DoCorrectAction()
        {
            Debug.Log("Doğru eşya geldi, görevi tetikle!");
            _npcDialog.StartSecondaryDialog();
        }

        void DoWrongAction()
        {
            Debug.Log("Yanlış eşya geldi, cezayı ver!");
            _npcDialog.StartThirtDialog();
        }
    }
}