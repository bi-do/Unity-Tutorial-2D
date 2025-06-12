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

    public void OnFade(float param_time , Color param_color, bool param_isFade)
    {
        StartCoroutine(this.Fade(param_time, param_color, param_isFade));
    }

    IEnumerator Fade(float fade_time, Color param_color , bool param_isFade)
    {
        Debug.Log("fade 시작");
        float value;
        while (this.timer <= 1)
        {
            timer += Time.deltaTime / fade_time;
            
            value = param_isFade ? timer : 1 - timer;
            this.image.color = new Color(param_color.r, param_color.g, param_color.b, value);
            yield return null;
        }
        this.timer = 0f;
    }
}
