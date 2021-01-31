using UnityEngine;

public class PauseManager : Singleton<PauseManager>
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject pauseIcon;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
    
    public void PauseGame()
    {
        pauseScreen.SetActive(!pauseScreen.activeSelf);
        pauseIcon.SetActive(!pauseIcon.activeSelf);
    }

    public void BackToMainMenu()
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

    public void Settings()
    {
        Debug.Log("LoadSettings.Call");
        //todo: screen manager to settings menu here
    }
}