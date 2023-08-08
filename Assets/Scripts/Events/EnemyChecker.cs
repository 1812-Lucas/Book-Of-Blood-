using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using Cinemachine;

public class EnemyChecker : MonoBehaviour
{
    public int numEnemies;
    public int enemy2Contador;
    public int enemy2ContadorCamera3;
    [SerializeField] UnityEvent Ev_Activa;
    [SerializeField] UnityEvent Ev_Exit;
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
            StartCoroutine(CameraCombatTransition2());
            EnemyKilled();
        }
    }
    public void SwitchCameraCombat(CinemachineVirtualCamera Combat2)
    {
        Combat2.Priority = 11;
        ActiveCamera = Combat2;

        foreach (CinemachineVirtualCamera c in CamarasCombat2)
        {
            if (c != Combat2 && c.Priority != 11)
            {
                c.Priority = 11;
            }
        }


    }
    IEnumerator CameraCombatTransition()
    {
        yield return new WaitForSeconds(enemy2Contador);
        SwitchCameraCombat(CamarasCombat2[1]);
        //SwitchCameraCombat(CamarasCombat2[2]);
       // Ev_Exit.Invoke();

        yield return null;
    }
    IEnumerator CameraCombatTransition2()
    {
        yield return new WaitForSeconds(enemy2ContadorCamera3);
        
        SwitchCameraCombat(CamarasCombat2[2]);
        Ev_Exit.Invoke();

        yield return null;
    }
    public void EnemyKilled()
    {
        Ev_Activa.Invoke();
    }
}
