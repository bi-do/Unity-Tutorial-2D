using UnityEngine;

public class Study_Invoke : MonoBehaviour
{
    public float timer = 10f;

    private string fun_ptr = "Bomb";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Invoke 반복 ( 함수 명 , 첫번째 호출 지연시간 , 첫 호출 이후 재실행 주기 )
        InvokeRepeating(this.fun_ptr, 0f, 1f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("폭탄이 해제되었습니다.");
            CancelInvoke(this.fun_ptr);

        }
    }

    private void Bomb()
    {
        Debug.Log($"현재 남은 폭탄 시간 : {this.timer} 초");
        if (this.timer == 0)
        {
            Debug.Log("폭탄이 터졌습니다.");
            CancelInvoke(this.fun_ptr);
        }
        this.timer--;
    }
}
