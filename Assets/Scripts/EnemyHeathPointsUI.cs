using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHeathPointsUI : MonoBehaviour
{
    public Enemy EnemyScript;
   
    private TextMeshProUGUI HealthEnemyCounter;


    private void Start()
    {
        HealthEnemyCounter = GetComponent<TextMeshProUGUI>();

    }

    public void Update()
    {
        //HealthEnemyCounter.text = Enemy.health.ToString();

    }

}
