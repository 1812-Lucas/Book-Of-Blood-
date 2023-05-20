using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CombatPosition : MonoBehaviour
{
    //public EnemyAldeano enemyAldean;

    public Enemy enemyy;
    public Combat combatscript;
    public List<GameObject> enemyGObj;
    public Transform enemytransf;
    public GameObject areaWhereTheEnemySpawns;

    public List<GameObject> AreasWhereTheEnemiesSpawns;
    public int CounterforPlacesWhereEnemiesSpawns;

    public bool battlePosition = false;
    public bool CombatON = false;
    public bool enemyInvoke = false;
    public Rigidbody playerRB;
    public Camera mainCamera;
    public Player player;
    public List<CinemachineVirtualCamera> cameras;
    public CinemachineVirtualCamera ActiveCamera;
    GameManager myGM;
    public MyCamera camerascript;
    public int enemiesreminder;
    public Deck deckscript;
    public VigorDeck vigordeckscript;
    public VigorCardsDisplay ScriptVigorCardDisplaySlot4;
    public VigorCardsDisplay ScriptVigorCardDisplaySlot5;
    public VigorCardsDisplay ScriptVigorCardDisplaySlot6;
    public StadisticPlayer stadisticPlayerScript;
    public EnemyHeathPointsUI EnemyHealthPointsScript;



    public float ContadorTransicion;

    public void Start()
    {
        myGM = GameManager.instance;
    }

    public void salircombate()
    {

        enemiesreminder--;
        if (enemiesreminder <= 0)
        {
            Cursor.lockState = CursorLockMode.Locked;
            SwitchCamera(cameras[0]);
            myGM.activeUI();
            battlePosition = false;
            //camerascript.enabled = true;
            player.enabled = true;
            playerRB.constraints = RigidbodyConstraints.None;
            playerRB.constraints = RigidbodyConstraints.FreezeRotation;
            CombatON = false;
            enemyInvoke = false;
            Debug.Log("Saliste del combate");
        }
    }

    public void combatON()
    {
        Cursor.lockState = CursorLockMode.Confined;
        SwitchCamera(cameras[1]);
        battlePosition = true;
        camerascript.enabled = false;
        myGM.activeUI();
        player.enabled = false;
        vigordeckscript.CreateListOfMyVigorCardsBuildForCombat();
        deckscript.CreateListOfMyrCardsBuildForCombat();
        Vector3 direccion = new Vector3(7, 0, 12);
        transform.LookAt(direccion);
        mainCamera.transform.LookAt(enemytransf);
        playerRB.constraints = RigidbodyConstraints.FreezeAll;
        //playerRB.freezeRotation = true;
        Debug.Log("Entraste en combate");
        deckscript.DrawCards();
        vigordeckscript.DrawCards();
        CombatON = true;
    }
    public void SwitchCamera(CinemachineVirtualCamera camera)
    {

        camera.Priority = 10;
        ActiveCamera = camera;


        // camerascript.canMoveCamera = false;

        foreach (CinemachineVirtualCamera c in cameras)
        {
            if (c != camera && c.Priority != 0)
            {
                c.Priority = 0;


            }
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            Destroy(other.gameObject);
            camerascript.canMoveCamera = false;
            enemiesreminder = 1;

            if (enemyInvoke == false)
            {
                EnemyInvoke();
            }

            Destroy(areaWhereTheEnemySpawns.gameObject);

            if (CombatON == false)
            {
                combatON();
            }
        }
    }
    void EnemyInvoke()
    {
        //Enemy actualenemy = Instantiate(enemyGObj[Random.Range(0, enemyGObj.Count)], areaWhereTheEnemySpawns.transform.position, areaWhereTheEnemySpawns.transform.rotation).GetComponent<Enemy>(); FUNCIONA PREDETERMINADO
        Enemy actualenemy = Instantiate(enemyGObj[CounterforPlacesWhereEnemiesSpawns], AreasWhereTheEnemiesSpawns[CounterforPlacesWhereEnemiesSpawns].transform.position, AreasWhereTheEnemiesSpawns[CounterforPlacesWhereEnemiesSpawns].transform.rotation).GetComponent<Enemy>();  //PRUEBA

        //enemyGObj.Remove(actualenemy); NO FUNCIONA
        actualenemy.Setcombat(this);
        actualenemy.SetPlayer(stadisticPlayerScript);
        combatscript.setenemy(actualenemy);
        EnemyHealthPointsScript.SetEnemyInEnemyHealthPoints(actualenemy);
        ScriptVigorCardDisplaySlot4.setenemy(actualenemy);
        ScriptVigorCardDisplaySlot5.setenemy(actualenemy);
        ScriptVigorCardDisplaySlot6.setenemy(actualenemy);
        enemyInvoke = true;
        CounterforPlacesWhereEnemiesSpawns += 1; // PRUEBA
    }
    /*private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 9)
        {
            Destroy(other.gameObject);
            camerascript.canMoveCamera = false;
            enemiesreminder = 1;
            Enemy actualenemy = Instantiate(enemyGObj[Random.Range(0, enemyGObj.Count)], areaWhereTheEnemySpawns.transform.position, areaWhereTheEnemySpawns.transform.rotation).GetComponent<Enemy>();
            actualenemy.Setcombat(this);
            actualenemy.SetPlayer(stadisticPlayerScript);
            combatscript.setenemy(actualenemy);

            EnemyHealthPointsScript.SetEnemyInEnemyHealthPoints(actualenemy);

            ScriptVigorCardDisplaySlot4.setenemy(actualenemy);
            ScriptVigorCardDisplaySlot5.setenemy(actualenemy);
            ScriptVigorCardDisplaySlot6.setenemy(actualenemy);
            Destroy(areaWhereTheEnemySpawns.gameObject);
            //StartCoroutine(CamaraTransicionCombate());
            combatON();
        }
    }*/
}
//IEnumerator CamaraTransicionCombate()
//{
//    yield return new WaitForSeconds(ContadorTransicion);


//    camerascript.canMoveCamera = false;

//    yield return null;
//}

