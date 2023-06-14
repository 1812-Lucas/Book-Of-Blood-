using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyAldeano : Enemy
{
    public override void Start()
    {
        base.Start();
    }
    public override void Enemyturn()
    {
        if (health <= 10 && health > 8)
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
        else if (health > 5 && health <= 8)
        {
            int Numero2 = Random.Range(1, 101);
            if (Numero2 >= 30)
            {
                BasicDamage();
            }
            else if (Numero2 < 30)
            {
                HeavyDamage();
            }
        }
        else if (health > 0 && health <= 5)
        {
            int Numero3 = Random.Range(1, 101);
            if (Numero3 >= 40)
            {
                BasicDamage();
            }
            else if (Numero3 < 40)
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
        //player._maxhealth -= 2;
        
        PlayerStadisticsScript.health -= 2;
        Debug.Log("El enemigo inflingio 2 de daño al jugador con un ataque basico");
        PlayBasicAttackParticles();

    }
    public void HeavyDamage()
    {
        //player._maxhealth -= 4;
        
        PlayerStadisticsScript.health -= 4;
        Debug.Log("El enemigo inflingio 4 de daño al jugador con un golpe pesado");
        PlayHeavyAttackParticles();

    }
    public void Regeneration()
    {
        health += 3;
        Debug.Log("El enemigo se curo 3 de vida");
    }
}