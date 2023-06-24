using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyAldeano : Enemy
{
    private Animator myAnim;
    public override void Awake()
    {
        myAnim = GetComponentInChildren<Animator>();
        base.Awake();
    }
    public override void Start()
    {
        base.Start();
    }
    public override void Enemyturn()
    {
        //Isattack(true);
        if (health <= 20 && health > 15)
        {
            int Numero = Random.Range(1, 101);
            if (Numero >= 10)
            {
                BasicDamage();
            }
            else if (Numero < 10)
            {
                HeavyDamage();
            }
        }
        else if (health > 5 && health <= 15)
        {
            int Numero2 = Random.Range(1, 101);
            if (Numero2 >= 15)
            {
                BasicDamage();
            }
            else if (Numero2 < 15)
            {
                HeavyDamage();
            }
        }
        else if (health > 0 && health <= 5)
        {
            int Numero3 = Random.Range(1, 101);
            if (Numero3 >= 20)
            {
                BasicDamage();
            }
            else if (Numero3 < 20)
            {
                HeavyDamage();
            }
            if (Numero3 <= 10)
            {
                Regeneration();
            }
        }
    }
    public void BasicDamage()
    {
        PlayerStadisticsScript.health -= 2;
        Debug.Log("El enemigo inflingio 2 de daño al jugador con un ataque basico");
        PlayBasicAttackParticles();
    }
    public void HeavyDamage()
    {
        PlayerStadisticsScript.health -= 4;
        Debug.Log("El enemigo inflingio 4 de daño al jugador con un golpe pesado");
        PlayHeavyAttackParticles();
    }
    public void Regeneration()
    {
        health += 3;
       

        health -= PlayerStadisticsScript.antihealingToEnemies;
        if (PlayerStadisticsScript.antihealingToEnemies > 0)
        {
            Debug.Log("enemy got damage by Cursed Mud when tried to heal himself with 3 points of health");
        }
        else
        {
            Debug.Log("the enemy healed 3 points of health");

        }
    }
    public void Isattack(bool attack)
    {
        myAnim.SetBool("isattack", attack);
    }
}