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
    public virtual void Start()
    {
        Enemyapears();
        GameObject PlayerObject = GameObject.Find("Player");

        if (PlayerObject != null)
        {
            // Obtener la referencia al script "OtroScript" en el objeto encontrado
            combat = PlayerObject.GetComponent<Combat>();

        }
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
            PlayerStadisticsScript.vigor = 0;//prueba
            _combatposition.salircombate();
            Destroy(gameObject);
        }
    }
}
