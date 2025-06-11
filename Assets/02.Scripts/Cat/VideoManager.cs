using UnityEngine;
using UnityEngine.Video;
namespace Cat
{
    public class VideoManager : MonoBehaviour
    {
        public VideoClip[] clips;
        public GameObject video_panel;

        public VideoPlayer video_player;

        void Start()
        {
            this.video_player = this.GetComponent<VideoPlayer>();
        }

        public void VideoPlay(bool param_isClear)
        {
            this.video_panel.SetActive(true);

            int index = param_isClear ? 0 : 1;

            this.video_player.clip = this.clips[index];
            this.video_player.Play();
        }
    }
}
