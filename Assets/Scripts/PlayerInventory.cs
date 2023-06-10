using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public GameManager myGM;
    private bool isInventoryActive = false;
    private bool isMenuActive = false;
    private bool isControlsActive = false;
    private Vector3 initialScale;
    public Deck DeckScript;
    public VigorDeck VigorDeckScript;
    public MyCamera camerascript;

    public AudioClip MyEffectAudio;
    public AudioSource MyAudioSource;
    public TextMeshProUGUI NotAppropiateDeckWarningText;

    public void PlayAudio(AudioClip AC)
    {
        MyAudioSource.clip = AC;
        MyAudioSource.Play();
    }
    private void Update()
    {
       /* if (isMenuActive)
        {
            PlayAudio(MyEffectAudio);
        }*/

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

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!isInventoryActive && !isMenuActive)
            {
                ToggleControls();
            }
        }
    }
    public void ToggleInventory()
    {
        int deckCardsCount = DeckScript.PermissionToLeaveTheInventoryMinimumDeckCards(DeckScript.DeckOfTheDeck);
        int vigorCardsCount = VigorDeckScript.PermissionToLeaveTheInventoryMinimumVigorDeckCards(VigorDeckScript.DeckOfTheVigorDeck);
        if(deckCardsCount < 5 || deckCardsCount > 8 || vigorCardsCount < 5 || vigorCardsCount > 8)
        {
            NotAppropiateDeckWarningText.gameObject.SetActive(true);
        }
        else
        {
            NotAppropiateDeckWarningText.gameObject.SetActive(false);
        }
        if (!isInventoryActive)
        {
            isInventoryActive = true;
            myGM.Activeinventory();
            Cursor.lockState = CursorLockMode.Confined;
            camerascript.enabled = false;
        }
        else if (isInventoryActive && deckCardsCount >= 5 && deckCardsCount<=8 &&vigorCardsCount >= 5&&vigorCardsCount<=8)
        {
            isInventoryActive = false;
            myGM.DesactivateInventory();
            Cursor.lockState = CursorLockMode.Locked;
            camerascript.enabled = true;
        }
    }
    public void ToggleMenu()
    {
        isMenuActive = !isMenuActive;
        if (isMenuActive)
        {
            myGM.Menuactivate();
            Cursor.lockState = CursorLockMode.Confined;
            camerascript.enabled = false;
        }
        else
        {
            myGM.Menudesactivate();
            Cursor.lockState = CursorLockMode.Locked;
            camerascript.enabled = true;
        }
    }
    public void ToggleControls()
    {
        isControlsActive = !isControlsActive;
        if (isControlsActive)
        {
            myGM.Showcontrols();
        }
        else
        {
            myGM.Hidecontrols();
        }
    }
    public void MusicON()
    {
        MyAudioSource.clip = MyEffectAudio;
        MyAudioSource.Play();
    }
    public void MusicOFF()
    {
        MyAudioSource.Stop();
    }
}