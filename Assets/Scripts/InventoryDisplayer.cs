using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryDisplayer : MonoBehaviour
{
    public Card card;
    public Text nametext;
    public Text descriptiontext;
    public Image image;
    public Text attacktext;
    public int MyPlaceOnTheArray;
    public Deck DeckScript;



    private void Start()
    {

        nametext.text = card.name;
        descriptiontext.text = card.description;
        image.sprite = card.image;

        attacktext.text = card.attack.ToString();
    }

    public void AddCardToMyDeck()
    {
        DeckScript.BuildMyDeck(card, MyPlaceOnTheArray);

    }









}
