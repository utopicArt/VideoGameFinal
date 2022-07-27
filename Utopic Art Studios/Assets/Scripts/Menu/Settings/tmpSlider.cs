using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

/*
    Archivo de configuración del TMP del valor del slider
*/
public class tmpSlider : MonoBehaviour{

    public Slider mainSlider;
    
    void Update(){
        this.GetComponent<TMP_Text>().text = ((int)Math.Round(mainSlider.value)).ToString();
    }
}