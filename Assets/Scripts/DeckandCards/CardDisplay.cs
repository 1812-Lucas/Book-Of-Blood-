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
    public Enemy enemyy;

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
        if (myslot == 1)
        {
            attackdmg = card.attack;
            return (attackdmg);
        }
        else if (myslot == 2)
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

    public void setenemy(Enemy enemy)
    {
        enemyy = enemy;
    }
    public void BloodFont()
    {
        enemyy.health -= StatsPlayerScript.bloodFontAditionalDamage;
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
                StatsPlayerScript.health += StatsPlayerScript.healingRingPassive;
                BloodFont();
                PlayAudio(komori);
                Debug.Log("you healed");
                break;

            case "Big Bang":
                BloodFont();
                PlayAudio(BigBangAudio);
                break;
            case "Fire Explosion":
                BloodFont();
                PlayAudio(fireExplosionAudio);
                break;
            case "Destruction":
                BloodFont();
                PlayAudio(DestructionAudio);
                break;
            case "cristal Pierce":
                BloodFont();
                PlayAudio(komori);
                break;
            case "Magestic":
                PlayAudio(komori);
                BloodFont();
                break;
            case "Mortal Punch":
                BloodFont();
                PlayAudio(railgun);
                break;
            case "Weak Punch":
                BloodFont();
                PlayAudio(musicBox);
                break;
            case "Blood Font":
                StatsPlayerScript.bloodFontAditionalDamage += 1;
                BloodFont();
                break;
            case "Convertion":
                StatsPlayerScript.health += StatsPlayerScript.vigor;
                StatsPlayerScript.health += StatsPlayerScript.healingRingPassive;
                BloodFont();
                break;
            case "Cursed Mud":
                BloodFont();
                if (StatsPlayerScript.antihealingToEnemies <= 6)
                {
                    StatsPlayerScript.antihealingToEnemies += 2;
                    Debug.Log("the damage taken every time the enemies try to heal is" + StatsPlayerScript.antihealingToEnemies + " points of damage");

                }
                else
                {
                    Debug.Log("You already got the max stacks of Cursed Mud ");
                }
                break;
            case "Giant Killer":
                float PorcentageReduction = enemyy.health * 0.25f;
                int ResultRounded = (int)Math.Round(PorcentageReduction);
                enemyy.health -= ResultRounded;
                BloodFont();
                break;
            case "Healing Ring":
                StatsPlayerScript.healingRingPassive += 1;
                BloodFont();
                break;
            case "Nemea BreastPlate":
                if (StatsPlayerScript.damageReduction <= 2)
                {
                    StatsPlayerScript.damageReduction += 1;
                }
                BloodFont();
                break;
            case "Nemesis":
                enemyy.health -= StatsPlayerScript.vigor;
                BloodFont();
                break;


        }

    }

}
