using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioController : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider volumeSlider;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void setVolumen()
    {
        audioSource.volume = (volumeSlider.value * 0.01f);
    }
}
