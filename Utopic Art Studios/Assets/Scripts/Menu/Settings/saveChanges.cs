using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    Archivo de guardado de configuraciones
*/

public class saveChanges : MonoBehaviour
{
    public Slider brightnessSlider, volumeSlider;
    public GameObject message, mainPanel, panelConfig;

    public void Nuevoscambios()
    {
        float savedBrightness = PlayerPrefs.GetFloat("brightness", 0.01f);
        float savedVolume = (100f * PlayerPrefs.GetFloat("volume", 0.25f));
        bool newChanges = false;

        savedBrightness = (savedBrightness != 0 ? (int)Math.Round((savedBrightness - 1) / -0.01) : 0);

        if (!brightnessSlider.value.Equals(savedBrightness))
        {
            newChanges = true;
        }
        if (!volumeSlider.value.Equals(savedVolume))
        {
            newChanges = true;
        }

        message.SetActive((newChanges?true:false));
        mainPanel.SetActive((newChanges?false:true));
        panelConfig.SetActive((newChanges?true:false));
    }

    public void comparar()
    {
        float savedBrightness = PlayerPrefs.GetFloat("brightness", 0.01f);
        int savedVolume = (int)Math.Round(PlayerPrefs.GetFloat("volume", 0.5f));

        if (!savedBrightness.Equals(1 - (brightnessSlider.value * 0.01f)))
        {
            guardar("brightness");
        }
        if (!savedVolume.Equals(1 - (volumeSlider.value * 0.01f)))
        {
            guardar("volume");
        }
    }

    public void guardar(string componente)
    {
        switch (componente)
        {
            case "brightness":
                float levelOfBrightness = (1 - (brightnessSlider.value * 0.01f));
                PlayerPrefs.SetFloat("brightness", levelOfBrightness);
                Image bright = GameObject.Find("Panel Brillo").GetComponent<Image>();
                if (bright != null)
                {
                    bright.color = new Color(0f, 0f, 0f, levelOfBrightness);
                }                
                break;
            case "volume":
                PlayerPrefs.SetFloat("volume", (volumeSlider.value * 0.01f));
                break;
        }
    }
}
