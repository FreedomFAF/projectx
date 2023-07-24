using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour
{    
    public int gameStartScene;
    public int optionsScene;
    public int mainMenuScene;

    public void StartGame() {
        SceneManager.LoadScene(gameStartScene);
    }

    public void GoToOptionsScene() {
        SceneManager.LoadScene(optionsScene);
    }

    public void GoToMainMenuScene() {
        SceneManager.LoadScene(mainMenuScene);
    }

    // Manage all functions for menu
    public void QuitGame() {
        Application.Quit();
    }

}
