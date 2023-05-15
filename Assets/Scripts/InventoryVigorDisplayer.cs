using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryVigorDisplayer : MonoBehaviour
{
    public VigorCards card;
    public Text nametext;
    public Text descriptiontext;
    public Image image;
    public int MyPlaceOnTheVigorArray;
    public Text vigortext;
    public VigorDeck VigorDeckScript;


    private void Start()
    {

        nametext.text = card.name;
        descriptiontext.text = card.description;
        image.sprite = card.image;
        vigortext.text = card.vigorcost.ToString();
        

    }
    public void AddCardToMyVigorDeck()
    {
        VigorDeckScript.BuildMyVigorDeck(card,MyPlaceOnTheVigorArray);

    }

}
