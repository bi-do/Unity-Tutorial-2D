using UnityEngine;

public class Bullet : MonoBehaviour
{
    /// <summary> 탄속 </summary>
    public float bullet_speed = 30f;

    void Update()
    {
        // 총알 생성시 Update마다 포지션 변경 ( 발사 )
        this.transform.position += this.transform.forward * this.bullet_speed * Time.deltaTime;
    }
}
