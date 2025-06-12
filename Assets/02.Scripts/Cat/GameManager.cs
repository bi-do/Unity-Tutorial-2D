using TMPro;
using UnityEngine;

namespace Cat
{
    public class GameManager : MonoBehaviour
    {
        public SoundManager soundManager;

        public TextMeshProUGUI play_time_UI;
        public TextMeshProUGUI score_UI;

        private static float timer = 0;
        public static int score = 0;

        public static bool isPlay = false;

        void Start()
        {
            this.soundManager.SetBackgroundMusic("Intro");
        }

        void Update()
        {
            if (!isPlay)
            {
                return;
            }
            else
            {
                timer += Time.deltaTime;
                this.play_time_UI.text = $"플레이 시간 : {timer:F1}";

                this.score_UI.text = $"X {score}";
            }
        }

        public static void ResetPlayUI()
        {
            timer = 0;
            score = 0;
        } 
    }

}
