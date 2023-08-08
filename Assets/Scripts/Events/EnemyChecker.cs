using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class EnemyChecker : MonoBehaviour
{
    public int numEnemies;
    [SerializeField] UnityEvent Ev_Activa;

    public Animator rejaNivel1;

    private void Update()
    {
        numEnemies = GameObject.FindGameObjectsWithTag("EnemyOpen").Length;
        if (numEnemies <= 0)
        {
            rejaNivel1.SetBool("RejaBoolNivel1", true);
            rejaNivel1.CrossFade("RejaAnimationNivel1", 0f);
            EnemyKilled();
        }
    }

    public void EnemyKilled()
    {
        Ev_Activa.Invoke();
    }
}
