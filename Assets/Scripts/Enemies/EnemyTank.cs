using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : Enemy
{
    public override void Start()
    {
        base.Start();
    }
    public override void Enemyturn()
    {
        if (health <= 40 && health > 25)
        {
            int Numero = Random.Range(1, 101);
            if (Numero >= 20)
            {
                BasicDamage();
            }
            else if (Numero < 20)
            {
                HeavyDamage();
            }
        }
        else if (health > 15 && health <= 25)
        {
            int Numero2 = Random.Range(1, 101);
            if (Numero2 >= 25)
            {
                BasicDamage();
            }
            else if (Numero2 < 25)
            {
                HeavyDamage();
            }
        }
        else if (health > 0 && health <= 15)
        {
            int Numero3 = Random.Range(1, 101);
            if (Numero3 >= 30)
            {
                BasicDamage();
            }
            else if (Numero3 < 30)
            {
                HeavyDamage();
            }
            if (Numero3 <= 20)
            {
                Regeneration();
            }
        }
    }
    public void BasicDamage()
    {
        PlayerStadisticsScript.health -= 4;
        Debug.Log("El enemigo inflingio 4 de daño al jugador con un ataque basico");
        PlayBasicAttackParticles();
    }
    public void HeavyDamage()
    {
        PlayerStadisticsScript.health -= 6;
        Debug.Log("El enemigo inflingio 6 de daño al jugador con un golpe pesado");
        PlayHeavyAttackParticles();
    }
    public void Regeneration()
    {
        health += 6;
        health -= PlayerStadisticsScript.antihealingToEnemies;
        if (PlayerStadisticsScript.antihealingToEnemies > 0)
        {
            Debug.Log("enemy got damage by Cursed Mud when tried to heal himself with 6 points of health");
        }
        else
        {
            Debug.Log("the enemy healed 6 points of health");

        }

    }
}