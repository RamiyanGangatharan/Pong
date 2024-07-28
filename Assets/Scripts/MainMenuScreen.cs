using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour
{
    GameController controller = new GameController();

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(4);
        controller.RestartGame();
    }
    public void ExitGame() { Application.Quit(); }
    public void MainMenu() { SceneManager.LoadSceneAsync(0); }
    public void AboutPage() { SceneManager.LoadSceneAsync(1); }
}
