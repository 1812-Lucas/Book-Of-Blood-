using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public GameManager myGM;
    private bool isInventoryActive = false;
    private bool isMenuActive = false;
    private Vector3 initialScale;
    public Deck DeckScipt;
    public VigorDeck VigorDeckScipt;

    private void Start()
    {
        //initialScale = transform.localScale;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!isMenuActive)
                ToggleInventory();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isInventoryActive)
                ToggleInventory();
            if (isMenuActive)
                ToggleMenu();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isInventoryActive)
                ToggleMenu();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMenuActive)
                ToggleMenu();
        }
    }

    void ToggleInventory()
    {
        DeckScipt.PermissionToLeaveTheInventoryMinimumDeckCards(DeckScipt.DeckOfTheDeck);
        VigorDeckScipt.PermissionToLeaveTheInventoryMinimumVigorDeckCards(VigorDeckScipt.DeckOfTheVigorDeck);
        isInventoryActive = !isInventoryActive;
        if (isInventoryActive)
        {
            myGM.Activeinventory();
            Cursor.lockState = CursorLockMode.Confined;
        }
        else if(!isInventoryActive && DeckScipt.PermissionToLeaveTheInventoryMinimumDeckCards(DeckScipt.DeckOfTheDeck)>=5 && VigorDeckScipt.PermissionToLeaveTheInventoryMinimumVigorDeckCards(VigorDeckScipt.DeckOfTheVigorDeck)>=5)
        {
            myGM.DesactivateInventory();
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void ToggleMenu()
    {
        isMenuActive = !isMenuActive;
        if (isMenuActive)
        {
            myGM.PauseMenuactivate();
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            myGM.PauseMenudesactivate();
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    /*public void OnPointerEnter(PointerEventData eventData)
    {
        LeanTween.scale(gameObject, initialScale * 1.2f, 0.2f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LeanTween.scale(gameObject, initialScale, 0.2f);
    }*/
}