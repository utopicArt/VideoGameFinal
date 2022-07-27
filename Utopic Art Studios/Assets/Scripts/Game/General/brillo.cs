using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class brillo : MonoBehaviour{

    public GameObject brilloContainer;
    private Image nivelBrillo;
    
    void Start(){
        float b = PlayerPrefs.GetFloat("brillo", 0f);
        nivelBrillo = brilloContainer.GetComponent<Image>();
        nivelBrillo.color = new Color(0f,0f,0f,b);
    }
}