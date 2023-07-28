using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class inventoryObjectsActions : MonoBehaviour
{
    private int WhispersCount;
    public int KeyForTheBlackDoor;
    public CombatPosition combatpositionscript;

    public Camera mainCamera;
    public MenuManager menumanagerscript;
    [SerializeField] LayerMask doormask;

    public GameObject[] cardsOnInventory;
    public bool[] ActivatorsOfCards;
    public int CardsOnCountdown;
    // private bool inventoryTutorialTrigger = false;

    AudioSource MyAudioSource;
    public AudioClip DeadlyEvilPageTutorial;
    public AudioClip doorOpen;
    public AudioClip newCard;
    public AudioClip UsePotionAudio;

    private int contador;

    public int VigorPotions;
    public int AguilePotions;
    public Image BlockerAguilePotionImage;//FALTA REFE
    public Combat combatScript;//FALTA REFE

    public int HealthPotions;
    public StadisticPlayer StadisticPlayerScript;

    public ParticleSystem HealthPotionParticles;

    public ParticleSystem vigorParticlesPlayer;

    public ParticleSystem aguileParticlesPlayer;

    public GameObject DoorHolder;

    public ParticleSystem healthPotionParticles;

    public ParticleSystem healthPotionMiniParticles;

    public ParticleSystem vigorParticlesPotion;

    public ParticleSystem aguileMiniParticlesPotion;

    public ParticleSystem aguileParticlesPotion;

    public Light aguileLightPotion;

    public Light vigorLightPotion;

    public Light healthPotionLight;

    public Light lightCardbox;

    public Light demonWhispersLight;



    public Animator animationDoor;

    public Animator playerAnimator;
    private void Awake()
    {
        MyAudioSource = GetComponent<AudioSource>();

    }

    public void PlayAudioInventory(AudioClip AC)
    {
        MyAudioSource.clip = AC;
        MyAudioSource.Play();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && HealthPotions > 0 && combatpositionscript.CombatON == true)
        {
            playerAnimator.Play("UsarPocion");
            StadisticPlayerScript.health += 30;
            HealthPotions -= 1;
            HealthPotionParticles.Play();
            Debug.Log("You had <color=green>healed 30 points</color> with a health buff.");

        }
    }
    public void UsePotion()
    {
        if (HealthPotions > 0 && combatpositionscript.CombatON == true)
        {
            StadisticPlayerScript.health += 30;
            HealthPotions -= 1;
            playerAnimator.Play("UsarPocion");
            PlayAudioInventory(UsePotionAudio);
            HealthPotionParticles.Play();
            Debug.Log("You had <color=green>healed 30 points</color> with a health buff.");
        }
    }
    public void UseVigorPotion()
    {
        if (VigorPotions > 0 && combatpositionscript.CombatON == true)
        {
            vigorParticlesPlayer.Play();
            StadisticPlayerScript.vigor += 10;
            VigorPotions -= 1;
            playerAnimator.Play("UsarPocion");
            PlayAudioInventory(UsePotionAudio);
            //HealthPotionParticles.Play();
            Debug.Log("You had recovered <color=blue>10 points of vigor</color> with a potion.");
        }
    }
    public void UseAguilePotion()
    {
        if (AguilePotions > 0 && combatpositionscript.CombatON == true && combatScript.playercontador == 1)
        {
            aguileParticlesPlayer.Play();
            AguilePotions -= 1;
            playerAnimator.Play("UsarPocion");
            PlayAudioInventory(UsePotionAudio);
            BlockerAguilePotionImage.gameObject.SetActive(true);
            combatScript.playercontador = 0;
            //HealthPotionParticles.Play();
            Debug.Log("You can use another <color=red>classic</color> card.");
        }
        else
        {
            Debug.Log("Use a <color=red>classic card</color> in this turn to be able to drink this <color=orange>potion</color>.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 15)
        {
            ActivatorsOfCards[CardsOnCountdown] = true;
            cardsOnInventory[CardsOnCountdown].gameObject.SetActive(ActivatorsOfCards[CardsOnCountdown]);
            PlayAudioInventory(newCard);
            Debug.Log("You had obtained a new card <color=yellow>[i]</color> to see the <color=yellow>inventory</color>.");
            /*if (inventoryTutorialTrigger == false)
            {
                inventoryTutorialTrigger = true;
            //}*/
            Destroy(other.gameObject);

            CardsOnCountdown += 1;
        }
        if (other.gameObject.layer == 16)
        {
            HealthPotions += 1;
            Destroy(other.gameObject);
            healthPotionLight.enabled = false;
            healthPotionParticles.Stop();
            healthPotionMiniParticles.Stop();


            Debug.Log("You had obtained a <color=green>healing potion</color>, you can only use it in combat by pressing the <color=yellow>H</color> key or its corresponding button.");
        }
        if (other.gameObject.layer == 20)
        {
            VigorPotions += 1;
            Destroy(other.gameObject);
            vigorLightPotion.enabled = false;
            vigorParticlesPotion.Stop();
            


            Debug.Log("You had obtained a <color=blue>vigor potion</color>, you can only use it in combat.");
        }
        if (other.gameObject.layer == 21)
        {
            if (AguilePotions <= 1)
            {
                AguilePotions += 1;

            }
            Destroy(other.gameObject);
            aguileLightPotion.enabled = false;
            aguileParticlesPotion.Stop();
            aguileMiniParticlesPotion.Stop();


            Debug.Log("You had obtained an <color=orange>aguile potion</color>, you can only use it in combat. Max <color=red>2 potions</color>.");
        }

        if (other.gameObject.layer == 6)
        {
            WhispersCount += 1;
            Destroy(other.gameObject);

            PlayAudioInventory(DeadlyEvilPageTutorial);
            if (WhispersCount == 1)
            {
                Debug.Log("Listen carefully Oswald, the fight is near. You have <color=yellow>two decks</color>. One of them will feed me your <color=blue>vigor</color> to give you much of my power and they can turn the fight in your favor if you use it with ingenuity. The more you fight, your <color=blue>stamina</color> will increase, and therefore, the more I can consume from you, so try not to die too quickly.");
            }
            else if (WhispersCount == 2)
            {
                Debug.Log("By pressing <color=yellow>[i]</color> you will enter the inventory, press on a card to equip it. you must equip both <color=blue>vigor</color> cards and <color=red>normal</color> cards or you will not be able to defeat your <color=red>enemies</color>.");
            }
            else if (WhispersCount == 3)
            {
                Debug.Log("The deck that does not consume your <color=blue>stamina</color> are just a supplement, but they can be very timely. I gave them to you out of pity...");
            }
            else if (WhispersCount == 4)
            {
                Debug.Log("Is that how you use <color=red>MY</color> cards!? you are disappointing me.");
            }
        }
        if (other.gameObject.layer == 8)
        {
            //llave
            KeyForTheBlackDoor = 1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.layer == 7)
        {

            //puerta
            if (KeyForTheBlackDoor == 1)
            {
                animationDoor.SetBool("PlayAnimation", true);

                animationDoor.CrossFade("AnimationDoor", 0f);
                // Destroy(other.gameObject);
                Destroy(DoorHolder);
            }
            if (contador == 0)
            {
                PlayAudioInventory(doorOpen);
                contador += 1;
            }

        }
        if (other.gameObject.layer == 12)
        {
            menumanagerscript.Restartscene();
        }


    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 15)
        {
            lightCardbox.enabled = false;
        }
        if (other.gameObject.layer == 6)
        {
            demonWhispersLight.enabled = false;
        }
    }
}
