using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartMenu : MonoBehaviour {


     public void PlayerVsComputer()
     {
        SceneManager.LoadScene(1);
     }

    public void PlayerVsPlayer()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
