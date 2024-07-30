using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * GameController class is responsible for managing the overall game logic 
 * of the Pong game. It handles the initialization, score updates, and UI updates.
 */
public class GameController : MonoBehaviour
{
    public GameObject gameOverUI; // Game Over UI panel
    private float previousTimeScale;

    private void Start()
    {
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
        }
        Time.timeScale = 1f;
    }

    public void EndGame()
    {
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }
        Time.timeScale = 0f;
        SceneManager.LoadScene("GameOver");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
