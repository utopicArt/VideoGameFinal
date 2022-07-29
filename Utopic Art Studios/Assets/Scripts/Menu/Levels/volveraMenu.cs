using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 Archivo para volver al menu principal
 */

public class volveraMenu : MonoBehaviour
{
    public void volverMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
