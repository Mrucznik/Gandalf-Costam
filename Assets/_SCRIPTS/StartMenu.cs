using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets._SCRIPTS
{
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
}
