using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    public Card[] _deck;
    private int availableCardSlots = 3;
    public CardDisplay Slot1;
    public CardDisplay Slot2;
    public CardDisplay Slot3;
    public bool SlotBool1 = false;
    public bool SlotBool2 = false;
    public bool SlotBool3 = false;
    //public Card[] DeckDisplayerInventory;
    public Card[] DeckOfTheDeck;
    public bool[] EquipOrUnequipTheNormalCardBool;


    private void Awake()
    {
        _deck = Resources.FindObjectsOfTypeAll<Card>();
        
    }
    
    public void BuildMyDeck(Card browser, int ThePlaceInArray)
    {
        
        if (EquipOrUnequipTheNormalCardBool[ThePlaceInArray] == false)
        {
            DeckOfTheDeck[ThePlaceInArray] = browser;
            EquipOrUnequipTheNormalCardBool[ThePlaceInArray] = true;
        }
        else if (EquipOrUnequipTheNormalCardBool[ThePlaceInArray] == true)
        {
            DeckOfTheDeck[ThePlaceInArray] = null;
            EquipOrUnequipTheNormalCardBool[ThePlaceInArray] = false;
        }
    }

    public void DrawCards()
    {
        if (DeckOfTheDeck.Length >= 1)
        {
            for (int i = 0; i <= availableCardSlots; i++)
            {
                Card randomCard = DeckOfTheDeck[Random.Range(0, DeckOfTheDeck.Length)];
                if (i == 0 && SlotBool1 == false)
                {
                    Slot1.card = randomCard;
                    Slot1.actualizarinfodeUIdeCadaCarta();
                    SlotBool1 = true;
                }
                else if (i == 1 && SlotBool2 == false)
                {
                    Slot2.card = randomCard;
                    Slot2.actualizarinfodeUIdeCadaCarta();
                    SlotBool2 = true;
                }
                else if (i == 2 && SlotBool3 == false)
                {
                    Slot3.card = randomCard;
                    Slot3.actualizarinfodeUIdeCadaCarta();
                    SlotBool3 = true;
                }

            }

        }


    }
}
