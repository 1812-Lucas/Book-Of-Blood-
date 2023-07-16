using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class StadisticPlayer : MonoBehaviour
{
    public int health = 50;
    public int vigor = 1;
    public int damageReduction;
    public int bloodFontPassive;
    public int healingRingPassive;
    public int antihealingToEnemies;
    public int bloodFontAditionalDamage;
    public int SpiritGrowthStacks;
    public int ProtectionTottemStacks;
    public int bloodDrainerCounter;
    public int clearMind;
    public int soulDrainer;
    public GameManager _myGM;
    public Image LuckyCoinSkillImage;
    public Image GameOfFaithSkillImage;
    public Combat combatScript;
    public inventoryObjectsActions inventoryObjectsActionsScript;

    public bool inmortalHeavyBool;
    public bool magicShieldBasicBool;
    
    public void Update()
    {
        if (health > 50)
        {
            health = 50;
        }

        if (health <= 0)
        {
            PlayerDies();
        }
      
    }

    public void PlayerDies()
    {
        SceneManager.LoadScene("LoseScene");
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void LuckyCoinSkillActive()
    {
        LuckyCoinSkillImage.gameObject.SetActive(true);


    }
    public void ButtonFunctionOfLuckyCoin()
    {
        int lc = Random.Range(0, 7);
        if (lc == 6)
        {
            combatScript.enemyy.health -= 13;
            Debug.Log(" You did <color=red>13 points of damage</color> to your oponent with the Lucky Coin!");
        }
        else
        {
            combatScript.enemyy.health -= 3;
            Debug.Log(" You did <color=red>3 points of damage</color> to your oponent.");
        }
        LuckyCoinSkillImage.gameObject.SetActive(false);
    }
    public void GameOfFaithSkillActive()
    {
        GameOfFaithSkillImage.gameObject.SetActive(true);


    }
    public void ButtonFunctionOfGameOfFaith()
    {
        int lc = Random.Range(0, 7);
        if (lc == 6)
        {
            inventoryObjectsActionsScript.VigorPotions += 1;
            Debug.Log("You <color=yellow>found</color> the <color=blue>Vigor Potion</color> from the Game of Faith!");
        }
        else
        {
            
            Debug.Log(" You <color=yellow>couldn´t find</color> the <color=blue>Vigor Potion</color> in the Game of Faith.");
        }
        GameOfFaithSkillImage.gameObject.SetActive(false);
    }
}
