using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
    Archivo de obtencion de la configuración guardada
*/

public class getSaved : MonoBehaviour
{

    public GameObject panelBrightness;
    public Slider brightnessSlider, volumeSlider;
    private float brightness;
    private Image brightnessLevel;
    private float volume;

    void Start()
    {
        brightnessLevel = panelBrightness.GetComponent<Image>();
        obtenerConfiguración();
    }

    public void obtenerConfiguración()
    {
        brightness = PlayerPrefs.GetFloat("brightness", 0.01f);
        volume = (100f * PlayerPrefs.GetFloat("volume", 0.25f));

        brightness = (brightness != 0f ? (int)Math.Round((brightness - 1) / -0.01) : 0f);
        brightnessSlider.value = brightness;
        volumeSlider.value = volume;
        brightnessLevel.color = new Color(0f, 0f, 0f, (1 - (brightnessSlider.value * 0.01f)));
    }
}
