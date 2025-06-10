using System.Security.Cryptography;
using UnityEngine;

namespace Cat
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource audio_source;

        public AudioClip jump_sound_clip;
        public AudioClip intro_bgm_sound_clip;
        public AudioClip play_bgm_sound_clip;
        public AudioClip collider_sound_clip;

        /// <summary> 스크립트 변수 초기화 및 BGM 재생 </summary>
        public void SetBackgroundMusic(string param_bgm)
        {
            if (param_bgm == "Intro")
            {
                this.audio_source.clip = this.intro_bgm_sound_clip;
            }
            else if (param_bgm == "Play")
            {
                this.audio_source.clip = this.play_bgm_sound_clip;
            }
            this.audio_source.playOnAwake = true;
            this.audio_source.loop = true;
            this.audio_source.volume = 0.4f;

            this.audio_source.Play();
        }

        /// <summary> 점프 사운드 한번 재생 </summary>
        public void OnJumpSound()
        {
            this.audio_source.PlayOneShot(this.jump_sound_clip); // 이벤트 사운드 ( 오디오 클립이 바뀌는게 아닌 임시 인스턴스를 생성하는 느낌이라 BGM이 끊기지 않음 )
        }

        public void OnColliderSound()
        {
            this.audio_source.PlayOneShot(this.collider_sound_clip);
        }

    }
}
