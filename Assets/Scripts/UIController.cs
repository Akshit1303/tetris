using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour {
    // gameOverPanel UI for game text
    public GameObject gameOverPanel;
    public static GameObject gameOverPanelStatic;


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
    }
        

	// Update is called once per frame
	void Update () {
        // NOTE: this doesn't belong to here... this should not here... ARGH
        // exit the game if presed ESC
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        } else if (gameOverPanel.activeSelf && Input.anyKeyDown) {
            gameOverPanel.SetActive(false);
            restart();
        } else if (Input.GetKeyDown(KeyCode.R)) {
            restart();  
        }
	}
}
