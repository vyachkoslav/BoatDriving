using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BoatGame
{
    public class GameState : MonoBehaviour
    {
        [SerializeField] GameObject endMenu;
        [SerializeField] TMPro.TextMeshProUGUI stateText;
        const string k_winText = "You won!";
        const string k_loseText = "You lost!";

        public void WinState()
        {
            SetState(k_winText);
        }
        public void LoseState()
        {
            SetState(k_loseText);
        }
        void SetState(string text)
        {
            endMenu.SetActive(true);
            stateText.text = text;
            PauseGame();
        }
        void PauseGame()
        {
            Time.timeScale = 0f;
        }
        public static void ResetGame()
        {
            Time.timeScale = 1f;
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        public static void Exit()
        {
            Application.Quit();
        }
    }
}