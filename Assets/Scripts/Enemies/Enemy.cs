using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Player player;
    public Combat combat;
    CombatPosition _combatposition;
    public int health;
    public string tipodeenemigo;
    public StadisticPlayer PlayerStadisticsScript;
    public int attackType;

    public GameObject ataqueEnemy1Prefab;
    public GameObject ataqueEnemigo2Prefab;
    public GameObject debrisParticles;
    public GameObject ataqueEnemy1Prefab_combate2;
    public GameObject ataqueEnemigo2Prefab_Combate2;
    public GameObject debrisParticles_Combate2;
    public GameObject ataqueEnemy1Prefab_Combate3;
    public GameObject ataqueEnemigo2Prefab_Combate3;
    public GameObject debrisParticles_Combate3;

    private ParticleSystem ataqueEnemy1;
    private ParticleSystem ataqueEnemigo2;
    private ParticleSystem Debris;
    private ParticleSystem ataqueEnemy1_combate2;
    private ParticleSystem ataqueEnemigo2_combate2;
    private ParticleSystem Debris_combate2;
    private ParticleSystem ataqueEnemy1_combate3;
    private ParticleSystem ataqueEnemigo2_combate3;
    private ParticleSystem Debris_combate3;

    public virtual void Start()
    {
        Enemyapears();
        GameObject PlayerObject = GameObject.Find("Player");

        if (PlayerObject != null)
        {
            // Obtener la referencia al script "OtroScript" en el objeto encontrado
            combat = PlayerObject.GetComponent<Combat>();

        }

        // Crear instancias de los sistemas de partículas
        ataqueEnemy1 = Instantiate(ataqueEnemy1Prefab.transform).GetComponent<ParticleSystem>();
        ataqueEnemigo2 = Instantiate(ataqueEnemigo2Prefab.transform).GetComponent<ParticleSystem>();
        Debris = Instantiate(debrisParticles.transform).GetComponent<ParticleSystem>();
        ataqueEnemy1_combate2 = Instantiate(ataqueEnemy1Prefab_combate2.transform).GetComponent<ParticleSystem>();
        ataqueEnemigo2_combate2 = Instantiate(ataqueEnemigo2Prefab_Combate2.transform).GetComponent<ParticleSystem>();
        Debris_combate2 = Instantiate(debrisParticles_Combate2.transform).GetComponent<ParticleSystem>();
        ataqueEnemy1_combate3 = Instantiate(ataqueEnemy1Prefab_Combate3.transform).GetComponent<ParticleSystem>();
        ataqueEnemigo2_combate3 = Instantiate(ataqueEnemigo2Prefab_Combate3.transform).GetComponent<ParticleSystem>();
        Debris_combate3 = Instantiate(debrisParticles_Combate3.transform).GetComponent<ParticleSystem>();
        //ataqueEnemy1.Stop();  Asegurarse de que las partículas estén detenidas al inicio
        //ataqueEnemigo2.Stop();
        //Debris.Play();
    }
    void Enemyapears()
    {
        Debug.Log("Aparecio un " + tipodeenemigo);
    }
    private void Update()
    {
        EnemyDies();
    }
    public virtual void Enemyturn()
    {

    }
    
    public void Setcombat(CombatPosition combatPosition)
    {
        _combatposition = combatPosition;
    }
    public void SetPlayer(StadisticPlayer playerreference)
    {
        PlayerStadisticsScript = playerreference;
    }
    public virtual void EnemyDies()
    {
        if (health <= 0)
        {
            combat.EndOfCombat();//prueba
            PlayerStadisticsScript.vigor = 3;//prueba
            _combatposition.salircombate();
            Destroy(gameObject);
        }
    }

    public void PlayBasicAttackParticles()
    {
        ataqueEnemy1.Play();
        ataqueEnemy1_combate2.Play();
        ataqueEnemy1_combate3.Play();
    }

    public void PlayHeavyAttackParticles()
    {
        ataqueEnemigo2.Play();
        ataqueEnemigo2_combate2.Play();
        ataqueEnemigo2_combate3.Play();
        Debris.Play();
        Debris_combate2.Play();
        Debris_combate3.Play();
    }
}
