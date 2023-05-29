using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    Player player;
    public Image combatUI;
    public Image Inventory;
    public bool cardsEquiped = false;
    public bool inventoryactive = false;
    //Variables del mazo
    public List<Card> deck = new List<Card>();
    public Transform[] cardslots;
    public bool[] availableCardSlots;
    public Text deckSizeText;
    private bool ActivateOrDeactivateMouseForThePauseMenu = true;
    
    
    public bool gameispaused;
    public Image PauseMenu;
    public MyCamera camerascript;
    public Rigidbody playerRB;
    

    //PROFE si ve esto  es solo prueba del script de mazo, nada más
    public void DrawCard()
    {
        if (deck.Count >= 1)
        {
            Card randomCard = deck[Random.Range(0, deck.Count)];

            for (int i = 0; i < availableCardSlots.Length; i++)
            {
                if (availableCardSlots[i] == true)
                {
                    // randomCard.gameObject.setActive(true);
                    //randomCard.transform.position = cardslots[i].position;
                    availableCardSlots[i] = false;
                    deck.Remove(randomCard);
                    return;
                }
            }
        }

       //  void Update()
        //{
            //deckSizeText.text = deck.Count.ToString();
        //}
    }

    public void PauseGame()
    {
        gameispaused = !gameispaused;
        PauseMenu.gameObject.SetActive(gameispaused);

        if (gameispaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
    public void PauseMenuactivate()
    {
        PauseGame();
        if (ActivateOrDeactivateMouseForThePauseMenu == true)
        {
            
            Cursor.lockState = CursorLockMode.Confined;            
            ActivateOrDeactivateMouseForThePauseMenu = false;
        }
        else if (ActivateOrDeactivateMouseForThePauseMenu == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            
            ActivateOrDeactivateMouseForThePauseMenu = true;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        player = FindObjectOfType<Player>();
    }
    public Player Player()
    {
        
        {
            return player;
        }
    }
    public static Transform PlayerTransform
    {
        get
        {
            return instance.player.transform;

        }

    }

    public void activeUI()
    {
        cardsEquiped = !cardsEquiped;
        combatUI.gameObject.SetActive(cardsEquiped);

    }
    public void Activeinventory()
    {
        inventoryactive = !inventoryactive;
        Inventory.gameObject.SetActive(inventoryactive);
    }
    public void DesactivateInventory()
    {
        Inventory.gameObject.SetActive(false);
    }
}
