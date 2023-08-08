using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightEvent : MonoBehaviour
{

    public AudioSource MyAudioSource;
    public AudioClip LightOnAudio;
    //public AudioClip[] audiosLightAr;

    public void PlayAudio(AudioClip AC)
    {
        MyAudioSource.clip = AC;
        MyAudioSource.Play();
    }

    [SerializeField] UnityEvent Ev_Activa;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Ev_Activa.Invoke();
            PlayAudio(LightOnAudio);
        }

    }

}
