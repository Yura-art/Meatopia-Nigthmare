using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    public GameObject inGameUIPanel;
    public GameObject pausePanel;
    public GameObject gameOverPanel;

    void Start()
    {
        Time.timeScale = 1;
        inGameUIPanel.SetActive(true);
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        inGameUIPanel.SetActive(false);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        inGameUIPanel.SetActive(true);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        inGameUIPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("UIMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
