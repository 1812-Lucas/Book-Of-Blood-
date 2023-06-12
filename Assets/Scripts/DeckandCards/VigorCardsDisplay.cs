using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VigorCardsDisplay : MonoBehaviour
{
    public VigorCards card;
    public Text nametext;
    public Text descriptiontext;
    public Image image;

    public Text vigortext;
    public VigorDeck vigorscriptdeck;
    public int myslot;
    public int thevigorCostOfMyCard;

    public string NombredelaCartadeVigoryEjecutarPasiva;
    public Player player;
    public StadisticPlayer stadisticplayerScipt;
    private int SpiritGrowthStacks;
    private int ProtectionTottemStacks;
    public Enemy enemyy;

    public AudioSource MyAudioSource;
    public AudioClip WarriorPendantAudio;
    public AudioClip DeadEyeAudio;
    public AudioClip CaosAudio;


   // private void Awake()
    //{
        //MyAudioSource = GetComponent<AudioSource>();
    //}
    public void PlayAudio(AudioClip AC)
    {
        MyAudioSource.clip = AC;
        MyAudioSource.Play();
    }
    private void Start()
    {

        nametext.text = card.name;
        descriptiontext.text = card.description;
        image.sprite = card.image;

        vigortext.text = card.vigorcost.ToString();
        thevigorCostOfMyCard = card.vigorcost;

    }
    public void setenemy(Enemy enemy)
    {
        enemyy = enemy;
    }
    public void actualizarinfodeUIdeCadaCarta()
    {
        nametext.text = card.name;
        descriptiontext.text = card.description;
        image.sprite = card.image;

        vigortext.text = card.vigorcost.ToString();
    }
    public int actualizarinformacióncostedeVigor()
    {
        thevigorCostOfMyCard = card.vigorcost;
        return (thevigorCostOfMyCard);
    }
    public void ejecutarpasivadelacartadevigor()
    {
        NombredelaCartadeVigoryEjecutarPasiva = card.name;

        switch (NombredelaCartadeVigoryEjecutarPasiva)
        {
            case "Warrior Pendant":
                stadisticplayerScipt.health += 8;
                protectiontottempasive();
                PlayAudio(WarriorPendantAudio);
                Debug.Log("te has curado 5 puntos de salud");
                break;
            case "Senpukku":

                protectiontottempasive();
                enemyy.health -= 4;
                if (stadisticplayerScipt.health <= 20)
                {
                    enemyy.health -= 3;
                }
                Debug.Log("has cometido Senpukku");
                break;
            case "Sacrifice":

                enemyy.health -= 12;
                protectiontottempasive();
                stadisticplayerScipt.health -= 3;
                Debug.Log("te has inflingido daño pero mucho mas al enemigo");
                break;
            case "Spirit Growth":

                SpiritGrowthStacks += 1;
                enemyy.health -= 1;
                protectiontottempasive();
                if (SpiritGrowthStacks >= 3)
                {
                    enemyy.health -= 3;
                    Debug.Log("has inflingido 8 de daño con Spirit Growth");
                }
                break;
            case "Unbreakable":
                stadisticplayerScipt.vigor += 5;
                protectiontottempasive();
                Debug.Log("te has aumentado 5 puntos de vigor");
                break;
            case "Protection Tottem":
                stadisticplayerScipt.health += 1;
                protectiontottempasive();
                Debug.Log("te has curado 1 puntos de salud");
                ProtectionTottemStacks += 1;
                if (ProtectionTottemStacks == 5)
                {
                    Debug.Log("el tottem de proteccción ya está activado");
                }
                break;
            case "Caos":
                enemyy.health -= 9;
                protectiontottempasive();
                PlayAudio(CaosAudio);
                Debug.Log("Has inflingido 9 de daño");
                Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
                break;
            case "Dead eye":
                enemyy.health -= 7;
                stadisticplayerScipt.health += 3;
                protectiontottempasive();
                PlayAudio(DeadEyeAudio);
                Debug.Log("Has inflingido 7 de daño y te has curado 2 puntos de salud");
                Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
                break;
            case "Prominence burn":
                enemyy.health -= 3;
                stadisticplayerScipt.health += 3;
                protectiontottempasive();
                Debug.Log("Has inflingido 3 de daño y te has curado 3 puntos de salud");
                Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
                break;
            case "Absolution":
                enemyy.health -= 6;
                stadisticplayerScipt.health += 4;
                protectiontottempasive();
                Debug.Log("Has inflingido 6 de daño y te has curado 4 puntos de salud");
                Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
                break;
            case "Uncontrolled pride":
                enemyy.health -= 5;
                Debug.Log("Has inflingido 5 de daño");
                protectiontottempasive();
                Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
                break;
        }


    }
    public void protectiontottempasive()
    {
        if (ProtectionTottemStacks >= 5)
        {
            stadisticplayerScipt.health += 1;
        }

    }
}
