using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    /// <summary> 공전 시 기준이 될 행성 </summary>
    public Transform target_plenet;

    /// <summary> 자전 속도 </summary>
    public float rot_speed = 30f;

    /// <summary> 공전 속도 </summary>
    public float rev_speed = 100f;

    /// <summary> 공전 여부 </summary>
    public bool isrev = false;

    void Update()
    {
        // 자전
        this.transform.Rotate(this.transform.up * this.rot_speed * Time.deltaTime);

        if (this.isrev)
        {
            // 공전
            this.transform.RotateAround(this.target_plenet.position, this.target_plenet.transform.up, this.rev_speed * Time.deltaTime);
        }


    }
}
