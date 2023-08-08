using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class EnemyChecker : MonoBehaviour
{
    public int numEnemies;
    [SerializeField] UnityEvent Ev_Activa;

    private void Update()
    {
        numEnemies = GameObject.FindGameObjectsWithTag("EnemyOpen").Length;
        if (numEnemies <= 0)
        {
            EnemyKilled();
        }
    }

    public void EnemyKilled()
    {
        Ev_Activa.Invoke();
    }
}
