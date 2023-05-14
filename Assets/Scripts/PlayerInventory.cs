using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public GameManager myGM;
    private bool ActivateOrDeactivateMouseForTheinventory=true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Inventoryactivate();
            if (ActivateOrDeactivateMouseForTheinventory == true)
            {
                Cursor.lockState = CursorLockMode.Confined;
                ActivateOrDeactivateMouseForTheinventory = false;
            }
            else if (ActivateOrDeactivateMouseForTheinventory == false)
            {
                Cursor.lockState = CursorLockMode.Locked;
                ActivateOrDeactivateMouseForTheinventory = true;
            }
        }
    }
    void Inventoryactivate()
    {
        myGM.Activeinventory();

    }
}
