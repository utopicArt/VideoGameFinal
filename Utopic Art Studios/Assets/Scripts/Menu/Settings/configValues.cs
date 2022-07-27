using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;
using System;

/*
    Archivo de configuración del value del slider
*/

public class configValues : MonoBehaviour
{
    public Slider mainSlider;
    public GameObject panelBrightness;
    private Image img;

    void Start()
    {
        img = panelBrightness.GetComponent<Image>();
        int value = (int)Math.Round((PlayerPrefs.GetFloat("brightness", 0.01f) - 1) / -0.01);
        mainSlider.value = value;
    }

    public void setBrillo()
    {
        img.color = new Color(0f, 0f, 0f, (1 - (mainSlider.value * 0.01f)));
    }
}