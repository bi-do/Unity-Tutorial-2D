using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cat
{
    public class UIManager : MonoBehaviour
    {
        public SoundManager sound_manager;
        public VideoManager video_manager;

        public GameObject play_obj;

        public GameObject play_panel;

        public GameObject intro_panel;

        /// <summary> 사용자 입력 필드 </summary>
        public TMP_InputField input_field;

        /// <summary> 고양이 이름 출력 필드 </summary>
        public TextMeshProUGUI name_text;

        public Button start_button;
        public Button Re_Start_button;

        void Awake()
        {
            this.play_obj.SetActive(false);
            this.play_panel.SetActive(false);
            this.intro_panel.SetActive(true);
        }

        void Start()
        {
            this.start_button.onClick.AddListener(this.OnStartBtn);
            this.Re_Start_button.onClick.AddListener(this.OnReStartBtn);
        }

        public void OnStartBtn()
        {
            if (input_field.text.Length == 0)
            {
                Debug.Log("이름이 설정되지 않았습니다.");
            }
            else
            {
                // BGM 교체
                this.sound_manager.SetBackgroundMusic("Play");

                // 플레이 씬 활성화 
                this.play_obj.SetActive(true);

                // 플레이 UI 패널 활성화 
                this.play_panel.SetActive(true);

                // 인트로 UI 패널 비활성화 
                this.intro_panel.SetActive(false);

                // 게임 씬 시작 ( 타이머 작동 및 UI 활성화 )
                GameManager.isPlay = true;

                // 텍스트 이름 동기화
                this.name_text.text = this.input_field.text;
            }

        }

        public void OnReStartBtn()
        {
            this.play_obj.SetActive(true);
            GameManager.ResetPlayUI();
            this.video_manager.VideoStop();
        }
    }
}
