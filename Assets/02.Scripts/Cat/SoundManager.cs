using System.Security.Cryptography;
using UnityEngine;

namespace Cat
{
    public class SoundManager : MonoBehaviour
    {
        public AudioClip jump_sound_clip;
        public AudioSource audio_source;
        public AudioClip bgm_sound_clip;

        void Start()
        {
            this.SetBackgroundMusic();
        }

        /// <summary> 스크립트 변수 초기화 및 BGM 재생 </summary>
        public void SetBackgroundMusic()
        {
            this.audio_source.clip = this.bgm_sound_clip;
            this.audio_source.playOnAwake = true;
            this.audio_source.loop = true;
            this.audio_source.volume = 0.4f;

            this.audio_source.Play();
        }

        /// <summary> 점프 사운드 한번 재생 </summary>
        public void OnJumpSound()
        {
            this.audio_source.PlayOneShot(jump_sound_clip); // 이벤트 사운드 ( 오디오 클립이 바뀌는게 아닌 임시 인스턴스를 생성하는 느낌이라 BGM이 끊기지 않음 )
        }

    }
}
