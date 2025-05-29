using Unity.VisualScripting;
using UnityEngine;

public class Pinball : MonoBehaviour
{
    /// <summary> 태그 점수 배열 </summary>
    public int[] tag_score_arr = { 10, 20, 30 };

    /// <summary> 공의 시작 지점 </summary>
    private Vector2 ball_start_pos;

    /// <summary> 핀볼 매니저 인스턴스 </summary>
    public PinballManager pinballManager;

    void Start()
    {
        this.ball_start_pos = this.transform.position;
    }

    /// <summary>  충돌 시 충돌한 오브젝트의 점수가 무엇인지 순차적으로 검사 </summary>
    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (int element in this.tag_score_arr)
        {
            if (collision.gameObject.CompareTag($"Score_{element}"))
            {
                // 점수 가산
                this.pinballManager.Add_Score(element);
                Debug.Log($"{element}점 획득");

                return;
            }
        }
    }

    /// <summary> 게임오버 트리거 접촉 시 게임오버 로그 출력 및 처음 위치로 재배치 </summary>
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GameOver"))
        {
            Debug.Log($"게임 오버. 총 점수 : {this.pinballManager.Get_Score()}");

            // 점수 초기화
            this.pinballManager.Init_Score();

            // 게임 오버시 재배치
            this.transform.position = this.ball_start_pos;

        }
    }
}
