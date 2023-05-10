using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplayer : MonoBehaviour
{




    public GameObject[] cardsOnInventory;
    public bool[] ActivatorsOfCards;
    private bool TriggerClock = true;
    private float Clock;



    private void Update()
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



    private void OnTriggerEnter(Collider other)
    {



        if (other.gameObject.layer == 12)
        {

            if (TriggerClock == true)
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
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        
    }








}
