
using Unity.Netcode;
namespace FPShooter
{
    public class PlayersManager : NetworkSingleton<PlayersManager>
    {
        NetworkVariable<int> _playersInGame = new NetworkVariable<int>();

        public int PlayersInGame
        {
            get
            {
                return _playersInGame.Value;
            }
        }

        void Start()
        {
            NetworkManager.Singleton.OnClientConnectedCallback += (id) =>
            {
                if(IsServer)
                    _playersInGame.Value++;
            };

            NetworkManager.Singleton.OnClientDisconnectCallback += (id) =>
            {
                if(IsServer)
                    _playersInGame.Value--;
            };
        }
    }
}

