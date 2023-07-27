using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class SensorGrid : MonoBehaviour
{
    [SerializeField] UnityEvent EV_OnTriggerGrid;
    [SerializeField] UnityEvent EV_OnExitTriggerGrid;

    public float gridCounter;
    public CinemachineVirtualCamera gridCamera;
    public Player player;
    public Collider playerColl;
    public Rigidbody playerRB;
    public List<CinemachineVirtualCamera> gridCameras;
    public CinemachineVirtualCamera activeCamera;
    public MyCamera myCamera;


    private void OnTriggerEnter(Collider other)
    {
        print("The grid <color=yellow>opened</color>.");
        if (IsPlayer(other))
        {
            SwitchCameraDoor(gridCameras[1]);
            player.enabled = false;
            myCamera.canMoveCamera = false;
            playerRB.constraints = RigidbodyConstraints.FreezeAll;
            EV_OnTriggerGrid.Invoke();
            playerColl.enabled = false;
            
            StartCoroutine(CameraTransation());
        }
    }



    public void SwitchCameraDoor(CinemachineVirtualCamera Door)
    {
        Door.Priority = 10;
        activeCamera = Door;

        foreach (CinemachineVirtualCamera c in gridCameras)
        {
            if (c != Door && c.Priority != 0)
            {
                c.Priority = 0;
            }
        }


    }
    bool IsPlayer(Collider col)
    {
        Player c = col.GetComponent<Player>();
        if (c == GameManager.instance.Player())
        {
            return true;
        }
        return false;
    }

    IEnumerator CameraTransation()
    {
        yield return new WaitForSeconds(gridCounter);

        transition();
        Invoke("PlayerEnabled", 2.5f);

        yield return null;
    }

    void transition()
    {
        SwitchCameraDoor(gridCameras[0]);
        EV_OnExitTriggerGrid.Invoke();

    }
    void PlayerEnabled()
    {
        player.enabled = true;
        playerRB.constraints = RigidbodyConstraints.None;
        playerRB.constraints = RigidbodyConstraints.FreezeRotation;
        myCamera.canMoveCamera = true;

    }
}
