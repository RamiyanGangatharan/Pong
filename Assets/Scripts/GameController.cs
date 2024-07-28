using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * GameController class is responsible for managing the overall game logic 
 * of the Pong game. It handles the initialization, score updates, and UI updates.
 */
public class GameController : MonoBehaviour
{
    public GameObject gameOverUI; // Game Over UI panel

    // Start is called before the first frame update.
    // This method initializes the game by loading existing game data and updating the UI.
    private void Start() { gameOverUI.SetActive(false); }

    // Ends the game session and shows the Game Over UI
    public void EndGame()
    {
        // Show the Game Over UI, then stop the game time and load the GameOver scene
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        SceneManager.LoadScene("GameOver");
    }

    // Reset the game time and load the MainScene to restart the game
    public void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("SinglePlayer");
    }
}
