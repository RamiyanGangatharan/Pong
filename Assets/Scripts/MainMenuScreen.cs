using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour
{
    public void PlayGame(string gameMode)
    {
        if (gameMode == "Singleplayer")
        {
            SceneManager.LoadSceneAsync(4); 
        }
        else if (gameMode == "Multiplayer")
        {
            SceneManager.LoadSceneAsync(5); 
        }
    }

    public void ExitGame() { Application.Quit(); }
    public void MainMenu() { SceneManager.LoadScene("MainMenu"); } 
    public void AboutPage() { SceneManager.LoadScene("AboutPage"); }
}
