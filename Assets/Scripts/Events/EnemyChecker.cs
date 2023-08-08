using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using Cinemachine;

public class EnemyChecker : MonoBehaviour
{
    public int numEnemies;
    public float enemy2Contador;
    [SerializeField] UnityEvent Ev_Activa;
    public CinemachineVirtualCamera ActiveCamera;
    public List<CinemachineVirtualCamera> CamarasCombat2;

    public Animator rejaNivel1;

    private void Update()
    {
       // numEnemies = GameObject.FindGameObjectsWithTag("EnemyOpen").Length;
        if (numEnemies <= 0)
        {
            SwitchCameraCombat(CamarasCombat2[0]);
            rejaNivel1.SetBool("RejaBoolNivel1", true);
            rejaNivel1.CrossFade("RejaAnimationNivel1", 0f);
            StartCoroutine(CameraCombatTransition());
            EnemyKilled();
        }
    }
    public void SwitchCameraCombat(CinemachineVirtualCamera Combat2)
    {
        Combat2.Priority = 10;
        ActiveCamera = Combat2;

        foreach (CinemachineVirtualCamera c in CamarasCombat2)
        {
            if (c != Combat2 && c.Priority != 0)
            {
                c.Priority = 0;
            }
        }


    }
    IEnumerator CameraCombatTransition()
    {
        yield return new WaitForSeconds(enemy2Contador);
        SwitchCameraCombat(CamarasCombat2[1]);
        //transition();
        //Invoke("Playerenabled", 2.5f);

        yield return null;
    }
    public void EnemyKilled()
    {
        Ev_Activa.Invoke();
    }
}
