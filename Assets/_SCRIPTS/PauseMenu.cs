using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets._SCRIPTS
{
    public class PauseMenu : MonoBehaviour {

        public GameObject PauseUi;
        public GameObject Rickroll;

        private bool _paused = false;

        void Start ()
        {
            PauseUi.SetActive(false);
        }

        void Update ()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _paused = !_paused;
                if (Rickroll.activeSelf)
                {
                    AudioListener.pause = false;
                    Rickroll.SetActive(false);
                }
            }

            if (_paused)
            {
                PauseUi.SetActive(true);
                Time.timeScale = 0;
            }

            if (!_paused)
            {
                PauseUi.SetActive(false);
                Time.timeScale = 1;
            }
        }

        public void Resume()
        {
            _paused = false;
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
            AudioListener.pause = true;
            Rickroll.SetActive(true);
        }
    }
}
