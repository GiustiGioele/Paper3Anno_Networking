using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FPShooter
{
    public class GameOverManager : MonoBehaviour
    {
        public void RestartGame()
        {
            SceneManager.LoadScene("FpsShooter");
        }

        // public void ReturnToMenu()
        // {
        //     UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        // }
    }

}
