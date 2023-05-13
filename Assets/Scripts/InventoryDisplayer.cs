using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplayer : MonoBehaviour
{




    public GameObject[] cardsOnInventory;
    public bool[] ActivatorsOfCards;
    public int CardsOnCountdown;
    //public bool TriggerClock = true;
    //public float Clock;



   /* private void Update()
    {
        if (TriggerClock == false)
        {
            Clock = Time.deltaTime;
            if (Clock >= 5)
            {
                TriggerClock = true;
            }
        }
    }
   */


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 15)
        {
            ActivatorsOfCards[CardsOnCountdown]= true;
            cardsOnInventory[CardsOnCountdown].gameObject.SetActive(ActivatorsOfCards[CardsOnCountdown]);
            Debug.Log("has obtenido una nueva carta [i] para ver el inventario");
            Destroy(other.gameObject);
            CardsOnCountdown += 1;

            /*if (TriggerClock == true)
            {
                for (int i = 0; i <= cardsOnInventory.Length; i++)
                {
                    ActivatorsOfCards[i] = true;
                    cardsOnInventory[i].gameObject.SetActive(ActivatorsOfCards[i]);
                    Debug.Log("has obtenido una nueva carta [i] para ver el inventario");
                    Destroy(other.gameObject);
                    TriggerClock = false;
                }

            }
            */

        }

    }
    /*private void OnCollisionEnter(Collision other)
    {

        
    }*/








}
