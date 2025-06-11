using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class RemoteController : MonoBehaviour
{
    public GameObject video_screen;

    public VideoClip[] clips;
    private VideoPlayer video_player;

    public Button[] buttons_UI;

    public int cur_clip_index = 0;

    public bool isMute = false;

    void Awake()
    {
        this.video_player = this.video_screen.GetComponent<VideoPlayer>();
    }

    void Start()
    {
        this.buttons_UI[0].onClick.AddListener(OnVideoPowerSwitch);
        this.buttons_UI[1].onClick.AddListener(OnMute);
        this.buttons_UI[2].onClick.AddListener(() => this.OnChangeChennel(-1));
        this.buttons_UI[3].onClick.AddListener(() => this.OnChangeChennel(1));
    }

    public void OnVideoPowerSwitch()
    {
        this.video_screen.SetActive(!this.video_screen.activeSelf);
    }

    void OnMute()
    {
        this.isMute = !this.isMute;
        this.video_player.SetDirectAudioMute(0, this.isMute);
    }

    void OnChangeChennel(int param_index_direction)
    {
        this.cur_clip_index += param_index_direction;
        if (this.cur_clip_index >= this.clips.Length)
        {
            this.cur_clip_index = 0;
        }
        else if (this.cur_clip_index < 0)
        {
            this.cur_clip_index = this.clips.Length - 1;
        }

        this.video_player.clip = this.clips[this.cur_clip_index];
        this.video_player.Play();
    }
}
