using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sonidoController : MonoBehaviour{
    public Image mute, midd, up;
    public Slider slider;
    private int volume;
    private float active;

    public void volumeLayer(){
        volume = (int)Math.Round(slider.value);
        active = (slider.value * 0.03f);
        active = (active <= 0.40f ? 0.4f : active);

        if (volume > 0 && volume < 50){
            setVolumeLayer((float)(1 - (slider.value * 0.0122449f)), active, 0.3f);
        }
        else if (volume >= 50){
            active = (1 - (1 - (slider.value / 50f)) * - 1);
            active = (active <= 0.4f ? 0.4f : active);
            setVolumeLayer(0.3f, active, (float)(slider.value * 0.00999f));
        }else{
            setVolumeLayer(1f, 0.3f, 0.3f);
        }
    }

    private void setVolumeLayer(float _defaultA, float _defaultB, float _defaultC){
        mute.color = new Color(1f, 1f, 1f, _defaultA);
        midd.color = new Color(1f, 1f, 1f, _defaultB);
        up.color = new Color(1f, 1f, 1f, _defaultC);
    }
}