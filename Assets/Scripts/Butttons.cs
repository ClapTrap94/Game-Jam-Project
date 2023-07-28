using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Butttons : MonoBehaviour
{
    public string gameStartScene;
    public void StartGame()
    {
        SceneManager.LoadScene(gameStartScene); 
    }

 

}
