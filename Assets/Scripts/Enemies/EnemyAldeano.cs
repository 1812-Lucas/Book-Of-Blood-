using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyAldeano : Enemy
{
    public string basicAttackParticlesPrefabPath; // Ruta del prefab del sistema de part�culas del ataque b�sico
    public string heavyAttackParticlesPrefabPath; // Ruta del prefab del sistema de part�culas del golpe pesado

    private ParticleSystem ataqueEnemy1;
    private ParticleSystem ataqueEnemigo2;

    public override void Start()
    {
        base.Start();
        // Cargar los prefabs de los sistemas de part�culas en tiempo de ejecuci�n
        GameObject basicAttackParticlesPrefab = Resources.Load<GameObject>(basicAttackParticlesPrefabPath);
        GameObject heavyAttackParticlesPrefab = Resources.Load<GameObject>(heavyAttackParticlesPrefabPath);

        // Crear instancias de los sistemas de part�culas
        ataqueEnemy1 = Instantiate(basicAttackParticlesPrefab, transform).GetComponent<ParticleSystem>();
        ataqueEnemigo2 = Instantiate(heavyAttackParticlesPrefab, transform).GetComponent<ParticleSystem>();
        ataqueEnemy1.Stop(); // Asegurarse de que las part�culas est�n detenidas al inicio
        ataqueEnemigo2.Stop();

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
            if (Numero2 >= 40)
            {
                BasicDamage();
            }
            else if (Numero2 < 40)
            {
                HeavyDamage();
            }
        }
        else if (health > 0 && health <= 5)
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
            if (Numero3 <= 40)
            {
                Regeneration();
            }
        }
    }
    public void BasicDamage()
    {
        //player._maxhealth -= 2;
        
        PlayerStadisticsScript.health -= 2;
        Debug.Log("El enemigo inflingio 2 de da�o al jugador con un ataque basico");
        ataqueEnemy1.Play();
    }
    public void HeavyDamage()
    {
        //player._maxhealth -= 4;
        
        PlayerStadisticsScript.health -= 4;
        Debug.Log("El enemigo inflingio 4 de da�o al jugador con un golpe pesado");
        ataqueEnemigo2.Play();
    }
    public void Regeneration()
    {
        health += 3;
        Debug.Log("El enemigo se curo 3 de vida");
    }
}