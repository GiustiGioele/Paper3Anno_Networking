using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Text promptMessageText;

    public void UpdateText(string promptMessage)
    {
        promptMessageText.text =  promptMessage;
    }
}