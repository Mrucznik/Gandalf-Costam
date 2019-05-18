using UnityEngine;
using UnityEngine.UI;

namespace Assets._SCRIPTS
{
    public class ScoreManag : MonoBehaviour {

        public static float Time;
        public static float DownTime;
        Text _text;

        private void Start()
        {
            _text = GetComponent<Text>();
            Time = 0;

            DownTime = UnityEngine.Time.time;

        }

        void Update()
        {
            if (Time < 0)
                Time = 0;


            ScoreManag.CountTime(0);

            _text.text = "" + Time;
        }

        public static void CountTime (int stop)
        {
            if (stop == 0)
            {
                Time = UnityEngine.Time.time - DownTime;
            }
            else
            {
                Time = 0;
                DownTime = UnityEngine.Time.time;
                UnityEngine.Time.timeScale = 0;
            
            
            }
        }
    
    }
}
