using System;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
namespace FPShooter
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private Button startServerButton;
        [SerializeField] private Button startHostButton;
        [SerializeField] private Button startClientButton;
        [SerializeField] private TextMeshProUGUI playersInGameText;
        [SerializeField] private TMP_InputField joinCodeInput;

        private bool _hasServerStarted;

        private void Awake()
        {
            Cursor.visible = true;
        }

        private void Update()
        {
            playersInGameText.text = $"Players in game : {PlayersManager.Instance.PlayersInGame}";
        }

        private void Start()
        {
            startServerButton?.onClick.AddListener(() => {
                if (NetworkManager.Singleton.StartServer()) {
                    Logger.Instance.LogInfo("Server started ...");
                }
                else {
                    Logger.Instance.LogInfo("Unable to start server ...");
                }
            });

            startHostButton?.onClick.AddListener(() => {
                if (NetworkManager.Singleton.StartHost()) {
                    Logger.Instance.LogInfo("Host started ...");
                }
                else {
                    Logger.Instance.LogInfo("Unable to start host ...");
                }
            });

            startClientButton?.onClick.AddListener(() => {
                if (NetworkManager.Singleton.StartClient()) {
                    Logger.Instance.LogInfo("Client started ...");
                }
                else {
                    Logger.Instance.LogInfo("Unable to start client ...");
                }
            });

            //status type callback
            NetworkManager.Singleton.OnClientConnectedCallback += (id) => {
                Logger.Instance.LogInfo($"{id} just connected ...");
            };
            NetworkManager.Singleton.OnServerStarted += () => {
                _hasServerStarted = true;
            };

        }
    }
}
