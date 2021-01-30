using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : Singleton<MainMenuManager>
{
    [SerializeField] private MenuState currentMenuState = MenuState.Main;

    public GameObject Main;
    public GameObject Load;
    public GameObject SettingsObj;
    public GameObject Credits;

    public GameObject MainBackground;
    public GameObject SettingsBackground;

    public void SwitchToWindow(MenuState menuState)
    {
        Main.SetActive(menuState == MenuState.Main);
        Load.SetActive(menuState == MenuState.Load);
        SettingsObj.SetActive(menuState == MenuState.Settings);
        //Credits.SetActive(menuState == MenuState.Credits);
    }

    public void ShowCurrentBackground()
    {
        if (currentMenuState == MenuState.Settings)
            ShowMainBackground(false);
        else
            ShowMainBackground(true);
    }

    private void ShowMainBackground(bool isVisible)
    {
        MainBackground.SetActive(isVisible);
        SettingsBackground.SetActive(!isVisible);
    }

    public void StartNewGame()
    {
        Debug.Log("а Ты действительно не плох в нажатии кнопок");
        currentMenuState = MenuState.Load;
        SwitchToWindow(MenuState.Load);
    }

    public void MainMenu()
    {
        Debug.Log("а Ты действительно не плох в нажатии кнопок 2");
        currentMenuState = MenuState.Main;
        ShowCurrentBackground();
        SwitchToWindow(MenuState.Main);
    }

    public void ShowSaves()
    {
        Debug.Log("Loading saves...");
        currentMenuState = MenuState.Settings;
        SwitchToWindow(MenuState.Main);
    }

    public void CreditsRoll()
    {
        Debug.Log("Loading credits...");
        //currentMenuState = MenuState.Credits;
        //SwitchToWindow(MenuState.Credits);
    }

    public void Settings()
    {
        Debug.Log("Here is your settings...");
        currentMenuState = MenuState.Settings;
        ShowCurrentBackground();
        SwitchToWindow(MenuState.Settings);
    }

    public void Quit()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }

    public enum MenuState { Main, Load, Settings, Credits };
}