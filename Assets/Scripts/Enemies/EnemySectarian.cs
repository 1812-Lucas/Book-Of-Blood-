using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySectarian : Enemy
{
    //public ParticleSystem ataqueEnemigo1;
    //public ParticleSystem ataqueEnemigo2;

    public override void Start()
    {
        base.Start();
        //ataqueEnemigo1 = gameObject.AddComponent<ParticleSystem>();
        //ataqueEnemigo2 = gameObject.AddComponent<ParticleSystem>();
    }
    public override void Enemyturn()
    {
        if (health <= 15 && health > 11)
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
        else if (health > 7 && health <= 11)
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
        else if (health > 0 && health <= 7)
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
            if (Numero3 <= 50)
            {
                Regeneration();
            }
        }
    }
    public void BasicDamage()
    {
        //player._maxhealth -= 3;
       // ataqueEnemigo1.Play();
        PlayerStadisticsScript.health -= 3;
        Debug.Log("El enemigo inflingio 3 de daño al jugador con un ataque basico");
    }
    public void HeavyDamage()
    {
        //player._maxhealth -= 5;
        //ataqueEnemigo2.Play();
        PlayerStadisticsScript.health -= 5;
        Debug.Log("El enemigo inflingio 5 de daño al jugador con un golpe pesado");
    }
    public void Regeneration()
    {
        health += 5;
        Debug.Log("El enemigo se curo 5 de vida");
    }
}