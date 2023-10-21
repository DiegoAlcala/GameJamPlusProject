using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Add this line


public class UIManager : MonoBehaviour
{
    public GameObject onPlayScreen;
    public GameObject StartScreen;
    public GameObject pauseScreen;
    public GameObject loadScreen;
    public GameObject victoryScreen;
    public GameObject gameOverScreen;
    public GameObject player;


    private void Update()
    {
        if(GameManager.Instance!= null)
        {

            if (GameManager.Instance.gameState == GameManager.GameState.InGame)
            {
                StartScreen.SetActive(false);
                onPlayScreen.gameObject.SetActive(true);
                player.SetActive(true);
                pauseScreen.SetActive(false);
                victoryScreen.SetActive(false);
                onPlayScreen.SetActive(true);
            }
            if (GameManager.Instance.gameState == GameManager.GameState.GameOver)
            {
                gameOverScreen.SetActive(true);
                onPlayScreen.SetActive(false);
                pauseScreen.SetActive(false);
                victoryScreen.SetActive(false);
            }
            if (GameManager.Instance.gameState == GameManager.GameState.Pause)
            {
                pauseScreen.SetActive(true);
                onPlayScreen.SetActive(false);
                StartScreen.SetActive(false);
                victoryScreen.SetActive(false);
                

            }
            if (GameManager.Instance.gameState == GameManager.GameState.Menu)
            {
                StartScreen.SetActive(true);
                pauseScreen.SetActive(false);
                onPlayScreen.SetActive(false);
                victoryScreen.SetActive(false);
            }
            if (GameManager.Instance.gameState == GameManager.GameState.Victory)
            {
                StartScreen.SetActive(false);
                pauseScreen.SetActive(false);
                onPlayScreen.SetActive(false);
                victoryScreen.SetActive(true);
            }
        }
    }

    public void PauseButtonClicked()
    {
        GameManager.Instance.gameState = GameManager.GameState.Pause;
    }

    public void MenuButtonClicked()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGameButtonClicked()
    {
        GameManager.Instance.gameState = GameManager.GameState.InGame;
    }

    public void RestartButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Add this line
    }

    public void ExitGameButtonClicked()
    {
        Application.Quit(); // Add this line
    }
}
