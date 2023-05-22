using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inventoryObjectsActions : MonoBehaviour
{
    private int WhispersCount;
    public int KeyForTheBlackDoor;

    public Camera mainCamera;
    public MenuManager menumanagerscript;
    [SerializeField] LayerMask doormask;

    public GameObject[] cardsOnInventory;
    public bool[] ActivatorsOfCards;
    public int CardsOnCountdown;
    private bool inventoryTutorialTrigger = false;

    AudioSource MyAudioSource;
    public AudioClip OpenCardBox;


    private void Awake()
    {
        MyAudioSource = GetComponent<AudioSource>();
    }

    public void PlayAudioInventory(AudioClip AC)
    {
        MyAudioSource.clip = AC;
        MyAudioSource.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 15)
        {
            ActivatorsOfCards[CardsOnCountdown] = true;
            cardsOnInventory[CardsOnCountdown].gameObject.SetActive(ActivatorsOfCards[CardsOnCountdown]);
            if (inventoryTutorialTrigger == false)
            {
                Debug.Log("Has obtenido una nueva carta [i] para ver el inventario");
                inventoryTutorialTrigger = true;
            }
            Destroy(other.gameObject);
            CardsOnCountdown += 1;
        }

        if (other.gameObject.layer == 6)
        {
            WhispersCount += 1;
            Destroy(other.gameObject);
            PlayAudioInventory(OpenCardBox);
            if (WhispersCount == 1)
            {
                Debug.Log("Vas por buen camino Oswald, puedo sentirlo. ahora recupera mi libro y dale buen uso a mis cartas, o conocerás las consecuencias");
            }
            else if (WhispersCount == 2)
            {
                Debug.Log("Escucha atentamente Oswald, el combate está cerca. tienes dos mazos. uno de ellos me alimentará de tu vigor para darte" +
                    " gran parte de mi poder y pueden poner el combate a tu favor si lo usas con ingenio. Mientras más luches tu vigor aumentará" +
                    ", y por ende, más podré consumir de ti, así que trata de no morirte tan rápido");
            }
            else if (WhispersCount == 3)
            {
                Debug.Log("El mazo que no consume tu vigor son sólo un suplemento, pero pueden ser muy oportunas. Te las di por pena...");
            }
            else if (WhispersCount == 4)
            {
                Debug.Log("¿así usas mis cartas? eres decepcionante");
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
                Destroy(other.gameObject);
            }

        }
        if (other.gameObject.layer == 12)
        {
            menumanagerscript.Restartscene();
        }
    }    /*private void Update()
    {
        if(combatMode == true)
        {
            fightStarts();
        }
        if (aldeano.health <= 0)
        {
            fightIsOver();
        }
        if (isfrozen == true)
        {
           
        }
        player2.frozee();
    }

    public void isFreeze()
    {
        isfrozen = true;
    }
    public void fightStarts()
    {
        transform.LookAt(enemy.transform);
        mainCameraa.transform.LookAt(enemy.transform);
        isFreeze();
        //transicion de cámara

    }
    public void fightIsOver()
    {
        isfrozen = false;
        //transicion de cámara
    }*/
}
