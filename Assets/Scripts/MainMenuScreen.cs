using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour
{
    GameController controller = new GameController();

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(0);
        controller.RestartGame();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void AboutPage()
    {
        SceneManager.LoadSceneAsync(4);
    }
}
