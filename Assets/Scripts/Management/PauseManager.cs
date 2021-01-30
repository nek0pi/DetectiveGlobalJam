using UnityEngine;

public class PauseManager : Singleton<PauseManager>
{
    [SerializeField] private GameObject pauseScreen;
    public static bool gameIsPaused;
    
    void Start()
    {
        pauseScreen.SetActive(gameIsPaused);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
    
    public void PauseGame()
    {
        gameIsPaused = !gameIsPaused;
        if(gameIsPaused)
        {
            Time.timeScale = 0f;
            pauseScreen.SetActive(!gameIsPaused);
        }
        else 
        {
            Time.timeScale = 1;
            pauseScreen.SetActive(!gameIsPaused);
        }
    }

    public void LoadMenuScreen()
    {
        Debug.Log("LoadMenuScreen.Call");
        PauseGame();
        //todo: screen manager to main menu here
    }

    public void SaveGame()
    {
        Debug.Log("SaveGame.Call");
        //todo: save manager to save game here
    }

    public void LoadGame()
    {
        Debug.Log("LoadGame.Call");
        //todo: save manager to load game here
    }

    public void LoadSettings()
    {
        Debug.Log("LoadSettings.Call");
        //todo: screen manager to settings menu here
    }
}