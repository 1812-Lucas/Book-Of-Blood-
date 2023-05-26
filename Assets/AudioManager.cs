using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixer Mixer;
    public Slider MasterSlider;

    public void Update()
    {
        Mixer.SetFloat("MasterVolume", MasterSlider.value);
    }
}
