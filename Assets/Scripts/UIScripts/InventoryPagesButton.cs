using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPagesButton : MonoBehaviour
{
    public GameObject[] PagesCounter;
    private int actualPaceInTheArray;

    private void Start()
    {
        // Inicializar el �ndice actual a cero
        actualPaceInTheArray = 0;
        // Desactivar todas las im�genes excepto la primera
        for (int i = 1; i < PagesCounter.Length; i++)
        {
            PagesCounter[i].gameObject.SetActive(false);
        }
    }

    public void Alternar()
    {
        // Desactivar la imagen actual
        PagesCounter[actualPaceInTheArray].gameObject.SetActive(false);

        // Incrementar el �ndice actual
        actualPaceInTheArray++;

        // Si el �ndice actual es mayor o igual al tama�o del arreglo, volver al inicio
        if (actualPaceInTheArray >= PagesCounter.Length)
        {
            actualPaceInTheArray = 0;
        }

        // Activar la siguiente imagen
        PagesCounter[actualPaceInTheArray].gameObject.SetActive(true);
    }
}
