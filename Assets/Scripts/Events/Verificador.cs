using UnityEngine;
using UnityEngine.Events;

public class Verificador : MonoBehaviour
{
    CombatPosition combatPositionScript; // Referencia al script CombatPosition
    [SerializeField] UnityEvent Ev_Activa;
    [SerializeField] UnityEvent Ev_Activa2;

    private void Awake()
    {
        // Obtener una referencia al script CombatPosition en el mismo objeto
        combatPositionScript = GetComponent<CombatPosition>();
    }

    private void Update()
    {
        // Verificar si combatON es true en el script CombatPosition
        if (combatPositionScript.CombatON)
        {
            EnemyKilled();
        }
        if (combatPositionScript.CombatON==false)
        {
            EnemyKilled2();
        }
    }

    public void EnemyKilled()
    {
        Ev_Activa.Invoke();
    }

    public void EnemyKilled2()
    {
        Ev_Activa2.Invoke();
    }
}


