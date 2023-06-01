using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;  // Referencia al transform del jugador
    public float range = 10f; // Rango en el que el enemigo comenzará a seguir al jugador
    public float speed = 5f;  // Velocidad de movimiento del enemigo
    private bool isFollowing; // Indica si el enemigo está siguiendo al jugador

    void Update()
    {
        // Calcula la distancia entre el enemigo y el jugador
        float distance = Vector3.Distance(transform.position, player.position);

        // Si el jugador está dentro del rango, comienza a seguirlo
        if (distance <= range)
        {
            isFollowing = true;
        }
        else
        {
            isFollowing = false;
        }

        // Si está siguiendo al jugador, mueve al enemigo hacia él
        if (isFollowing)
        {
            // Calcula la dirección hacia el jugador
            Vector3 direction = (player.position - transform.position).normalized;

            // Mueve al enemigo en la dirección del jugador con la velocidad especificada
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
