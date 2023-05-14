using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VigorCardsDisplay : MonoBehaviour
{
    public VigorCards card;
    public Text nametext;
    public Text descriptiontext;
    public Image image;

    public Text vigortext;
    public VigorDeck vigorscriptdeck;
    public int myslot;
    public int thevigorCostOfMyCard;

    public string NombredelaCartadeVigoryEjecutarPasiva;
    public Player player;
    public StadisticPlayer stadisticplayerScipt;
    private int SpiritGrowthStacks;
    private int ProtectionTottemStacks;

    public Enemy enemyy;

    private void Start()
    {

        nametext.text = card.name;
        descriptiontext.text = card.description;
        image.sprite = card.image;

        vigortext.text = card.vigorcost.ToString();
        thevigorCostOfMyCard = card.vigorcost;

    }
    public void setenemy(Enemy enemy)
    {
        enemyy = enemy;
    }
    public void actualizarinfodeUIdeCadaCarta()
    {
        nametext.text = card.name;
        descriptiontext.text = card.description;
        image.sprite = card.image;

        vigortext.text = card.vigorcost.ToString();
    }
    public int actualizarinformaci�ncostedeVigor()
    {
        thevigorCostOfMyCard = card.vigorcost;
        return (thevigorCostOfMyCard);
    }
    public void ejecutarpasivadelacartadevigor()
    {
        NombredelaCartadeVigoryEjecutarPasiva = card.name;

        switch (NombredelaCartadeVigoryEjecutarPasiva)
        {
            case "Warrior Pendant":
                stadisticplayerScipt.health += 5;
                protectiontottempasive();
                Debug.Log("te has curado 5 puntos de salud");
                break;
            case "Senpukku":

                protectiontottempasive();
                if (stadisticplayerScipt.health <= 5)
                {
                    enemyy.health -= 7;
                }
                Debug.Log("has cometido Senpukku");
                break;
            case "Sacrifice":

                enemyy.health -= 12;
                protectiontottempasive();
                stadisticplayerScipt.health -= 7;
                Debug.Log("te has inflingido da�o pero mucho mas al enemigo");
                break;
            case "Spirit Growth":

                SpiritGrowthStacks += 1;
                protectiontottempasive();
                if (SpiritGrowthStacks >= 7)
                {
                    enemyy.health -= 8;
                    Debug.Log("has inflingido 8 de da�o con Spirit Growth");
                }
                break;
            case "Unbreakable":
                stadisticplayerScipt.vigor += 3;
                protectiontottempasive();
                Debug.Log("te has aumentado 3 puntos de vigor");
                break;
            case "Protection Tottem":
                stadisticplayerScipt.health += 1;
                protectiontottempasive();
                Debug.Log("te has curado 1 puntos de salud");
                ProtectionTottemStacks += 1;
                if (ProtectionTottemStacks >= 5)
                {
                    Debug.Log("el tottem de proteccci�n ya est� activado");
                }
                break;
            case "Caos":
                enemyy.health -= 8;
                Debug.Log("Has inflingido 8 de da�o");
                Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
                break;
            case "Dead eye":
                enemyy.health -= 7;
                stadisticplayerScipt.health += 2;
                Debug.Log("Has inflingido 7 de da�o y te has curado 2 puntos de salud");
                Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
                break;
            case "Prominence burn":
                enemyy.health -= 3;
                stadisticplayerScipt.health += 3;
                Debug.Log("Has inflingido 3 de da�o y te has curado 3 puntos de salud");
                Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
                break;
            case "Absolution":
                enemyy.health -= 6;
                stadisticplayerScipt.health += 4;
                Debug.Log("Has inflingido 6 de da�o y te has curado 4 puntos de salud");
                Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
                break;
            case "Uncontrolled pride":
                enemyy.health -= 5;
                Debug.Log("Has inflingido 5 de da�o");
                Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
                break;
        }


    }
    public void protectiontottempasive()
    {
        if (ProtectionTottemStacks >= 5)
        {
            stadisticplayerScipt.health += 1;
        }

    }
}
