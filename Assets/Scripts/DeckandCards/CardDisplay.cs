using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
   
    
    public Card card;
    public Text nametext;
    public Text descriptiontext;
    public Image image;
    
    public Text attacktext;
  
    public Deck scriptdeck;
    public int myslot;
    public int attackdmg;

    public string NombredelaCartayEjecutarPasiva;
    public Player player;
    public StadisticPlayer StatsPlayerScript;

    public AudioSource MyAudioSource;
    public AudioClip BigBangAudio;
    public AudioClip fireExplosionAudio;
    public AudioClip DestructionAudio;

    public AudioClip NormalAudioCard;
    public AudioClip komori;
    public AudioClip musicBox;
    public AudioClip railgun;
   

    private void Start()
    {
        
        nametext.text = card.name;
        descriptiontext.text = card.description;
        image.sprite = card.image;
       
        attacktext.text = card.attack.ToString();
        

    }
    public void PlayAudio(AudioClip AC)
    {
        MyAudioSource.clip = AC;
        MyAudioSource.Play();
    }
    public int Thecarddmg()
    {
        if(myslot == 1)
        {
            attackdmg = card.attack;
            return (attackdmg);
        }
        else if(myslot == 2)
        {
            attackdmg = card.attack;
            return (attackdmg);
        }
        else
        {
            attackdmg = card.attack;
            return (attackdmg);
        }
    }
    public void actualizarinfodeUIdeCadaCarta()
    {
        nametext.text = card.name;
        descriptiontext.text = card.description;
        image.sprite = card.image;
        
        attacktext.text = card.attack.ToString();
       
    }

    public void ejecutarpasivadelacarta()
    {
        NombredelaCartayEjecutarPasiva = card.name;
        /*if(NombredelaCartayEjecutarPasiva=="Sacred Font")
        {
            player.PlayerHealth += 5;
            Debug.Log("te has curado 5 puntos de salud");

        }*/
        switch (NombredelaCartayEjecutarPasiva)
        {
            case "Sacred Font":
                StatsPlayerScript.health += 5;
                PlayAudio(komori);
                Debug.Log("Te has curado 5 puntos de salud");
                break;

            case "Big Bang":
                PlayAudio(BigBangAudio);
                break;
            case "Fire Explosion":
                PlayAudio(fireExplosionAudio);
                break;
            case "Destruction":
                PlayAudio(DestructionAudio);
                break;
            case "cristal Pierce":
                PlayAudio(komori);
                break;
            case "Magestic":
                PlayAudio(komori);
                break;
            case "Mortal Punch":
                PlayAudio(railgun);
                break;
            case "Weak Punch":
                PlayAudio(musicBox);
                break;


        }

    }
    
}
