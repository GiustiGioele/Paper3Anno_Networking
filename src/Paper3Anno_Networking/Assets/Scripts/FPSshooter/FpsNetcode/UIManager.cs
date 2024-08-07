using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;

namespace FPShooter
{
    public class UIManager : NetworkBehaviour
    {
        [SerializeField] private Button startServerButton;
        [SerializeField] private Button startHostButton;
        [SerializeField] private Button startClientButton;
        // [SerializeField] private TextMeshProUGUI playersInGameText;

        private void Awake()
        {
            Cursor.visible = true;
        }

        private void Start()
        {
            startServerButton.onClick.AddListener(() => {
                if (NetworkManager.Singleton.StartServer()) {
                    Logger.Instance.LogInfo("Server started ...");
                    LoggerText.Instance.LogText("Server started ...");
                }
                else {
                    Logger.Instance.LogInfo("Server could not started ...");
                    LoggerText.Instance.LogText2("Server could not started ...");
                }
            });
            startHostButton.onClick.AddListener(() => {
                Debug.Log("host button clicked");
                if (NetworkManager.Singleton.StartHost()) {
                    Logger.Instance.LogInfo("Host started ...");
                    LoggerText.Instance.LogText("Host started ...");
                }
                else {
                    Logger.Instance.LogInfo("Host could not be started ...");
                    LoggerText.Instance.LogText2("Host could not be started ...");
                }
            });
            startClientButton.onClick.AddListener(() => {
                if (NetworkManager.Singleton.StartClient()) {
                    Logger.Instance.LogInfo("Client started ...");
                    LoggerText.Instance.LogText("Client started ...");
                }
                else {
                    Logger.Instance.LogInfo("Client could not started ...");
                    LoggerText.Instance.LogText2("Client could not started ...");
                }
            });
        }

        private void Update()
        {

        }
    }
}

