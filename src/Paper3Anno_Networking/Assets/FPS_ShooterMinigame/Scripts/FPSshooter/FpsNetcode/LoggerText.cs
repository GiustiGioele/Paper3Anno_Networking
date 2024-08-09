using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace FPShooter
{
    public class LoggerText : MonoBehaviour
    {
        public static LoggerText Instance { get; private set; }

        [SerializeField] private Text logText;
        [SerializeField] private Text logText2; // O TextMeshProUGUI per TMP
        [SerializeField] private float messageDuration; // Durata in secondi

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void LogText(string message)
        {
            if (logText != null)
            {
                // Mostra logText e nasconde logText2
                StartCoroutine(ShowMessage(logText, message));
                HideText(logText2);
            }
        }

        public void LogText2(string message2)
        {
            if (logText2 != null)
            {
                // Mostra logText2 e nasconde logText
                StartCoroutine(ShowMessage(logText2, message2));
                HideText(logText);
            }
        }

        private IEnumerator ShowMessage(Text textComponent, string message)
        {
            textComponent.text = message;
            textComponent.gameObject.SetActive(true);

            // Aspetta per la durata specificata
            yield return new WaitForSeconds(messageDuration);

            // Nascondi il testo dopo il tempo specificato
            textComponent.text = "";
            textComponent.gameObject.SetActive(false);
        }

        private void HideText(Text textComponent)
        {
            if (textComponent != null)
            {
                textComponent.text = "";
                textComponent.gameObject.SetActive(false);
            }
        }
    }
}
