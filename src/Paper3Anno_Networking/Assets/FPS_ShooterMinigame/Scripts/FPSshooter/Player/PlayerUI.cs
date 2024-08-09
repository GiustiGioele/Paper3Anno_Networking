using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FPShooter
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private Text promptMessageText;
        [SerializeField] private Text enemyPromptMessageText;

        public void UpdateText(string promptMessage, string enemyPromptMessage)
        {
            promptMessageText.text =  promptMessage;
            enemyPromptMessageText.text = enemyPromptMessage;
        }
    }
}

