using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject winScreen;
    public int winScore = 20;
    public bool gameWon = false;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        if (gameWon) return;

        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();

        if (playerScore >= winScore)
        {
            winGame();
        }
    }

    public void restartGame()
    {
        Time.timeScale = 1; // Resume game in case it was paused
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        if (!gameWon)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void winGame()
    {
        gameWon = true;
        Time.timeScale = 0; // Pause game
        winScreen.SetActive(true);
    }
}
