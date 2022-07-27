using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class difcultadController : MonoBehaviour
{

    public void setDificultad(int difficulty)
    {
        PlayerPrefs.SetInt("difficulty", difficulty);
    }
}
