using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * GameData class is responsible for defining the data structure that holds 
 * the game-related data such as player scores. This class can be extended 
 * to include more game-related data as required.
 */
public class GameOverMenu : MonoBehaviour
{
    GameController controller = new GameController();
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(4);
        controller.RestartGame();
    }
    public void ReturnMenu() { SceneManager.LoadSceneAsync(0); }
}
