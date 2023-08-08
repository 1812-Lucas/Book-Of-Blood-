using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightEvent : MonoBehaviour
{

    [SerializeField] UnityEvent Ev_Activa;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Ev_Activa.Invoke();
        }

    }

}
