using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance { get; private set; }

    public GameObject pauseMenuUI; // Reference to the Pause Menu UI Canvas

    private float previousTimeScale;

    private bool isPaused = false;
    private bool pauseMenuSceneLoaded = false; // Track if the pause menu scene is loaded

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false); // Ensure the pause menu is initially inactive
        }

        // Ensure there's an EventSystem in the scene
        if (FindObjectOfType<EventSystem>() == null)
        {
            GameObject eventSystem = new GameObject("EventSystem");
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        if (!isPaused)
        {
            Debug.Log("Pausing game");
            previousTimeScale = Time.timeScale;
            Time.timeScale = 0f;

            if (pauseMenuUI != null)
            {
                pauseMenuUI.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
                pauseMenuSceneLoaded = true; // Mark the pause menu scene as loaded
            }

            isPaused = true;
            Debug.Log("PauseMenu scene loaded or UI activated");
        }
    }

    public void Resume()
    {
        if (isPaused)
        {
            Debug.Log("Resuming game");
            Time.timeScale = previousTimeScale;

            if (pauseMenuUI != null)
            {
                pauseMenuUI.SetActive(false);
            }
            else if (pauseMenuSceneLoaded)
            {
                SceneManager.UnloadSceneAsync("PauseMenu").completed += (asyncOperation) =>
                {
                    Debug.Log("PauseMenu scene unloaded");
                };
                pauseMenuSceneLoaded = false; // Mark the pause menu scene as unloaded
            }

            isPaused = false;
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Time.timeScale = 1f; // Ensure the game time is running before quitting
        SceneManager.LoadScene("MainMenu"); // Load your main menu scene
    }
}
