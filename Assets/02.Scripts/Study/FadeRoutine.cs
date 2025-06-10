using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FadeRoutine : MonoBehaviour
{
    /// <summary> fade에 사용할 이미지 참조 </summary>
    public Image image;
    
    /// <summary> 로직에 사용될 타이머 변수 </summary>
    private float timer = 0f;

    public void OnFade(float param_time , Color param_color)
    {
        StartCoroutine(this.Fade(param_time, param_color));
    }

    IEnumerator Fade(float fade_time, Color param_color)
    {
        while (this.timer <= 1)
        {
            timer += Time.deltaTime / fade_time;
            this.image.color = new Color(param_color.r,param_color.g, param_color.b, this.timer);
            yield return null;
        }
    }
}
