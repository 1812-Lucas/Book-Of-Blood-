using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject MenuControls;
    public GameObject MenuOptions;

    public void loadscene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void Restartscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}