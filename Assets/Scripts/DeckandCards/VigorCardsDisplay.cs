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
    public inventoryObjectsActions InvObjActionsScript;
    public Combat combatScript;
    public int myslot;
    public int thevigorCostOfMyCard;



    public string NombredelaCartadeVigoryEjecutarPasiva;
    public Player player;
    public StadisticPlayer stadisticplayerScipt;


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
                combatScript.damageparticleSlot16.Play();
                combatScript.damageparticleSlot16Combate2.Play();
                combatScript.damageparticleSlot16_Combate3.Play();
                stadisticplayerScipt.health += 8;
                protectiontottempasive();
                PlayAudio(WarriorPendantAudio);
                Debug.Log("Te has curado 5 puntos de salud");
                break;
            case "Senpukku":
                combatScript.damageparticleSlot17.Play();
                combatScript.damageparticleSlot17Combate2.Play();
                combatScript.damageparticleSlot17_Combate3.Play();
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
                combatScript.damageparticleSlot18.Play();
                combatScript.damageparticleSlot18Combate2.Play();
                combatScript.damageparticleSlot18_Combate3.Play();
                enemyy.health -= 12;
                PlayAudio(magicSuntemple);
                protectiontottempasive();
                stadisticplayerScipt.health -= 3;
                Debug.Log("Te has inflingido daño pero mucho mas al enemigo");
                break;
            case "Spirit Growth":
                combatScript.damageparticleSlot19.Play();
                combatScript.damageparticleSlot19Combate2.Play();
                combatScript.damageparticleSlot19_Combate3.Play();
                stadisticplayerScipt.SpiritGrowthStacks += 1;
                PlayAudio(magicCircle);
                enemyy.health -= 1;
                protectiontottempasive();
                if (stadisticplayerScipt.SpiritGrowthStacks >= 3)
                {
                    enemyy.health -= 4;
                    Debug.Log("Has inflingido 5 de daño con Spirit Growth");
                }
                break;
            case "Unbreakable":
                combatScript.damageparticleSlot20.Play();
                combatScript.damageparticleSlot20Combate2.Play();
                combatScript.damageparticleSlot20_Combate3.Play();
                PlayAudio(windowFixing);
                stadisticplayerScipt.vigor += 5;
                protectiontottempasive();
                Debug.Log("Te has aumentado 5 puntos de vigor");
                break;
            case "Protection Tottem":
                combatScript.damageparticleSlot21.Play();
                combatScript.damageparticleSlot21Combate2.Play();
                combatScript.damageparticleSlot21_Combate3.Play();
                stadisticplayerScipt.health += 1;
                protectiontottempasive();
                Debug.Log("Te has curado 1 puntos de salud");
                stadisticplayerScipt.ProtectionTottemStacks += 1;
                if (stadisticplayerScipt.ProtectionTottemStacks == 5)
                {
                    PlayAudio(remorseFemale);
                    Debug.Log("El tottem de proteccción ya está activado");
                }
                else
                {
                    PlayAudio(claps);

                }
                break;
            case "Caos":
                combatScript.damageparticleSlot22.Play();
                combatScript.damageparticleSlot22Combate2.Play();
                combatScript.damageparticleSlot22_Combate3.Play();
                enemyy.health -= 9;
                protectiontottempasive();
                PlayAudio(CaosAudio);
                Debug.Log("Has inflingido 9 de daño");
                Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
                break;
            case "Dead eye":
                combatScript.damageparticleSlot23.Play();
                combatScript.damageparticleSlot23Combate2.Play();
                combatScript.damageparticleSlot23_Combate3.Play();
                enemyy.health -= 7;
                stadisticplayerScipt.health += 3;
                protectiontottempasive();
                PlayAudio(DeadEyeAudio);
                Debug.Log("Has inflingido 7 de daño y te has curado 2 puntos de salud");
                Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
                break;
            case "Prominence burn":
                combatScript.damageparticleSlot24.Play();
                combatScript.damageparticleSlot24Combate2.Play();
                combatScript.damageparticleSlot24_Combate3.Play();
                enemyy.health -= 3;
                PlayAudio(healUp);
                stadisticplayerScipt.health += 3;
                protectiontottempasive();
                Debug.Log("Has inflingido 3 de daño y te has curado 3 puntos de salud");
                Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
                break;
            case "Absolution":
                combatScript.damageparticleSlot25.Play();
                combatScript.damageparticleSlot25Combate2.Play();
                combatScript.damageparticleSlot25_Combate3.Play();
                enemyy.health -= 6;
                PlayAudio(iceMagic);
                stadisticplayerScipt.health += 4;
                protectiontottempasive();
                Debug.Log("Has inflingido 6 de daño y te has curado 4 puntos de salud");
                Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
                break;
            case "Uncontrolled pride":
                combatScript.damageparticleSlot26.Play();
                combatScript.damageparticleSlot26Combate2.Play();
                combatScript.damageparticleSlot26_Combate3.Play();
                enemyy.health -= 5;
                PlayAudio(CaosAudio);
                Debug.Log("Has inflingido 5 de daño");
                protectiontottempasive();
                Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
                break;

            case "absortion":
                combatScript.damageparticleSlot27.Play();
                combatScript.damageparticleSlot27Combate2.Play();
                combatScript.damageparticleSlot27_Combate3.Play();
                if (stadisticplayerScipt.vigor <= 3)
                {
                    stadisticplayerScipt.vigor = 7;
                }
                break;
            case "Balance of Death":
                combatScript.damageparticleSlot28.Play();
                combatScript.damageparticleSlot28Combate2.Play();
                combatScript.damageparticleSlot28_Combate3.Play();
                int i = enemyy.health - stadisticplayerScipt.health;
                if (i < 0)
                {
                    i*= -1;
                    enemyy.health -= i;
                }
                else
                {
                    enemyy.health -= i;
                }
                break;
            case "Balance of Life":
                combatScript.damageparticleSlot29.Play();
                combatScript.damageparticleSlot29Combate2.Play();
                combatScript.damageparticleSlot29_Combate3.Play();
                int u = enemyy.health - stadisticplayerScipt.health;
                if (u < 0)
                {
                    u *= -1;
                    stadisticplayerScipt.health -= u;
                }
                else
                {
                    stadisticplayerScipt.health -= u;
                }

                break;

            case "Blood Drainer":
                combatScript.damageparticleSlot30.Play();
                combatScript.damageparticleSlot30Combate2.Play();
                combatScript.damageparticleSlot30_Combate3.Play();
                enemyy.health -= 4;
                stadisticplayerScipt.bloodDrainerCounter += 1;

                if (stadisticplayerScipt.bloodDrainerCounter == 3)
                {
                    InvObjActionsScript.HealthPotions += 1;
                    stadisticplayerScipt.bloodDrainerCounter = 0;
                }
                break;
            case "Death Reaper":
                combatScript.damageparticleSlot31.Play();
                combatScript.damageparticleSlot31Combate2.Play();
                combatScript.damageparticleSlot31_Combate3.Play();
                stadisticplayerScipt.vigor += 7;
                if (stadisticplayerScipt.health <= 15)
                {
                    enemyy.health = 0;
                }
                break;
            case "Devil Eyes":
                combatScript.damageparticleSlot32.Play();
                combatScript.damageparticleSlot32Combate2.Play();
                combatScript.damageparticleSlot32_Combate3.Play();
                stadisticplayerScipt.health += combatScript.devilEyesPassive;
                break;
            case "Evil Pendant":
                combatScript.damageparticleSlot33.Play();
                combatScript.damageparticleSlot33Combate2.Play();
                combatScript.damageparticleSlot33_Combate3.Play();
                stadisticplayerScipt.health += 7;
                stadisticplayerScipt.vigor += 6;
                break;
            case "Souls Strike":
                combatScript.damageparticleSlot34.Play();
                combatScript.damageparticleSlot34Combate2.Play();
                combatScript.damageparticleSlot34_Combate3.Play();
                enemyy.health -= 5;
                if (stadisticplayerScipt.health < stadisticplayerScipt.vigor)
                {
                    enemyy.health = 0;
                }
                break;
            case "Thanatos":
                combatScript.damageparticleSlot35.Play();
                combatScript.damageparticleSlot35Combate2.Play();
                combatScript.damageparticleSlot35_Combate3.Play();
                enemyy.health -= 5;
                if (stadisticplayerScipt.health <= 15)
                {
                    stadisticplayerScipt.vigor += 15;
                }
                break;
                




        }


    }
    public void protectiontottempasive()
    {
        if (stadisticplayerScipt.ProtectionTottemStacks >= 5)
        {
            stadisticplayerScipt.health += 1;
        }

    }
}
