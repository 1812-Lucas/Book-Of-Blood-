using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryDisplayer : MonoBehaviour
{

    [SerializeField] UnityEvent EV_OnPlayerEnter;
    [SerializeField] UnityEvent EV_OnPlayerExit;
    public Player player;
    public Collider playerColl;
    public int MyNumber;
    //public List<> CardsinInventory;




    private void OnTriggerEnter(Collider other)
    {

        if (IsPlayer(other))
        {

        }
    }

    public void IamThisCard(int thesenumber)
    {
        thesenumber = MyNumber;
        if (thesenumber == 1)
        {

        }
    }


    bool IsPlayer(Collider col)
    {
        Player c = col.GetComponent<Player>();
        if (c == GameManager.instance.Player())
        {
            return true;
        }
        return false;
    }
}
