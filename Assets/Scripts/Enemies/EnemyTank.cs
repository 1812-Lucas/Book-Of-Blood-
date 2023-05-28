using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : Enemy
{
    public string basicAttackParticlesPrefabPath; // Ruta del prefab del sistema de partículas del ataque básico
    public string heavyAttackParticlesPrefabPath; // Ruta del prefab del sistema de partículas del golpe pesado

    private ParticleSystem ataqueEnemy1;
    private ParticleSystem ataqueEnemigo2;

    public override void Start()
    {
        base.Start();
        // Cargar los prefabs de los sistemas de partículas en tiempo de ejecución
        GameObject basicAttackParticlesPrefab = Resources.Load<GameObject>(basicAttackParticlesPrefabPath);
        GameObject heavyAttackParticlesPrefab = Resources.Load<GameObject>(heavyAttackParticlesPrefabPath);

        // Crear instancias de los sistemas de partículas
        ataqueEnemy1 = Instantiate(basicAttackParticlesPrefab, transform).GetComponent<ParticleSystem>();
        ataqueEnemigo2 = Instantiate(heavyAttackParticlesPrefab, transform).GetComponent<ParticleSystem>();
        ataqueEnemy1.Stop(); // Asegurarse de que las partículas estén detenidas al inicio
        ataqueEnemigo2.Stop();
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
            if (Numero2 >= 60)
            {
                BasicDamage();
            }
            else if (Numero2 < 60)
            {
                HeavyDamage();
            }
        }
        else if (health > 0 && health <= 9)
        {
            int Numero3 = Random.Range(1, 101);
            if (Numero3 >= 70)
            {
                BasicDamage();
            }
            else if (Numero3 < 70)
            {
                HeavyDamage();
            }
            if (Numero3 <= 60)
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
        ataqueEnemy1.Play();
    }
    public void HeavyDamage()
    {
        //player._maxhealth -= 6;
       
        PlayerStadisticsScript.health -= 6;
        Debug.Log("El enemigo inflingio 6 de daño al jugador con un golpe pesado");
        ataqueEnemigo2.Play();
    }
    public void Regeneration()
    {
        health += 6;
        Debug.Log("El enemigo se curo 6 de vida");
    }
}