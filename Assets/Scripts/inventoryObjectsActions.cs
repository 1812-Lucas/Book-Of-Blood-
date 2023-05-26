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

    public int HealthPotions;
    public StadisticPlayer StadisticPlayerScript;


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
        if (Input.GetKeyDown(KeyCode.H) && HealthPotions > 0)
        {
            // Llamar a tu funci�n aqu�
            //TuFuncion();
            StadisticPlayerScript.health += 3;
            Debug.Log("te has curado 3 puntos de salud con una mejora de salud");

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 15)
        {
            ActivatorsOfCards[CardsOnCountdown] = true;
            cardsOnInventory[CardsOnCountdown].gameObject.SetActive(ActivatorsOfCards[CardsOnCountdown]);
            Debug.Log("Has obtenido una nueva carta [i] para ver el inventario");
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
        }

        if (other.gameObject.layer == 6)
        {
            WhispersCount += 1;
            Destroy(other.gameObject);
            PlayAudioInventory(OpenCardBox);
            if (WhispersCount == 1)
            {
                Debug.Log("Al presionar [i] entrar�s en el inventario, presiona sobre una carta para equipartela. debes equiparte tanto" +
                    " cartas de vigor como cartas normales o no podr�s derrotar a tus enemigos.");
            }
            else if (WhispersCount == 2)
            {
                Debug.Log("Escucha atentamente Oswald, el combate est� cerca. tienes dos mazos. uno de ellos me alimentar� de tu vigor para darte" +
                    " gran parte de mi poder y pueden poner el combate a tu favor si lo usas con ingenio. Mientras m�s luches tu vigor aumentar�" +
                    ", y por ende, m�s podr� consumir de ti, as� que trata de no morirte tan r�pido");
            }
            else if (WhispersCount == 3)
            {
                Debug.Log("El mazo que no consume tu vigor son s�lo un suplemento, pero pueden ser muy oportunas. Te las di por pena...");
            }
            else if (WhispersCount == 4)
            {
                Debug.Log("�as� usas mis cartas? eres decepcionante");
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
        //transicion de c�mara

    }
    public void fightIsOver()
    {
        isfrozen = false;
        //transicion de c�mara
    }*/
}
