using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

/*
    Archivo de controlador de levels y dificultad
*/

public class levelController : MonoBehaviour
{
    private int gameLevel = 0;
    private Color c;
    public GameObject message;

    public void setLevel(int level)
    {
        GameObject[] levels;
        levels = GameObject.FindGameObjectsWithTag("Nivel");
        gameLevel = level;
        foreach (GameObject btn in levels)
        {
            c = btn.GetComponent<Image>().color;
            c.a = 0f;
            btn.GetComponent<Image>().color = c;
        }
        c = levels[level - 1].GetComponent<Image>().color;
        c.a = 0.29f;
        levels[level - 1].GetComponent<Image>().color = c;
        PlayerPrefs.SetInt("level", level);
    }

    public void goBack()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void comprobarValores()
    {
        int dificultad = PlayerPrefs.GetInt("difficulty", 2);
        if (gameLevel > 0){
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else{
            message.SetActive(true);
        }
    }

    public void loadLevel()
    {
        int level = PlayerPrefs.GetInt("level", 1);
        int introductionLevel = PlayerPrefs.GetInt("intro", 0);
        SceneManager.LoadScene((introductionLevel==0?6: level));
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
