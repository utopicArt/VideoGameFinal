using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    Archivo de configuración del brillo mediante slider
*/

public class panelBrillo : MonoBehaviour{

    public Slider slider;
    public GameObject panelBrightness;
    private Image img;

    void Start(){
        img = panelBrightness.GetComponent<Image>();
    }

    public void setBrillo(){
        if (img){
            img.color = new Color(0f, 0f, 0f, (1 - (slider.value * 0.01f)));
        }
    }
}