using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * GameController class is responsible for managing the overall game logic 
 * of the Pong game. It handles the initialization, score updates, and UI updates.
 */
public class GameController : MonoBehaviour
{
    public GameObject gameOverUI; // Game Over UI panel

    private GameData gameData; // Instance of GameData to hold the current game state

    // Start is called before the first frame update.
    // This method initializes the game by loading existing game data and updating the UI.
    private void Start()
    {
        gameData = FileManager.LoadData();
        gameOverUI.SetActive(false); // Ensure the Game Over UI is initially hidden
    }

    // Updates the score for a player and saves the game data.
    public void PlayerScored(int playerNumber)
    {
        if (playerNumber == 1)
        {
            gameData.player1Score++;
        }
        else if (playerNumber == 2)
        {
            gameData.player2Score++;
        }
        FileManager.SaveData(gameData);
    }

    // Ends the game session and shows the Game Over UI
    public void EndGame()
    {
        // Show the Game Over UI
        gameOverUI.SetActive(true);

        // Optionally, stop the game time
        Time.timeScale = 0f;

        // Load the GameOver scene
        SceneManager.LoadScene("GameOver");
    }

    // Restarts the game by reloading the scene
    public void RestartGame()
    {
        Time.timeScale = 1f; // Reset the game time

        // Load the MainScene to restart the game
        SceneManager.LoadScene("MainScene");
    }
}
