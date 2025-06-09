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


    void Start()
    {
        StartCoroutine(this.FadeRoutineA(3 , false));
    }
    IEnumerator FadeRoutineA(float fade_time , bool isFadeIn)
    {
        float value = 1;
        if (isFadeIn)
        {
            this.timer = 1f;
            value = -1;
        }
        while (this.timer <= 1)
        {
            timer += (Time.deltaTime / fade_time) * value;
            this.image.color = new Color(0, 0, 0, this.timer);
            yield return null;
        }
    }
}
