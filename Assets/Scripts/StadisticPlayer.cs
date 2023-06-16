using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class StadisticPlayer : MonoBehaviour
{
    public int health = 50;
    public int vigor = 1;
    public int defense;
    public GameManager _myGM;

    public void Update()
    {
        if (health > 50)
        {
            health = 50;
        }

        if (health <= 0)
        {
            PlayerDies();
        }
    }

    public void PlayerDies()
    {
        SceneManager.LoadScene("LoseScene");
    }
}
