using System.Collections;
using TMPro;
using UnityEngine;

namespace Mehmet
{
    public class NpcDialog : MonoBehaviour
    {
        [Header("Referanslar")]
        public GameObject dialogCanvas;
        public GameObject eKeySprite;
        public TextMeshProUGUI dialogText;
        public AudioSource audioSource;
        public AudioClip[] dialogSounds;

        [Header("Birinci Diyalog")]
        [TextArea(2, 5)]
        public string[] dialogLines;

        [Header("İkinci Diyalog")]
        [TextArea(2, 5)]
        public string[] secondaryDialogLines;
        
        [Header("Üçüncü Diyalog")]
        [TextArea(2, 5)]
        public string[] thirtDialogLines;

        [Header("Ayarlar")]
        public float textSpeed = 0.03f;
        public float interactionDistance = 3f;

        private Transform player;
        private int currentLine = 0;
        private bool isPlayerNear = false;
        private bool isTyping = false;
        private string[] currentDialog;

        private bool secondaryDialogActive = false;

        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            dialogCanvas.SetActive(false);
            eKeySprite.SetActive(false);

            currentDialog = dialogLines; // Varsayılan birinci diyalog
        }

        void Update()
        {
            float distance = Vector3.Distance(player.position, transform.position);
            isPlayerNear = distance <= interactionDistance;

            // "E" sprite'ı göster/gizle
            if (!dialogCanvas.activeSelf)
                eKeySprite.SetActive(isPlayerNear);
            else
                eKeySprite.SetActive(false);

            if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
            {
                if (!dialogCanvas.activeSelf)
                {
                    currentLine = 0;
                    dialogCanvas.SetActive(true);
                    StartCoroutine(TypeLine());
                }
                else if (!isTyping)
                {
                    currentLine++;
                    if (currentLine < currentDialog.Length)
                    {
                        StartCoroutine(TypeLine());
                    }
                    else
                    {
                        dialogCanvas.SetActive(false);
                        dialogText.text = "";
                    }
                }
            }
        }

        IEnumerator TypeLine()
        {
            isTyping = true;
            dialogText.text = "";

            if (audioSource && dialogSounds.Length > 0)
            {
                int randomIndex = Random.Range(0, dialogSounds.Length);
                audioSource.PlayOneShot(dialogSounds[randomIndex]);
            }

            foreach (char c in currentDialog[currentLine])
            {
                dialogText.text += c;
                yield return new WaitForSeconds(textSpeed);
            }

            isTyping = false;
        }

        // 🔥 Bu fonksiyonu çağırınca artık ikinci diyalog gösterilecek
        public void StartSecondaryDialog()
        {
            currentDialog = secondaryDialogLines;
        }

        public void StartThirtDialog()
        {
            currentDialog = thirtDialogLines;
        }
        
        
    }
}
