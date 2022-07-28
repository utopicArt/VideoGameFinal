using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    public GameObject panelPausa;
    public GameObject playerPrefab;
    public static bool isPaused;

    void Start()
    {
        isPaused = false;
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (isPaused){
                ResumeGame();
            }
            else{
                PauseGame();
            }
        }
    }

    public void PauseGame(){
        playerPrefab.GetComponent<PlayerController>().enabled = false;
        panelPausa.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame(){
        playerPrefab.GetComponent<PlayerController>().enabled = true;
        panelPausa.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }
}
