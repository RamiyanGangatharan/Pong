using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // TODO FIX THE DAMN PAUSE MENU AS IT DOES NOT STOP TIME
    private float previousTimeScale;

    void Update()
    {  
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale > 0) { Pause(); }
            else { Resume(); }
        }
    }

    void Pause()
    {
        previousTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
    }

    public void Resume()
    {
        Time.timeScale = previousTimeScale;
        SceneManager.UnloadSceneAsync("PauseMenu");
    }
}
