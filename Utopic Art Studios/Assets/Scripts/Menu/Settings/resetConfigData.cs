using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resetConfigData : MonoBehaviour{

    public Slider brightnessSlider, volumeSlider;

    public void resetData(){
        //PlayerPrefs.DeleteAll();
        brightnessSlider.value = 100;
        volumeSlider.value = 25;
    }
}
