using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    public void ResumeGame()
    {
        // Find the PauseMenu script in the SinglePlayer scene and call Resume
        PauseMenu pauseMenu = FindObjectOfType<PauseMenu>();
        if (pauseMenu != null) { pauseMenu.Resume(); }
    }
}
