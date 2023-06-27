using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneFinalBattle : MonoBehaviour
{
    public Slider barraProgreso;

    private void Start()
    {
        StartCoroutine(CargarJuego());
    }

    private IEnumerator CargarJuego()
    {
        AsyncOperation cargaOperacion = SceneManager.LoadSceneAsync("NewZone");

        while (!cargaOperacion.isDone)
        {
            float progreso = Mathf.Clamp01(cargaOperacion.progress / 0.9f);
            barraProgreso.value = progreso;
            yield return null;
        }
        SceneManager.LoadScene("NewZone");
    }
}
