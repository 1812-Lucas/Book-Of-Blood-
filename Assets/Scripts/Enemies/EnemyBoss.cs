using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : Enemy
{
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
        PlayerStadisticsScript.health -= 5;
        Debug.Log("El jefe inflingio 5 de daño al jugador con un ataque basico");
        PlayBasicAttackParticles();
    }
    public void HeavyDamage()
    {
        PlayerStadisticsScript.health -= 7;
        Debug.Log("El jefe inflingio 7 de daño al jugador con un golpe pesado");
        PlayHeavyAttackParticles();
    }
    public void SuperHeavyDamage()
    {
        PlayerStadisticsScript.health -= 10;
        Debug.Log("El jefe inflingio 10 de daño al jugador con un golpe super pesado");
        PlayHeavyAttackParticles();
    }
    public void Regeneration()
    {
        health += 7;
        Debug.Log("El jefe se curo 7 de vida");
    }
}
