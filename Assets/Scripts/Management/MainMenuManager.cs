using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public void StartNewGame()
    {
        Debug.Log("а Ты действительно не плох в нажатии кнопок");
    }

    public void ShowSaves()
    {
        Debug.Log("Loading saves...");
    }

    public void CreditsRoll()
    {
        Debug.Log("Loading credits...");
    }

    public void Settings()
    {
        Debug.Log("Here is your settings...");
    }

    public void Quit()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }
}