using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsMenu;

    public void StartGame()
    {
        SceneManager.LoadScene("sl_ServerLobby");
    }

    public void OpenSettingsMenu()
    {
        if (settingsMenu != null)
        {
            bool isActive = settingsMenu.activeSelf;
            settingsMenu.SetActive(!isActive);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
