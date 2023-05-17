using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public GameManager myGM;
    private bool ActivateOrDeactivateMouseForTheinventory=true;
    private Vector3 initialScale;

    private void Start()
    {
        initialScale = transform.localScale;
    }
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
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            InventoryExit();
        }
    }
    void Inventoryactivate()
    {
        myGM.Activeinventory();
    }
    void InventoryExit()
    {
        myGM.DesactivateInventory();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        LeanTween.scale(gameObject, initialScale * 1.2f, 0.2f);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        LeanTween.scale(gameObject, initialScale, 0.2f);
    }
}
