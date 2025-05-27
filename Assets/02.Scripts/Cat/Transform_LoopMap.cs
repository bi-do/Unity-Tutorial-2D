using UnityEngine;

public class Transform_LoopMap : MonoBehaviour
{
    public float move_speed = 5f;

    public float width = 30f;

    public float sprite_count = 2f;

    // 고정된 위치로 변경시 detatime의 오차를 막을 수 없음.
    // 만약 if문 실행시의 값이 -30.xxx라면 완전히 30으로 떨어지지 않는 상황에서 고정값으로 x 값을 30으로 만들기 때문에
    // 정확하게 60의 값이 오른쪽으로 가는것이 아닌 60.xxx값이 가산되는것이고 2번째 타일 및 배경은 if문 실행 당시에
    // x 좌표가 정확하게 0이 아닌 -0.xxx일 것이기에 둘의 중심점 차이는 30이 아닌 30.xxx가 되어버림.
    // 그러므로 0.xxx의 값 만큼 실선이 생기는 것
    // public Vector3 return_pos = new Vector3(30, 0, 0);

    void Update()
    {
        this.transform.position += Vector3.left * this.move_speed * Time.deltaTime;

        if (this.transform.position.x <= -this.width)
        {
            this.transform.position += new Vector3(this.width * this.sprite_count, 0, 0);
        }
    }
}