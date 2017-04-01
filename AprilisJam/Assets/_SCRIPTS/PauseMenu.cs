using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public GameObject PauseUI;

    private bool paused = false;

	void Start ()
    {
        
        PauseUI.SetActive(false);
	}

	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }

        if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Resume()
    {
        paused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
        

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Help()
    {
        SceneManager.LoadScene("Ricky");
    }
}
