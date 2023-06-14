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
        if (health <= 20 && health > 15)
        {
            int Numero = Random.Range(1, 101);
            if (Numero >= 40)
            {
                BasicDamage();
            }
            else if (Numero < 40)
            {
                HeavyDamage();
            }
        }
        else if (health > 9 && health <= 15)
        {
            int Numero2 = Random.Range(1, 101);
            if (Numero2 >= 50)
            {
                BasicDamage();
            }
            else if (Numero2 < 50)
            {
                HeavyDamage();
            }
        }
        else if (health > 0 && health <= 9)
        {
            int Numero3 = Random.Range(1, 101);
            if (Numero3 >= 60)
            {
                BasicDamage();
            }
            else if (Numero3 < 60)
            {
                HeavyDamage();
            }
            if (Numero3 <= 40)
            {
                Regeneration();
            }
        }
    }
    public void BasicDamage()
    {
        //player._maxhealth -= 4;
        
        PlayerStadisticsScript.health -= 4;
        Debug.Log("El enemigo inflingio 4 de daño al jugador con un ataque basico");
        PlayBasicAttackParticles();

    }
    public void HeavyDamage()
    {
        //player._maxhealth -= 6;
       
        PlayerStadisticsScript.health -= 6;
        Debug.Log("El enemigo inflingio 6 de daño al jugador con un golpe pesado");
        PlayHeavyAttackParticles();

    }
    public void Regeneration()
    {
        health += 6;
        Debug.Log("El enemigo se curo 6 de vida");
    }
}