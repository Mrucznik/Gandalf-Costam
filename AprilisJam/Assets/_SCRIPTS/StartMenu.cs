﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour {


     public void StartGame()
     {
         Application.LoadLevel(1);
     }

    public void Quit()
    {
        Application.Quit();
    }
}
