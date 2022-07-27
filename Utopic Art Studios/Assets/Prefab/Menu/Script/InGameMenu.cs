using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    public GameObject canvasPausa;
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
        if (canvasPausa){
            canvasPausa.SetActive(true);
            playerPrefab.GetComponent<PlayerController>().enabled = false;
        }
        panelPausa.SetActive(true);
        canvasPausa.GetComponent<CanvasGroup>().alpha = 1f;
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame(){
        if (canvasPausa){
            canvasPausa.SetActive(false);
            playerPrefab.GetComponent<PlayerController>().enabled = true;
        }
        panelPausa.SetActive(false);
        canvasPausa.GetComponent<CanvasGroup>().alpha = 0f;
        isPaused = false;
        Time.timeScale = 1f;
    }
}
