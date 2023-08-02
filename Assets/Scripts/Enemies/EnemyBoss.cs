using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : Enemy
{
    public Animator myAnim;
    public override void Awake()
    {
        myAnim = GetComponent<Animator>();
        base.Awake();
    }
    public override void Start()
    {
        base.Start();
    }
    public override void Enemyturn()
    {
        if (health <= 50 && health > 30)
        {
            int Numero = Random.Range(1, 101);
            if (Numero >= 30)
            {
                BasicDamage();
            }
            else if (Numero < 30)
            {
                HeavyDamage();
            }
        }
        else if (health > 20 && health <= 30)
        {
            int Numero2 = Random.Range(1, 101);
            if (Numero2 >= 35)
            {
                BasicDamage();
            }
            else if (Numero2 < 35)
            {
                HeavyDamage();
            }
        }
        else if (health > 0 && health <= 20)
        {
            int Numero3 = Random.Range(1, 101);
            if (Numero3 >= 40)
            {
                BasicDamage();
            }
            else if (Numero3 >= 15 && Numero3 < 40)
            {
                HeavyDamage();
            }
            else if (Numero3 < 15)
            {
                SuperHeavyDamage();
            }
            if (Numero3 <= 10)
            {
                Regeneration();
            }
        }
    }
    public void BasicDamage()
    {
        if (PlayerStadisticsScript.magicShieldBasicBool == false)
        {
            PlayerStadisticsScript.health -= 5;
            Debug.Log("The Boss dealt <color=red>5 damage</color> to the player with a <color=red>basic attack</color>.");


        }
        else
        {
            Debug.Log("<color=green>Magic shield</color> protected you from a <color=red>basic attack</color>.");
        }
        myAnim.Play("Enemy M Attack");
        PlayBasicAttackParticles();
    }
    public void HeavyDamage()
    {
        if (PlayerStadisticsScript.inmortalHeavyBool == false)
        {
            PlayerStadisticsScript.health -= 7;
            Debug.Log("The Boss dealt <color=red>7 damage</color> to the player with a <color=red>heavy attack</color>.");


        }
        else
        {
            Debug.Log("<color=green>Inmortal</color> protected you from a <color=red>heavy attack</color>.");
        }
        myAnim.Play("Enemy M HAttack");
        PlayHeavyAttackParticles();
    }
    public void SuperHeavyDamage()
    {
        if (PlayerStadisticsScript.inmortalHeavyBool == false)
        {
            PlayerStadisticsScript.health -= 9;
            Debug.Log("The Boss dealt <color=red>9 damage</color> to the player with a <color=red>super heavy attack</color>.");


        }
        else
        {
            Debug.Log("<color=green>Inmortal</color> protected you from a <color=red>super heavy attack</color>.");
        }
        myAnim.Play("Enemy M SHAttack");
        PlayHeavyAttackParticles();
    }
    public void Regeneration()
    {
        health += 10;
        health -= PlayerStadisticsScript.antihealingToEnemies;
        if (PlayerStadisticsScript.antihealingToEnemies > 0)
        {
            Debug.Log("Boss got damage by <color=red>Cursed Mud</color> when he tried to <color=green>heal himself</color> with 7 points of health.");
        }
        else
        {
            Debug.Log("The Boss <color=green>healed</color> 10 points of health.");
            myAnim.Play("Enemy M Health");
        }
    }
}
