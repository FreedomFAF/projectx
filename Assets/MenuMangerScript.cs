using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMangerScript : MonoBehaviour
{
    // Manage all functions for menu
    public void QuitGame() {
        Application.Quit();
    }
    
    public int gameStartScene;

    public void StartGame() {
        SceneManager.LoadScene(gameStartScene);
    }

}
