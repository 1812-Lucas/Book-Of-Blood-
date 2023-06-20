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
    public AudioClip arrowhit;
    public AudioClip magicSuntemple;
    public AudioClip magicCircle;
    public AudioClip windowFixing;
    public AudioClip claps;
    public AudioClip healUp;
    public AudioClip iceMagic;
    public AudioClip remorseFemale;

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
    public int actualizarinformaci�ncostedeVigor()
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
                Debug.Log("Te has curado 5 puntos de salud");
                break;
            case "Senpukku":

                protectiontottempasive();
                enemyy.health -= 4;
                PlayAudio(arrowhit);
                if (stadisticplayerScipt.health <= 20)
                {
                    enemyy.health -= 3;
                }
                Debug.Log("Has cometido Senpukku");
                break;
            case "Sacrifice":

                enemyy.health -= 12;
                PlayAudio(magicSuntemple);
                protectiontottempasive();
                stadisticplayerScipt.health -= 3;
                Debug.Log("Te has inflingido da�o pero mucho mas al enemigo");
                break;
            case "Spirit Growth":

                SpiritGrowthStacks += 1;
                PlayAudio(magicCircle);
                enemyy.health -= 1;
                protectiontottempasive();
                if (SpiritGrowthStacks >= 3)
                {
                    enemyy.health -= 3;
                    Debug.Log("Has inflingido 8 de da�o con Spirit Growth");
                }
                break;
            case "Unbreakable":

                PlayAudio(windowFixing);
                stadisticplayerScipt.vigor += 5;
                protectiontottempasive();
                Debug.Log("Te has aumentado 5 puntos de vigor");
                break;
            case "Protection Tottem":
                stadisticplayerScipt.health += 1;
                protectiontottempasive();
                Debug.Log("Te has curado 1 puntos de salud");
                ProtectionTottemStacks += 1;
                if (ProtectionTottemStacks == 5)
                {
                    PlayAudio(remorseFemale);
                    Debug.Log("El tottem de proteccci�n ya est� activado");
                }
                else
                {
                    PlayAudio(claps);

                }
                break;
            case "Caos":
                enemyy.health -= 9;
                protectiontottempasive();
                PlayAudio(CaosAudio);
                Debug.Log("Has inflingido 9 de da�o");
                Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
                break;
            case "Dead eye":
                enemyy.health -= 7;
                stadisticplayerScipt.health += 3;
                protectiontottempasive();
                PlayAudio(DeadEyeAudio);
                Debug.Log("Has inflingido 7 de da�o y te has curado 2 puntos de salud");
                Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
                break;
            case "Prominence burn":
                enemyy.health -= 3;
                PlayAudio(healUp);
                stadisticplayerScipt.health += 3;
                protectiontottempasive();
                Debug.Log("Has inflingido 3 de da�o y te has curado 3 puntos de salud");
                Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
                break;
            case "Absolution":
                enemyy.health -= 6;
                PlayAudio(iceMagic);
                stadisticplayerScipt.health += 4;
                protectiontottempasive();
                Debug.Log("Has inflingido 6 de da�o y te has curado 4 puntos de salud");
                Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
                break;
            case "Uncontrolled pride":
                enemyy.health -= 5;
                PlayAudio(CaosAudio);
                Debug.Log("Has inflingido 5 de da�o");
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
