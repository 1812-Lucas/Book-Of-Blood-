using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySectarian : Enemy
{
    public override void Start()
    {
        base.Start();
    }
    public override void Enemyturn()
    {
        if (health <= 30 && health > 20)
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
        else if (health > 10 && health <= 20)
        {
            int Numero2 = Random.Range(1, 101);
            if (Numero2 >= 40)
            {
                BasicDamage();
            }
            else if (Numero2 < 40)
            {
                HeavyDamage();
            }
        }
        else if (health > 0 && health <= 10)
        {
            int Numero3 = Random.Range(1, 101);
            if (Numero3 >= 50)
            {
                BasicDamage();
            }
            else if (Numero3 < 50)
            {
                HeavyDamage();
            }
            if (Numero3 <= 30)
            {
                Regeneration();
            }
        }
    }
    public void BasicDamage()
    {
        PlayerStadisticsScript.health -= 3;
        Debug.Log("El enemigo inflingio 3 de daño al jugador con un ataque basico");
       
        PlayBasicAttackParticles();
    }
    public void HeavyDamage()
    {
        PlayerStadisticsScript.health -= 5;
        Debug.Log("El enemigo inflingio 5 de daño al jugador con un golpe pesado");
       
        PlayHeavyAttackParticles();
    }
    public void Regeneration()
    {
        health += 5;
        Debug.Log("El enemigo se curo 5 de vida");
    }
}