using Unity.Burst.Intrinsics;
using UnityEngine;

public class StudyTransform : MonoBehaviour
{
    public Transform local_up;

    public float move_speed = 10f;
    public float rotate_speed = 70f;

    private float angle = 0;
    private float local_angle = 0;

    private float world_rotation_x = 0;

    private float world_rotation_z = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.world_rotation_x = this.transform.rotation.eulerAngles.x;
        this.world_rotation_z = this.transform.rotation.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        // this.transform.position += this.transform.forward * this.move_speed * Time.deltaTime;

        // this.transform.Translate(Vector3.forward*this.move_speed*Time.deltaTime);


        // 월드 y축
        // this.angle = this.transform.rotation.eulerAngles.y + rotate_speed * Time.deltaTime;


        // 로컬 y축
        // this.local_angle = this.transform.localRotation.eulerAngles.y + rotate_speed * Time.deltaTime;


        // 월드 회전
        // this.transform.rotation = Quaternion.Euler(this.world_rotation_x, this.angle, this.world_rotation_z);

        // 로컬 회전
        // this.transform.localRotation = Quaternion.Euler(0, this.local_angle, 0);

        // 월드 기반 공전
        this.transform.RotateAround(Vector3.zero, Vector3.up, this.rotate_speed * Time.deltaTime);



    }
}
