using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cat
{
    public class UIManager : MonoBehaviour
    {
        public GameObject play_obj;

        public GameObject fade_panel;

        public GameObject intro_panel;

        /// <summary> 사용자 입력 필드 </summary>
        public TMP_InputField input_field;

        /// <summary> 고양이 이름 출력 필드 </summary>
        public TextMeshProUGUI name_text;

        public Button start_button;

        public void OnStartBtn()
        {
            if (input_field.text.Length == 0)
            {
                Debug.Log("이름이 설정되지 않았습니다.");
            }
            else
            {
                // 플레이 씬 활성화 
                this.play_obj.SetActive(true);

                // 페이드 효과 패널 활성화 
                this.fade_panel.SetActive(true);

                // 인트로 패널 비활성화 
                this.intro_panel.SetActive(false);

                // 텍스트 이름 동기화
                this.name_text.text = this.input_field.text;
            }

        }
    }

}
