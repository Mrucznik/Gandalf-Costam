using UnityEngine;

namespace Assets._SCRIPTS
{
    public class CameraChangingBgColor : MonoBehaviour {

        public Color Color1 = Color.red;
        public Color Color2 = Color.blue;
        public float Duration = 3.0F;

        void Start()
        {
        }

        void Update()
        {
            float t = Mathf.PingPong(Time.time, Duration) / Duration;

            Camera.main.backgroundColor = Color.Lerp(Color1, Color2, t);
            if(Camera.main.backgroundColor == Color2)
            {
                Color tmp = Color2;
                Color2 = Color1;
                Color1 = tmp;
            }
        }
    }
}
