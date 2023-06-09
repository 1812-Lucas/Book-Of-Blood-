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

    public GameObject DoorHolder;

    public ParticleSystem healthPotionParticles;

    public ParticleSystem healthPotionMiniParticles;

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
            Debug.Log("You have healed 30 health with a health buff");

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
            Debug.Log("You have healed 30 health with a health buff");
        }
    }
    public void UseVigorPotion()
    {
        if (VigorPotions > 0 && combatpositionscript.CombatON == true)
        {
            StadisticPlayerScript.vigor += 10;
            VigorPotions -= 1;
            playerAnimator.Play("UsarPocion");
            PlayAudioInventory(UsePotionAudio);
            //HealthPotionParticles.Play();
            Debug.Log("You have recover 10 points of vigor with a potion");
        }
    }
    public void UseAguilePotion()
    {
        if (AguilePotions > 0 && combatpositionscript.CombatON == true && combatScript.playercontador == 1)
        {

            AguilePotions -= 1;
            playerAnimator.Play("UsarPocion");
            PlayAudioInventory(UsePotionAudio);
            BlockerAguilePotionImage.gameObject.SetActive(true);
            combatScript.playercontador = 0;
            //HealthPotionParticles.Play();
            Debug.Log("You can use another classic card");
        }
        else
        {
            Debug.Log(" Use a classic card in this turn to be able to drink this potion");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 15)
        {
            ActivatorsOfCards[CardsOnCountdown] = true;
            cardsOnInventory[CardsOnCountdown].gameObject.SetActive(ActivatorsOfCards[CardsOnCountdown]);
            PlayAudioInventory(newCard);
            Debug.Log("You have obtained a new card [i] to see the inventory");
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


            Debug.Log("You obtained a healing potion, you can only use it in combat by pressing the H key or its corresponding button");
        }

        if (other.gameObject.layer == 6)
        {
            WhispersCount += 1;
            Destroy(other.gameObject);

            PlayAudioInventory(DeadlyEvilPageTutorial);
            if (WhispersCount == 1)
            {
                Debug.Log("Listen carefully Oswald, the fight is near. you have two decks. one of them will feed me your vigor to give you much of my power and they can turn the fight in your favor if you use it with ingenuity. The more you fight, your stamina will increase, and therefore, the more I can consume from you, so try not to die too quickly.");
            }
            else if (WhispersCount == 2)
            {
                Debug.Log("By pressing [i] you will enter the inventory, press on a card to equip it. you must equip both vigor cards and normal cards or you will not be able to defeat your enemies.");
            }
            else if (WhispersCount == 3)
            {
                Debug.Log("The deck that does not consume your stamina are just a supplement, but they can be very timely. I gave them to you out of pity...");
            }
            else if (WhispersCount == 4)
            {
                Debug.Log("Is that how you use my cards? you are disappointing");
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
