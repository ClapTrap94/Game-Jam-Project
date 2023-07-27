using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverMenu;

    private void OnEnable()
    {
        //PlayerScript.OnPlayerDeath += EnableGameOverMenu;
    }

    private void OnDisable()
    {
       // PlayerScript.OnPlayerDeath -= EnableGameOverMenu;
    }

    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }
}
