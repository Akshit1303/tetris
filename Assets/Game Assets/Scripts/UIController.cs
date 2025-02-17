using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour {
    // gameOverPanel UI for game text
    public GameObject gameOverPanel;
    public GameObject pausePanel;
    public static GameObject gameOverPanelStatic;
    public static float gameOverTime = 0;
    public static bool isPaused = false;


    void Awake() {
        if (gameOverPanelStatic == null) {
            gameOverPanelStatic = gameOverPanel;
        }
    }
	
    // restart the game 
    void restart() {
        Debug.Log("RESTART GAME!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // terminate the game
    public static void gameOver() {
        gameOverPanelStatic.SetActive(true);
        gameOverTime = Time.time;
    }

    void gotoMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    void togglePause() {
        Time.timeScale = Time.timeScale > 0 ? 0f : 1f;
        pausePanel.SetActive(!pausePanel.activeSelf);
        isPaused = !isPaused;
    }

	
	void Update () {
       
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        } else if (Input.GetKeyDown(KeyCode.P)) {
            togglePause();
        }
        else if (Input.GetKeyDown(KeyCode.R)) {
            restart();  
        } else if (gameOverPanel.activeSelf && Input.anyKeyDown && Time.time - gameOverTime >= 0.5f) {
         
            gotoMainMenu();
        } 
	}
}
