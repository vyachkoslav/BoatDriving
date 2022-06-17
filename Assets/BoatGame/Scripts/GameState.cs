using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    [SerializeField] GameObject endMenu;
    [SerializeField] TMPro.TextMeshProUGUI stateText;
    const string k_winText = "You won!";
    const string k_loseText = "You lost!";

    public void WinState()
    {
        endMenu.SetActive(true);
        stateText.text = k_winText;
        PauseGame();
    }
    public void LoseState()
    {
        endMenu.SetActive(true);
        stateText.text = k_loseText;
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
