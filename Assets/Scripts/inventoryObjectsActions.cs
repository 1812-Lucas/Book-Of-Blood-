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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 15)
        {
            ActivatorsOfCards[CardsOnCountdown] = true;
            cardsOnInventory[CardsOnCountdown].gameObject.SetActive(ActivatorsOfCards[CardsOnCountdown]);
            Debug.Log("has obtenido una nueva carta [i] para ver el inventario");
            Destroy(other.gameObject);
            CardsOnCountdown += 1;
        }

            if (other.gameObject.layer == 6)
        {
            WhispersCount += 1;
            Destroy(other.gameObject);
            if (WhispersCount == 1)
            {
                Debug.Log("vas por buen camino Oswald, puedo sentirlo. ahora recupera mi libro y dale buen uso a mis cartas, o conocer�s las consecuencias");
            }
            else if (WhispersCount == 2)
            {
                Debug.Log("escucha atentamente Oswald, el combate est� cerca. tienes dos mazos. uno de ellos me alimentar� de tu vigor para darte" +
                    " gran parte de mi poder y pueden poner el combate a tu favor si lo usas con ingenio. Mientras m�s luches tu vigor aumentar�" +
                    ", y por ende, m�s podr� consumir de ti, as� que trata de no morirte tan r�pido");
            }
            else if (WhispersCount == 3)
            {
                Debug.Log("el mazo que no consume tu vigor son s�lo un suplemento, pero pueden ser muy oportunas. Te las di por pena ");
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
            if (KeyForTheBlackDoor==1)
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
