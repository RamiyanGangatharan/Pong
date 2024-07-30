using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * GameOverMenu class is responsible for handling the game over menu actions 
 * such as restarting the game or returning to the main menu.
 */
public class GameOverMenu : MonoBehaviour
{
    private GameController controller;

    private void Start()
    {
        controller = FindObjectOfType<GameController>();
    }

    public void PlayGame(string gameMode)
    {
        if (gameMode == "Singleplayer")
        {
            SceneManager.LoadScene(4); 
        }
        else if (gameMode == "Multiplayer")
        {
            SceneManager.LoadScene(5); 
        }
        controller.RestartGame();
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("MainMenu"); 
    }
}
