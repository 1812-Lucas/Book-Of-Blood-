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
    public Deck DeckScript;
    public VigorDeck VigorDeckScript;

    public AudioClip MyEffectAudio;
    public AudioSource MyAudioSource;

    private void Start()
    {
        initialScale = transform.localScale;
    }

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
    }

    void ToggleInventory()
    {
        int deckCardsCount = DeckScript.PermissionToLeaveTheInventoryMinimumDeckCards(DeckScript.DeckOfTheDeck);
        int vigorCardsCount = VigorDeckScript.PermissionToLeaveTheInventoryMinimumVigorDeckCards(VigorDeckScript.DeckOfTheVigorDeck);

        if (!isInventoryActive)
        {
            isInventoryActive = true;
            myGM.Activeinventory();
            Cursor.lockState = CursorLockMode.Confined;
        }
        else if (isInventoryActive && deckCardsCount >= 5 && vigorCardsCount >= 5)
        {
            isInventoryActive = false;
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
            MyAudioSource.clip = MyEffectAudio;
            MyAudioSource.Play();
        }
        else
        {
            myGM.PauseMenudesactivate();
            Cursor.lockState = CursorLockMode.Locked;
            MyAudioSource.Stop();
        }
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